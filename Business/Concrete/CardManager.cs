using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;

        }
        public IResult Add(Card card, int userId)
        {
            _cardDal.Add(card);
            card = _cardDal.GetLastCardByUserId(userId);
            UserCard userCard = new UserCard { UserId = userId, CardId = card.Id };
            _cardDal.AddUserCards(userCard);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Card card, int userId)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }
        public IDataResult<Card> GetLastCardByUserId(int userId)
        {
            return new SuccessDataResult<Card>(_cardDal.GetLastCardByUserId(userId), Messages.CardsListed);
        }
        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CardsListed);
        }

        public IDataResult<List<Card>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAllByUserId(userId), Messages.CardsListed);
        }

        public IDataResult<Card> GetById(int Id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(p => p.Id == Id), Messages.CardListed);
        }
    }
}
