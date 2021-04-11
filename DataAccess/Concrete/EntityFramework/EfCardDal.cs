using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCardDal : EfEntityRepositoryBase<Card, CBCContext>, ICardDal
    {
        public void AddUserCards(UserCard userCard)
        {
            using (CBCContext context = new CBCContext())
            {
                var addedEntity = context.Entry(userCard);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Card GetLastCardByUserId(int userId)
        {
            using (CBCContext context = new CBCContext())
            {
                var result = from ca in context.Cards
                             join uc in context.UserCards on ca.Id equals uc.CardId
                             where uc.UserId == userId

                             select new Card
                             {
                                 Id = ca.Id,
                                 CardHoldersName = ca.CardHoldersName,
                                 CardNumber = ca.CardNumber,
                                 CardExpirationMonth = ca.CardExpirationMonth,
                                 CardExpirationYear = ca.CardExpirationYear,
                                 CardCvcNumber = ca.CardCvcNumber
                             };
                return result.OrderByDescending(x => x.Id).FirstOrDefault();
            }
        }


        public List<Card> GetAllByUserId(int userId)
        {
                using (CBCContext context = new CBCContext())
                {
                    var result = from ca in context.Cards
                                 join uc in context.UserCards on ca.Id  equals uc.CardId
                                 where uc.UserId == userId
                                
                                 select new Card
                                 {
                                     Id = ca.Id,
                                     CardHoldersName = ca.CardHoldersName,
                                     CardNumber = ca.CardNumber,
                                     CardExpirationMonth = ca.CardExpirationMonth,
                                     CardExpirationYear = ca.CardExpirationYear,
                                     CardCvcNumber = ca.CardCvcNumber
                                 };
                    return result.ToList();
                }
        }


    }
}
