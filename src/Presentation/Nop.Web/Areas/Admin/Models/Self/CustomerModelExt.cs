using Nop.Web.Areas.Admin.Models.Self;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Nop.Web.Areas.Admin.Models.Customers
{
    public partial class CustomerModel
    {
        [NopResourceDisplayName("Admin.Customers.Customers.Fields.MemberOfVendors")]
        public IList<CustomerVendorModel> CustomerVendorsModel { get; set; }
        public bool IsLoggedInAsVendor { get; set; }
        // customer is a member of the vendor
        [NopResourceDisplayName("Admin.Customers.Customers.Fields.MemberOfVendors")]
        public IList<int> SelectedVendorIds { get; set; }
    }
}
