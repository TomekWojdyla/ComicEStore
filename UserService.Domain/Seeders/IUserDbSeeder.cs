﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Seeders;

public interface IUserDbSeeder
{
    Task Seed();
}
