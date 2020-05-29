using System;
using System.Collections.Generic;
using Hearthstone.Core;
using System.Linq;

namespace Hearthstone.Data
{
    public class SqlCardData : ICardData
    {
        private readonly HearthstoneDbContext db;

        public SqlCardData(HearthstoneDbContext db)
        {
            this.db = db;
        }

        public Card Add(Card newCard)
        {
            db.Add(newCard);
            return newCard;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Card Delete(int id)
        {
            var card = GetById(id);
            if(card != null)
            {
                db.Cards.Remove(card);
            }
            return card;
        }

        public Card GetById(int id)
        {
            return db.Cards.Find(id);
        }

        public IEnumerable<Card> GetCardsByName(string name)
        {
            var query = from c in db.Cards
                        where c.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby c.Name
                        select c;
            return query;
        }

        public int GetCountOfCards()
        {
            return db.Cards.Count();
        }

        public Card Update(Card updatedCard)
        {
            var entity = db.Cards.Attach(updatedCard);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedCard;
        }
    }
}
