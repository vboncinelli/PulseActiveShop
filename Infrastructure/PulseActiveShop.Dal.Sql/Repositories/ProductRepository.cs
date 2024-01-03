﻿using Microsoft.Extensions.Configuration;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Product, Domain.ProductCollection, EF.Product>
    {
        public ProductRepository(IConfiguration configuration) : base(configuration, new[] { "Brand", "ProductType" })
        {
        }

        protected override IQueryable<EF.Product> GetDefaultOrdering(IQueryable<EF.Product> query)
        {
            return query.OrderBy(product => product.Id);
        }

        #region Mappings

        protected override EF.Product ToDal(Domain.Product entity)
        {
            var dalEntity = new EF.Product()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                BrandId = entity.BrandId,
                ProductTypeId = entity.ProductTypeId,
                Price = entity.Price,
                PictureUri = entity.PictureUri,
            };

            return dalEntity;
        }

        protected override Domain.Product? ToDomain(EF.Product? dalEntity)
        {
            if (dalEntity == null) return null;

            var entity = new Domain.Product(
                name: dalEntity.Name,
                description: dalEntity.Description,
                productTypeId: dalEntity.ProductType!.Id,
                productTypeName: dalEntity.ProductType.Type,
                brandId: dalEntity.Brand!.Id,
                brandName: dalEntity.Brand!.Name,
                pictureUri: dalEntity.PictureUri,
                price: dalEntity.Price);

            return entity;
        } 
        #endregion
    }
}
