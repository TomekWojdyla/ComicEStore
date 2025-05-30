﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicEStoreDomain.Models;

namespace ComicEStoreApplication.Services;

public interface IProductService
{
    public Task<List<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task<Product> Update(Product product);
    Task<Product> Add(Product product);
}
