using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories.Interfaces
{
    public interface IHorseGameRepository
    {
        void Add(HorseGame horseGame);
        void Delete(int id);
        List<HorseGame> GetAll();
        HorseGame GetById(int id);
        HorseGame MakeHorseGame(SqlDataReader reader);
    }
}