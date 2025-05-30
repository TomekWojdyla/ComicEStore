using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicEStoreDomain.Models;

public class Product : BaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; } = 0;

    public int PublisherId { get; set; } // FK

    public Publisher Publisher { get; set; } = default!;
}
