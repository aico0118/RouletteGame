using System;
using System.Collections.Generic;

namespace RouletteGame.Models
{
    public partial class Room
    {
        public Room()
        {
            Game = new HashSet<Game>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LimitUsers { get; set; }
        public string Creator { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreDate { get; set; }
        public DateTime? UpdDate { get; set; }

        public ICollection<Game> Game { get; set; }
        public ICollection<User> User { get; set; }
    }
}
