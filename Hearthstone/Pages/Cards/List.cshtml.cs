using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hearthstone.Core;
using Hearthstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Hearthstone.Pages.Cards
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        private readonly IConfiguration config;
        private readonly ICardData cardData;
        public IEnumerable<Card> Cards { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, ICardData cardData)
        {
            this.config = config;
            this.cardData = cardData;
        }

        public void OnGet()
        {

            Message = config["Message"];
            Cards = cardData.GetCardsByName(SearchTerm);
        }
    }
}