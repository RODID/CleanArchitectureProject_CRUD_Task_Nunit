﻿using Application.Dtos;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Users
{
    public class AddNewUserCommand : IRequest<OperationResult<User>>
    {
        public AddNewUserCommand(UserDTO newName)
        {
            UserName = user.UserName;
            Password = user.Password;
            Email = user.Email;
        }

        public UserDTO NewUser { get; }
        public string UserName { get; set; }
        public string Password {  get; set; }
        public string Email { get; set; }
    }
}
