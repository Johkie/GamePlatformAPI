using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebAPI.Models
{
    public class HighscoreItem
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int Score { get; set; }
    }
}
