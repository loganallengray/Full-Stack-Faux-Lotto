using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories
{
    public interface ICardGameRepository
    {
        void Add(CardGame cardGame);
        void Delete(int id);
        List<CardGame> GetAll();
        CardGame GetById(int id);
        CardGame MakeCardGame(SqlDataReader reader);
    }
}