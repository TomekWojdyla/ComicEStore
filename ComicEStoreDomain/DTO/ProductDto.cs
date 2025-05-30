using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicEStoreDomain.DTO;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    // Informacje o Publisherze (np. nazwa i Id)
    public int PublisherId { get; set; }
    public string PublisherName { get; set; } = string.Empty;
}
