using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Self;

namespace Nop.Services.Self
{
    public partial interface IAppointmentService
    {
        Appointment GetAppointmentById(int appointmentId);
        void InsertAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
        List<Appointment> GetAppointmentsByResource(DateTime startTimeUtc, DateTime endTimeUtc, int resourceId);
        List<Appointment> GetAvailableAppointmentsByCustomer(DateTime startTimeUtc, DateTime endTimeUtc, int resourceId, int customerId);
    }
}
