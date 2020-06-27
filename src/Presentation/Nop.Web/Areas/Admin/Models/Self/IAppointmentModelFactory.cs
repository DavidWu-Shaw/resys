using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Self;
using Nop.Web.Areas.Admin.Models.Catalog;
using System.Collections.Generic;

namespace Nop.Web.Areas.Admin.Models.Self
{
    public interface IAppointmentModelFactory
    {
        AppointmentEditModel PrepareAppointmentEditModel(Appointment appointment);
        AppointmentInfoModel PrepareAppointmentInfoModel(Appointment appointment);
        ProductCalendarModel PrepareProductCalendarModel(ProductCalendarModel model, Product product);
        VendorAppointmentInfoModel PrepareVendorAppointmentInfoModel(Appointment appointment);
        List<VendorResourceModel> PrepareVendorResourcesModel(int parentProductId);
    };
}
