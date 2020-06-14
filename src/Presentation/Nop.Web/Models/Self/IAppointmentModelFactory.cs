using Nop.Core.Domain.Self;
using System.Collections.Generic;

namespace Nop.Web.Models.Self
{
    public interface IAppointmentModelFactory
    {
        AppointmentUpdateModel PrepareAppointmentUpdateModel(Appointment appointment);
        AppointmentInfoModel PrepareAppointmentInfoModel(Appointment appointment);
        VendorAppointmentInfoModel PrepareVendorAppointmentInfoModel(Appointment appointment);
        List<VendorResourceModel> PrepareVendorResourcesModel(int vendorId);
    };
}