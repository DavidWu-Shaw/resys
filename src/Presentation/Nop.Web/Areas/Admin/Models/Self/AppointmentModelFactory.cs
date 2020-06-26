﻿using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Self;
using Nop.Services.Helpers;
using Nop.Web.Areas.Admin.Models.Catalog;
using System;

namespace Nop.Web.Areas.Admin.Models.Self
{
    public partial class AppointmentModelFactory : IAppointmentModelFactory
    {
        private readonly IDateTimeHelper _dateTimeHelper;

        public AppointmentModelFactory(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        public virtual AppointmentEditModel PrepareAppointmentEditModel(Appointment appointment)
        {
            var model = new AppointmentEditModel();
            if (appointment != null)
            {
                model.Id = appointment.Id;
                var start = _dateTimeHelper.ConvertToUserTime(appointment.StartTimeUtc, DateTimeKind.Utc);
                var end = _dateTimeHelper.ConvertToUserTime(appointment.EndTimeUtc, DateTimeKind.Utc);
                model.TimeSlot = $"{start.ToShortTimeString()} - {end.ToShortTimeString()}, {start.ToShortDateString()} {start.ToString("dddd")}";
                model.Status = appointment.Status;
                model.Notes = appointment.Notes;
                model.CustomerId = appointment.CustomerId ?? 0;
                if (appointment.Customer != null)
                {
                    model.CustomerFullName = appointment.Customer.Email;
                    model.CustomerEmail = appointment.Customer.Email;
                }
                else
                {
                    model.CustomerFullName = "N/A";
                    model.CustomerEmail = "N/A";
                }
            }

            return model;
        }

        public virtual AppointmentInfoModel PrepareAppointmentInfoModel(Appointment appointment)
        {
            var model = new AppointmentInfoModel
            {
                id = appointment.Id.ToString(),
                start = _dateTimeHelper.ConvertToUserTime(appointment.StartTimeUtc, DateTimeKind.Utc).ToString("yyyy-MM-ddTHH:mm:ss"),
                end = _dateTimeHelper.ConvertToUserTime(appointment.EndTimeUtc, DateTimeKind.Utc).ToString("yyyy-MM-ddTHH:mm:ss"),
                resource = appointment.ResourceId.ToString()
            };
            model.tags = new TagModel
            {
                status = appointment.Status.ToString(),
                doctor = appointment.Product.Name
            };
            if (appointment.Customer != null)
            {
                model.text = appointment.Customer.Username;
            };

            return model;
        }

        public ProductCalendarModel PrepareProductCalendarModel(ProductCalendarModel model, Product product)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.Id = product.Id;
            model.ProductName = product.Name;
            model.IsParentProduct = product.ProductType == ProductType.GroupedProduct;
            model.ShowCalendar = true;
            // Child product or parent product can't edit schedule
            model.ShowSchedule = product.ParentGroupedProductId == 0 && product.ProductType == ProductType.SimpleProduct;

            model.BusinessBeginsHour = 9;
            model.BusinessEndsHour = 21;
            model.BusinessMorningShiftEndsHour = 12;
            model.BusinessAfternoonShiftBeginsHour = 13;
            model.BusinessOnWeekends = true;

            return model;
        }
    }
}
