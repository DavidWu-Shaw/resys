using Nop.Core.Domain.Self;
using Nop.Services.Helpers;

namespace Nop.Web.Models.Self
{
    public partial class AppointmentModelFactory : IAppointmentModelFactory
    {
        private readonly IDateTimeHelper _dateTimeHelper;

        public AppointmentModelFactory()
        {

        }

        public virtual AppointmentUpdateModel PrepareAppointmentUpdateModel(Appointment appointment)
        {
            var model = new AppointmentUpdateModel();
            if (appointment != null)
            {
                model.Id = appointment.Id;
                model.Status = appointment.Status;
                model.ResourceId = appointment.ResourceId;
                model.CustomerId = appointment.CustomerId;
                if (appointment.Customer != null)
                {
                    model.CustomerEmail = appointment.Customer.Email;
                }
                model.CanCancel = appointment.Status != AppointmentStatusType.Free;
                model.CanRequest = appointment.Status == AppointmentStatusType.Free;
            }
            else
            {
                model.Status = AppointmentStatusType.Free;
                model.CanRequest = true;
            }

            return model;
        }

        public virtual AppointmentInfoModel PrepareAppointmentInfoModel(Appointment appointment)
        {
            var model = new AppointmentInfoModel
            {
                id = appointment.Id.ToString(),
                start = appointment.StartTimeUtc.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss"),
                end = appointment.EndTimeUtc.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss"),
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
    }
}
