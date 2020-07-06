using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Web.Components
{
    public class CustomerRegisteredProductsViewComponent : NopViewComponent
    {
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        public CustomerRegisteredProductsViewComponent(IWorkContext workContext,
            IProductModelFactory productModelFactory,
            IProductService productService)
        {
            _workContext = workContext;
            _productModelFactory = productModelFactory;
            _productService = productService;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize)
        {
            var products = new List<Product>();
            foreach (var customerVendor in _workContext.CurrentCustomer.CustomerVendorMappings)
            {
                var vendorProducts = _productService.SearchProducts(vendorId: customerVendor.VendorId, visibleIndividuallyOnly: true);
                products.AddRange(vendorProducts);
            }

            if (!products.Any())
                return Content("");

            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();

            return View(model);
        }
    }
}