using Microsoft.AspNetCore.Authentication;

namespace FS_Faux_Lotto.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string House { get; set; }
        public string Rank { get; set; }
        public string Name { get { return $"{Rank} of {House}"; } }
        public int Value
        {
            get
            {
                int result = 0;

                switch (Rank)
                {
                    case "Two":
                        result = 2;
                        break;
                    case "Three":
                        result = 3;
                        break;
                    case "Four":
                        result = 4;
                        break;
                    case "Five":
                        result = 5;
                        break;
                    case "Six":
                        result = 6;
                        break;
                    case "Seven":
                        result = 7;
                        break;
                    case "Eight":
                        result = 8;
                        break;
                    case "Nine":
                        result = 9;
                        break;
                    case "Jack":
                    case "Queen":
                    case "King":
                        result = 10;
                        break;
                    case "Ace":
                        result = 11;
                        break;
                }

                return result;
            }
        }
        public bool Ace { get { return Rank == "Ace"; } }
    }
}