using System;
using System.ComponentModel.DataAnnotations;

namespace Hearthstone.Core
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required, Range(0, 10)]
        public int Cost { get; set; }

        public ClassType Class { get; set; }
    }
}