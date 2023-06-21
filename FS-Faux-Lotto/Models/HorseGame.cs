using System;

namespace FS_Faux_Lotto.Models
{
    public class HorseGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HorseBetId { get; set; }
        public int HorseWonId { get; set; }
        public int AmountBet { get; set; }
        public int NewAmount { get; set; }
        public bool Win { get; set; }
        public bool Featured { get; set; }
        public DateTime Date { get; set; }
    }
}