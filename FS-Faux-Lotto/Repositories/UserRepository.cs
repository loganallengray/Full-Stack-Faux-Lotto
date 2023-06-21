using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories.Interfaces;
using FS_Faux_Lotto.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT u.Id, u.FireBaseId, u.UserName, 
                            u.FirstName, u.LastName, u.Email,
                            u.ImageLocation, u.Currency, u.Wins,
                            u.Losses
                        FROM [User] u
                            LEFT JOIN UserType ut ON u.UserTypeId = ut.Id
                        ORDER BY ut.Id, u.UserName;";

                    var users = new List<User>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(MakeUser(reader));
                    }

                    reader.Close();

                    return users;
                }
            }
        }

        public User GetByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT u.Id, u.FireBaseId, u.UserName, 
                            u.FirstName, u.LastName, u.Email,
                            u.ImageLocation, u.Currency, u.Wins,
                            u.Losses
                        FROM [User] u
                        WHERE u.Id = @id;";

                    DbUtils.AddParameter(cmd, "@id", id);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = MakeUser(reader);
                    }

                    reader.Close();

                    return user;
                }
            }
        }

        public User GetByFireBaseId(string fireBaseId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT u.Id, u.FireBaseId, u.UserName, 
                            u.FirstName, u.LastName, u.Email,
                            u.ImageLocation, u.Currency, u.Wins,
                            u.Losses
                        FROM [User] u
                            LEFT JOIN UserType ut ON u.UserTypeId = ut.id
                        WHERE FireBaseId = @FireBaseId AND u.Locked != 1";
                    DbUtils.AddParameter(cmd, "@FireBaseId", fireBaseId);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = MakeUser(reader);
                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [User] (FireBaseId, UserName, FirstName, LastName, Email, ImageLocation, Currency, Wins, Losses)
                        OUTPUT INSERTED.ID
                        VALUES (@FireBaseId, @UserName, @FirstName, @LastName, @Email, @ImageLocation, @Currency, @Wins, @Losses)";

                    DbUtils.AddParameter(cmd, "@FireBaseId", user.FireBaseId);
                    DbUtils.AddParameter(cmd, "@UserName", user.UserName);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@ImageLocation", user.ImageLocation);
                    DbUtils.AddParameter(cmd, "@Currency", 0);
                    DbUtils.AddParameter(cmd, "@Wins", 0);
                    DbUtils.AddParameter(cmd, "@Losses", 0);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE [User]
                            SET UserName = @UserName,
                                FirstName = @FirstName, 
                                LastName = @LastName,
                                Email = @Email,
                                ImageLocation = @ImageLocation
                         WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", DbUtils.ValueOrDBNull(user.LastName));
                    cmd.Parameters.AddWithValue("@Email", DbUtils.ValueOrDBNull(user.Email));
                    cmd.Parameters.AddWithValue("@ImageLocation", DbUtils.ValueOrDBNull(user.ImageLocation));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User MakeUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FireBaseId = reader.GetString(reader.GetOrdinal("FirebaseId")),
                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                ImageLocation = DbUtils.GetNullableString(reader, "ImageLocation"),
                Currency = reader.GetInt32(reader.GetOrdinal("Currency")),
                Wins = reader.GetInt32(reader.GetOrdinal("Wins")),
                Losses = reader.GetInt32(reader.GetOrdinal("Losses")),
            };
        }
    }
}