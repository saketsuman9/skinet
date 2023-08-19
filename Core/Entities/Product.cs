using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}