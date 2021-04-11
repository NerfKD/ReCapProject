using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICardDal : IEntityRepository<Card>
    {
        List<Card> GetAllByUserId(int userId);

        void AddUserCards(UserCard userCard);
        Card GetLastCardByUserId(int userId);
    }
}
