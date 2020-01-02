using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Areas.Admin.Models.Self
{
    public class AppointmentModel : BaseNopEntityModel
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public short StatusId { get; set; }
        public int ResourceId { get; set; }
        [NopResourceDisplayName("Admin.Orders.Fields.Customer")]
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Orders.Fields.CustomerEmail")]
        public string CustomerEmail { get; set; }
        public string CustomerFullName { get; set; }
    }

    public class TimeSlot
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
