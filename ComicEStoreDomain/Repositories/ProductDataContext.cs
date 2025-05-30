using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicEStoreDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicEStoreDomain.Repositories;

public class ProductDataContext : DbContext
{

    public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options) { }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Product> Products { get; set; }
}
