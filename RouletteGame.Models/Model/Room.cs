using System;
using System.Collections.Generic;

namespace RouletteGame.Models.Model
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int MaxAllowPerson { get; set; }
    }
}
