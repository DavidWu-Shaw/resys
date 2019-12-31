using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Self;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Self;
using Nop.Web.Areas.Admin.Helpers;
using Nop.Web.Models.Self;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class AppointmentController : BaseAdminController
    {
        public const int MORNING_SHIFT_STARTS = 9;
        public const int MORNING_SHIFT_ENDS = 13;
        public const int AFTERNOON_SHIFT_STARTS = 14;
        public const int AFTERNOON_SHIFT_ENDS = 18;

        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IAppointmentService _appointmentService;
        private readonly IWorkContext _workContext;

        #endregion Fields

        #region Ctor

        public AppointmentController(CatalogSettings catalogSettings,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IAppointmentService appointmentService,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _appointmentService = appointmentService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpPost]
        public virtual IActionResult List(DateTime start, DateTime end, int resourceId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageProductReviews))
                return AccessDeniedDataTablesJson();

            var events = _appointmentService.GetAppointmentsByResource(start, end, resourceId);

            var model = new List<AppointmentModel>();
            foreach (var appointment in events)
            {
                var item = AppointmentModelFactory.ConvertToModel(appointment);
                model.Add(item);
            }

            return Json(model);
        }

        [HttpPost]
        public virtual IActionResult Create(DateTime start, DateTime end, int resourceId, string scale)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageProductReviews))
                return AccessDeniedView();

            var timeSlots = GetSlots(start, end, scale);
            foreach (var slot in timeSlots)
            {
                Appointment appointment = new Appointment
                {
                    StartTimeUtc = slot.Start.ToUniversalTime(),
                    EndTimeUtc = slot.End.ToUniversalTime(),
                    ResourceId = resourceId,
                    Label = string.Empty,
                    Status = AppointmentStatusType.free
                };

                _appointmentService.InsertAppointment(appointment);
            }

            return Json(new { status = true, responseText = $"{timeSlots.Count} records created." });
        }

        private List<TimeSlot> GetSlots(DateTime start, DateTime end, string scale)
        {
            if (scale == "shifts")
            {
                return GetSlotsByShift(start, end);
            }
            else
            {
                var helper = new AppointmentTimeSlotHelper(MORNING_SHIFT_STARTS, MORNING_SHIFT_ENDS, AFTERNOON_SHIFT_STARTS, AFTERNOON_SHIFT_ENDS);
                return helper.GetSlotsByHour(start, end);
            }
        }


        private List<TimeSlot> GetSlotsByShift(DateTime start, DateTime end)
        {
            var result = new List<TimeSlot>();

            return result;
        }

        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageProductReviews))
                return AccessDeniedView();

            return Json(new { status = true, responseText = "Deleted." });
        }

        #endregion
    }
}