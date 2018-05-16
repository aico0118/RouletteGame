using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class Game
    {
        public int GameId { get; set; }
        public int GameConfigId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Result { get; set; }
        public string RoomId { get; set; }
    }
}
