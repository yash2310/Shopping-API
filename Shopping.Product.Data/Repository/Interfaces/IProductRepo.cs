﻿using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Product.Data
{
    public interface IProductRepo: IMongoRepository<ProductEntity>
    {
    }
}
