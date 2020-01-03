using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Self;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Self;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;
using Nop.Web.Models.Self;

namespace Nop.Web.Controllers
{
    [HttpsRequirement(SslRequirement.No)]
    public partial class AppointmentController : BasePublicController
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IAppointmentService _appointmentService;
        private readonly IWorkContext _workContext;
        private readonly OrderSettings _orderSettings;

        #endregion Fields

        #region Ctor

        public AppointmentController(CatalogSettings catalogSettings,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IAppointmentService appointmentService,
            IWorkContext workContext,
            OrderSettings orderSettings)
        {
            _catalogSettings = catalogSettings;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _appointmentService = appointmentService;
            _workContext = workContext;
            _orderSettings = orderSettings;
        }

        #endregion

        #region Methods

        [HttpPost]
        public virtual IActionResult AvailableSlotsByCustomer(DateTime start, DateTime end, int resourceId)
        {
            var events = _appointmentService.GetAvailableAppointmentsByCustomer(start, end, resourceId, _workContext.CurrentCustomer.Id);

            var model = new List<AppointmentModel>();
            foreach (var appointment in events)
            {
                var item = AppointmentModelFactory.ConvertToModel(appointment);
                model.Add(item);
            }

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult AppointmentRequest(int id)
        {
            if (_workContext.CurrentCustomer.IsGuest() && (!_orderSettings.AnonymousCheckoutAllowed))
                return Challenge();

            var requestedAppointment = _appointmentService.GetAppointmentById(id);
            if (requestedAppointment.Status == AppointmentStatusType.Free)
            {
                requestedAppointment.CustomerId = _workContext.CurrentCustomer.Id;
                requestedAppointment.Status = AppointmentStatusType.Waiting;
                _appointmentService.UpdateAppointment(requestedAppointment);

                return Json(new { status = true, responseText = $"Appointment requested." });
            }
            else
            {
                return Json(new { status = false, responseText = $"Appointment request failed." });
            }
        }
        #endregion
    }
}