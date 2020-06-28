using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public class ProductCalendarModel : BaseNopEntityModel
    {
        public string ProductName { get; set; }

        public bool ShowCalendar { get; set; }
        public bool ShowSchedule { get; set; }
        public bool IsParentProduct { get; set; }

        public int BusinessBeginsHour { get; set; }
        public int BusinessEndsHour { get; set; }
        public int BusinessMorningShiftEndsHour { get; set; }
        public int BusinessAfternoonShiftBeginsHour { get; set; }
        public bool BusinessOnWeekends { get; set; }

    }
}
