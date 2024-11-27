using System;

namespace Portfolio.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; } // In production, use hashed passwords!
    public string Role { get; set; } // "Admin" or "Client"
}
