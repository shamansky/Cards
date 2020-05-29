using System;
using Hearthstone.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hearthstone.ViewComponents
{
    public class CardCountViewComponent : ViewComponent
    {
        private readonly ICardData cardData;

        public CardCountViewComponent(ICardData cardData)
        {
            this.cardData = cardData;
        }

        public IViewComponentResult Invoke()
        {
            var count = cardData.GetCountOfCards();
            return View(count);
        }
    }
}
