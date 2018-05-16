using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class CardConfig
    {
        public int CardConfigId { get; set; }
        public DateTime EffDateFrom { get; set; }
        public DateTime? EffDateTo { get; set; }
    }
}
