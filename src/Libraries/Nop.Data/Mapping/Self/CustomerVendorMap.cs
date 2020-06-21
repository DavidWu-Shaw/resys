using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Self;

namespace Nop.Data.Mapping.Self
{
    /// <summary>
    /// Represents a product category mapping configuration
    /// </summary>
    public partial class CustomerVendorMap : NopEntityTypeConfiguration<CustomerVendor>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerVendor> builder)
        {
            builder.ToTable(NopMappingDefaults.CustomerVendorTable);
            builder.HasKey(CustomerVendor => CustomerVendor.Id);

            builder.HasOne(CustomerVendor => CustomerVendor.Vendor)
                .WithMany()
                .HasForeignKey(CustomerVendor => CustomerVendor.VendorId)
                .IsRequired();

            builder.HasOne(CustomerVendor => CustomerVendor.Customer)
                .WithMany(c => c.CustomerVendors)
                .HasForeignKey(CustomerVendor => CustomerVendor.CustomerId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}