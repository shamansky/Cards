using System;
using System.Collections.Generic;
using System.Linq;
using Hearthstone.Core;

namespace Hearthstone.Data
{
    public class InMemoryCardData : ICardData
    {

        readonly List<Card> cards;

        public InMemoryCardData()
        {
            cards = new List<Card>()
            {
                new Card { Id = 1, Name = "Tirion Fordring", Cost = 8, Class = ClassType.Paladin},
                new Card { Id = 2, Name = "Khadgar", Cost = 2, Class = ClassType.Mage},
                new Card { Id = 3, Name = "Grommash Hellscream", Cost = 8, Class = ClassType.Warrior},
                new Card { Id = 2, Name = "Pit Commander", Cost = 9, Class = ClassType.DemonHunter},
                new Card { Id = 2, Name = "Cenarius", Cost = 9, Class = ClassType.Druid},
                new Card { Id = 2, Name = "Gnomish Inventor", Cost = 4, Class = ClassType.Neutral},
                new Card { Id = 2, Name = "Catrina Muerte", Cost = 8, Class = ClassType.Priest},
                new Card { Id = 2, Name = "Edwin VanCleef", Cost = 3, Class = ClassType.Rogue},
                new Card { Id = 2, Name = "Al'Akir the Windlord", Cost = 8, Class = ClassType.Shaman},
                new Card { Id = 2, Name = "Lord Jaraxxus", Cost = 9, Class = ClassType.Warlock},
                new Card { Id = 2, Name = "Savannah Highmane", Cost = 6, Class = ClassType.Hunter},
            };
        }

        public Card GetById(int id)
        {
            return cards.SingleOrDefault(r => r.Id == id);
        }

        public Card Add(Card newCard)
        {
            cards.Add(newCard);
            newCard.Id = cards.Max(c => c.Id) + 1;
            return newCard;
        }

        public Card Update(Card updatedCard)
        {
            var card = cards.SingleOrDefault(c => c.Id == updatedCard.Id);
            if (card != null)
            {
                card.Name = updatedCard.Name;
                card.Cost = updatedCard.Cost;
                card.Class = updatedCard.Class;
            }
            return card;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Card> GetCardsByName(string name = null)
        {
            return from c in cards
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }

        public Card Delete(int id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if(card != null)
            {
                cards.Remove(card);
            }
            return null;
        }

        public int GetCountOfCards()
        {
            return cards.Count();
        }
    }
}
