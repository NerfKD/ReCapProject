using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetById(int Id);
        IDataResult<Card> GetLastCardByUserId(int userId);
        IResult Add(Card card, int userId);
        IResult Delete(Card card, int userId);
        IDataResult<List<Card>> GetAllByUserId(int userId);
    }
}
