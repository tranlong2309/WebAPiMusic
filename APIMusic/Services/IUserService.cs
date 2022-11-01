using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using APIMusic.Entities;
using APIMusic.Models.Requests;
using APIMusic.Models.Response;

namespace APIMusic.Services
{
    public interface IUserService
    {
        AuthenticateResponses Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponses RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);

        User GetCurrentUser();
        bool RegisterUser(RegisterUserRequest request);
    }
}
