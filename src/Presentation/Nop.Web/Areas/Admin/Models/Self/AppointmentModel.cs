using Nop.Core.Domain.Self;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;

namespace Nop.Web.Areas.Admin.Models.Self
{
    public class AppointmentModel : BaseNopEntityModel
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        [NopResourceDisplayName("Admin.Appointment.Fields.Status")]
        public AppointmentStatusType Status { get; set; }
        public int ResourceId { get; set; }
        [NopResourceDisplayName("Admin.Appointment.Fields.Customer")]
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Appointment.Fields.CustomerEmail")]
        public string CustomerEmail { get; set; }
        public string CustomerFullName { get; set; }

        public bool IsLoggedInAsVendor { get; set; }
        public bool CanCancel { get; set; }
        public bool CanConfirm { get; set; }
    }

    public class TimeSlot
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
