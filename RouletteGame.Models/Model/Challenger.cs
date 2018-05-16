using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class Challenger
    {
        public int ChallengerId { get; set; }
        public string Name { get; set; }
        public int? ImageId { get; set; }
    }
}
