using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult UpdatePassword(User entity, string password);
        IResult Delete(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
    }
}
