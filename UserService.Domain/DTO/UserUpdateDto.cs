using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.DTO;

public class UserUpdateDto
{
    [MaxLength(100)]
    public string Username { get; set; }

    [MaxLength(255)]
    public string Email { get; set; }

    public bool IsActive { get; set; }

    public List<int> RoleIds { get; set; } = new();
}
