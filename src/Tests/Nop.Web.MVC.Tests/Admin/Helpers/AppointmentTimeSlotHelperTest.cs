using Nop.Web.Areas.Admin.Helpers;
using Nop.Web.Areas.Admin.Models.Self;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Nop.Web.MVC.Tests.Admin.Helpers
{
    [TestFixture]
    public class AppointmentTimeSlotHelperTest
    {
        [Test]
        public void Should_Create_8_Slots_For_1_Day_With_8_Hours_Shift()
        {
            AppointmentTimeSlotHelper helper = new AppointmentTimeSlotHelper(9, 13, 14, 18);
            DateTime start = new DateTime(2050, 12, 21, 10, 0, 0);
            List<TimeSlot> timeSlots = helper.GetSlotsByHour(start, start.AddHours(2));

            Assert.AreEqual(8, timeSlots.Count);
        }
    }
}
