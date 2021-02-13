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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer entity)
        {
            if(DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.CustomerAdded);
            }
        }

        public IResult Delete(Customer entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _customerDal.Delete(entity);
                return new SuccessResult(Messages.CustomerDeleted);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Customer>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
            }
        }

        public IDataResult<Customer> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Customer>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(p => p.UserId == Id), Messages.CustomerListed);
            }
        }

        public IResult Update(Customer entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _customerDal.Update(entity);
                return new SuccessResult(Messages.CustomerUpdated);
            }
        }
    }
}
