using System;
using System.Collections.Generic;
using Hearthstone.Core;
using System.Linq;

namespace Hearthstone.Data
{
    public interface ICardData
    {
        IEnumerable<Card> GetCardsByName(string name);
        Card GetById(int id);
        Card Update(Card updatedCard);
        Card Add(Card newCard);
        Card Delete(int id);
        int GetCountOfCards();
        int Commit();
    }
}