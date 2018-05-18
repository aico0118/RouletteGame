using System;
using System.Collections.Generic;

namespace RouletteGame.Models
{
    public partial class Coin
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public DateTime CreDate { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
