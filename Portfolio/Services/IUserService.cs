using System;
using Portfolio.Models;

namespace Portfolio.Services;

public interface IUserService
{
    User Authenticate(string username, string password);
    void RegisterUser(string username, string password);
}

