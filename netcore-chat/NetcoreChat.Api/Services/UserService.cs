using System;
using NetcoreChat.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NetcoreChat.Models;

namespace NetcoreChat.Services
{
    public class UserService
    {
        static IDictionary<string, UserDto> UsersDictionary = new Dictionary<string, UserDto>();

        public static UserDto Connect(string connectionId)
        {
            if (!UsersDictionary.TryGetValue(connectionId, out var user))
            {
                user = new UserDto
                {
                    UserName = connectionId
                };
                UsersDictionary.Add(connectionId, user);
            }
                
            user.Status = UserStatus.Online;

            return user;
        }

        public UserDto GetUserByConnectionId(string contextConnectionId)
        {
            if (UsersDictionary.TryGetValue(contextConnectionId, out var user))
                return user;

            throw new ArgumentException();
        }
    }
}
