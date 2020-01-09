using Nop.Core.Domain.Self;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Models.Self
{
    public class AppointmentUpdateModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Product.Appointment.Fields.TimeSlot")]
        public string TimeSlot { get; set; }
        [NopResourceDisplayName("Product.Appointment.Fields.Status")]
        public AppointmentStatusType Status { get; set; }
        public int ResourceId { get; set; }
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Product.Appointment.Fields.CustomerEmail")]
        public string CustomerEmail { get; set; }
        [NopResourceDisplayName("Product.Appointment.Fields.CustomerFirstName")]
        public string CustomerFirstName { get; set; }
        [NopResourceDisplayName("Product.Appointment.Fields.CustomerLastName")]
        public string CustomerLastName { get; set; }
        [NopResourceDisplayName("Product.Appointment.Fields.CustomerPhoneNumber")]
        public string CustomerPhoneNumber { get; set; }
        [NopResourceDisplayName("Product.Appointment.Fields.CustomerNotes")]
        public string CustomerNotes { get; set; }

        public bool CanCancel { get; set; }
        public bool CanRequest { get; set; }
    }
}
