﻿namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Product : BaseDalEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? PictureUri { get; set; }

        public int? ProductTypeId { get; set; }

        public ProductType? ProductType { get; set; }

        public int? ProductBrandId { get; set; }

        public Brand? ProductBrand { get; set; }
    }
}
