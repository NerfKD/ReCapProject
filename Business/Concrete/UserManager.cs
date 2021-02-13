using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _userDal.Delete(entity);
                return new SuccessResult(Messages.UserDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<User>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
            }
        }

        public IDataResult<User> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<User>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id), Messages.UserListed);
            }
        }

        public IResult Update(User entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _userDal.Update(entity);
                return new SuccessResult(Messages.UserUpdated);
            }
        }
    }
}
