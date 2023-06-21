using System;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Models
{
    public class CardGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AmountBet { get; set; }
        public int NewAmount { get; set; }
        public bool Win { get; set; }
        public bool Featured { get; set; }
        public DateTime Date { get; set; }
        public List<Card> DealerDeck { get; set; }
        public List<Card> PlayerDeck { get; set; }
    }
}