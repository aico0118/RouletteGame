using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class CardType
    {
        public int CardTypeId { get; set; }
        public string Color { get; set; }
        public decimal Reward { get; set; }
    }
}
