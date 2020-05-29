using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hearthstone.Core;
using Hearthstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hearthstone.Pages.Cards
{
    public class DetailModel : PageModel
    {

        public Card Card { get; set; }
        private readonly ICardData cardData;

        [TempData]
        public string Message { get; set; }

        public DetailModel(ICardData cardData)
        {
            this.cardData = cardData;
        }

        public IActionResult OnGet(int cardId)
        {
            Card = cardData.GetById(cardId);
            if (Card == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}