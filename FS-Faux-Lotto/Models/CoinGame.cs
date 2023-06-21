using System;

namespace FS_Faux_Lotto.Models
{
    public class CoinGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AmountBet { get; set; }
        public int NewAmount { get; set; }
        public string Choice { get; set; }
        public string Outcome { get; set; }
        public bool Win { get; set; }
        public bool Featured { get; set; }
        public DateTime Date { get; set; }
    }
}