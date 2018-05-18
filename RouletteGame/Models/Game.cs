using System;
using System.Collections.Generic;

namespace RouletteGame.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coin { get; set; }
        public int RoomId { get; set; }
        public DateTime CreDate { get; set; }
        public DateTime? UpdDate { get; set; }

        public Room Room { get; set; }
    }
}
