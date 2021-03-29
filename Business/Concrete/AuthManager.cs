using Business.Abstract;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetUserByEmail(email).Data;
            if (result != null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var token = _tokenHelper.CreateToken(user,claims);

            return new SuccessDataResult<AccessToken>(token);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetUserByEmail(userForLoginDto.Email).Data;
            if (user==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPassword(userForLoginDto.Password,user.PasswordHash,user.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.BadPassword);
            }
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }
    }
}
