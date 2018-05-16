using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class GameBetDetail
    {
        public int ChallengerId { get; set; }
        public int CardTypeId { get; set; }
        public int GameId { get; set; }
        public decimal? Quantity { get; set; }
    }
}
