using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace ToDoListAPI.Dtos;

public class RegisterDto
{
    [MinLength(4, ErrorMessage = "Username should be atleast 4 characters")]
    [MaxLength(8, ErrorMessage = "Username should be atmost 8 characters")]
    public required String Username { get; set; }
    
    [MinLength(4, ErrorMessage = "Password should be atleast 4 characters")]
    [MaxLength(8, ErrorMessage = "Password should be atmost 8 characters")]
    public required String Password { get; set; }

}
