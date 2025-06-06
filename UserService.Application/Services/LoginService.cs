﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Exceptions;
using UserService.Domain.Repositories;

namespace UserService.Application.Services;

public class LoginService : ILoginService
{
    protected IJwtTokenService _jwtTokenService;
    protected IUserRepository _userRepository;

    public LoginService(IJwtTokenService jwtTokenService, IUserRepository userRepository)
    {
        _jwtTokenService = jwtTokenService;
        _userRepository = userRepository;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user == null || user.Password != password)
        {
            throw new InvalidCredentialsException();
        }

        var roles = user.Roles.Select(r => r.Name).ToList();

        var token = _jwtTokenService.GenerateToken(user.Id, roles);
        
        return token;
    }
}
