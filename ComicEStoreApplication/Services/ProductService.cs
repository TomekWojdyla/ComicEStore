using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicEStoreDomain.Models;

namespace ComicEStoreApplication.Services;

public class ProductService : IProductService
{
    Task<Product> IProductService.Add(Product product)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>> IProductService.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<Product> IProductService.GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Product> IProductService.Update(Product product)
    {
        throw new NotImplementedException();
    }
}
