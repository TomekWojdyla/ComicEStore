using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicEStoreDomain.DTO;

public class ProductCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    [Required]
    public int PublisherId { get; set; }
}
