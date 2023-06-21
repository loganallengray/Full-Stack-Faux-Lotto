using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAll();
        User GetByFireBaseId(string fireBaseId);
        User GetByUserId(int id);
        User MakeUser(SqlDataReader reader);
        void Update(User user);
    }
}