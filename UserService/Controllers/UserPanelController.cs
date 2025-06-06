﻿using Microsoft.AspNetCore.Mvc;
using UserService.Domain.DTO;
using UserService.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPanelController : ControllerBase
{
    
    private IUserService _userService;
    public UserPanelController(IUserService userService)
    {
        _userService = userService;
    }

    // GET api/<UserController>/5
    [HttpGet("get-current-user")]
    [Authorize(Policy = "RegisteredOnly")]
    public async Task<IActionResult> Get()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);
        var userDto = await _userService.GetUserDtoByIdAsync(userId);

        return Ok(userDto);

    }

    // PATCH api/<UserController>/5
    [HttpPatch("change-password")]
    [Authorize(Policy = "RegisteredOnly")]
    public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);

        try
        {
            var result = await _userService.ChangePasswordAsync(userId, dto);

            if (result)
                return Ok(new { message = "Hasło zostało pomyślnie zmienione." });

            return BadRequest(new { message = "Nie udało się zmienić hasła. Sprawdź aktualne hasło." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Wystąpił błąd serwera.", error = ex.Message });
        }

    }

    // PUT api/<UserController>/5
    [HttpPut("edit-account")]
    [Authorize(Policy = "RegisteredOnly")]
    public async Task<IActionResult> EditAccount([FromBody] UserEditDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim.Value);

        try
        {
            var result = await _userService.EditUserAccountAsync(userId, dto);

            if (result)
                return Ok(new { message = "Konto zmodyfikowane pomyślnie." });

            return BadRequest(new { message = "Nie udało się wyedytować konta. Skontaktuj się z administratorem." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Wystąpił błąd serwera.", error = ex.Message });
        }

    }

}