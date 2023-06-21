using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories.Interfaces
{
    public interface ICoinGameRepository
    {
        void Add(CoinGame coinGame);
        void Delete(int id);
        List<CoinGame> GetAll();
        CoinGame GetById(int id);
        CoinGame MakeCoinGame(SqlDataReader reader);
    }
}