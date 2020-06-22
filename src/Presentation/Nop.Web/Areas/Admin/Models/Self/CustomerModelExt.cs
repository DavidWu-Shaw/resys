using Nop.Web.Areas.Admin.Models.Self;
using System.Collections.Generic;

namespace Nop.Web.Areas.Admin.Models.Customers
{
    public partial class CustomerModel
    {
        public IList<CustomerVendorModel> CustomerVendorsModel { get; set; }
        public bool IsLoggedInAsVendor { get; set; }
    }
}
