using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EfEntityRepositoryBase<User,ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();               
            }
        }

        public UserEditedDto GetUserDtoByEmail(string email)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from user in context.Users
                             where user.Email == email
                             select new UserEditedDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
