using Nop.Core.Domain.Self;

namespace Nop.Web.Areas.Admin.Models.Self
{
    public static class AppointmentModelFactory
    {
        public static AppointmentInfoModel ConvertToModel(Appointment appointment)
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
