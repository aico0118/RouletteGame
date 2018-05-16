using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class CardConfigDetail
    {
        public int CardTypeId { get; set; }
        public int CardConfigId { get; set; }
        public decimal Position { get; set; }
    }
}
