using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hearthstone.Core;
using Hearthstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hearthstone.Pages.Cards
{
    public class EditModel : PageModel
    {

        private readonly ICardData cardData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Card Card { get; set; }

        public IEnumerable<SelectListItem> Classes { get; set; }

        public EditModel(ICardData cardData, IHtmlHelper htmlHelper)
        {
            this.cardData = cardData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? cardId)
        {
            Classes = htmlHelper.GetEnumSelectList<ClassType>();
            if (cardId.HasValue)
            {
                Card = cardData.GetById(cardId.Value);
            }
            else
            {
                Card = new Card();
            }
            if (Card == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Classes = htmlHelper.GetEnumSelectList<ClassType>();
                return Page(); 
            }
            if(Card.Id > 0)
            {
                cardData.Update(Card);
            }
            else
            {
                cardData.Add(Card);
            }
            cardData.Commit();
            TempData["Message"] = "Card Saved!";
            return RedirectToPage("./Detail", new { cardId = Card.Id });
        }
    }
}