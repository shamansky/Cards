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
    public class DeleteModel : PageModel
    {
        private readonly ICardData cardData;

        public Card Card { get; set; }

        public DeleteModel(ICardData cardData)
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

        public IActionResult OnPost(int cardId)
        {
            var card = cardData.Delete(cardId);
            cardData.Commit();

            if(card == null)
            {
              return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{card.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}