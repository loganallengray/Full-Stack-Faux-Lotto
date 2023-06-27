using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using FS_Faux_Lotto.Repositories.Interfaces;

namespace FS_Faux_Lotto.Repositories
{
    public class HorseGameRepository : BaseRepository, IHorseGameRepository
    {
        public HorseGameRepository(IConfiguration configuration) : base(configuration) { }

        public List<HorseGame> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT hg.Id, hg.UserId, hg.HorseBetId,
                            hg.HorseWonId, hg.AmountBet,
	                        hg.NewAmount, hg.Win, hg.Featured, 
                            hg.[Date]
                        FROM HorseGames hg";

                    var bounties = new List<HorseGame>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bounties.Add(MakeHorseGame(reader));
                    }

                    reader.Close();

                    return bounties;
                }
            }
        }

        public HorseGame GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT hg.Id, hg.UserId, hg.HorseBetId,
                            hg.HorseWonId, hg.AmountBet,
	                        hg.NewAmount, hg.Win, hg.Featured, 
                            hg.[Date]
	                    FROM HorseGames hg
                        WHERE hg.Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    HorseGame horseGame = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        horseGame = MakeHorseGame(reader);
                    }

                    reader.Close();

                    return horseGame;
                }
            }
        }

        public void Add(HorseGame horseGame)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO HorseGames ( UserId, HorseBetId, HorseWonId, AmountBet, NewAmount, Win, Featured, [Date] )
                        OUTPUT INSERTED.ID
                        VALUES ( @UserId, @HorseBetId, @HorseWonId, @AmountBet, @NewAmount, @Win, @Featured, @Date )";
                    cmd.Parameters.AddWithValue("@UserId", horseGame.UserId);
                    cmd.Parameters.AddWithValue("@Choice", horseGame.HorseBetId);
                    cmd.Parameters.AddWithValue("@Outcome", horseGame.HorseWonId);
                    cmd.Parameters.AddWithValue("@AmountBet", horseGame.AmountBet);
                    cmd.Parameters.AddWithValue("@NewAmount", horseGame.NewAmount);
                    cmd.Parameters.AddWithValue("@Win", horseGame.Win);
                    cmd.Parameters.AddWithValue("@Featured", horseGame.Featured);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    horseGame.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM HorseGame
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public HorseGame MakeHorseGame(SqlDataReader reader)
        {
            HorseGame horseGame = new HorseGame()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                HorseBetId = reader.GetInt32(reader.GetOrdinal("HorseBetId")),
                HorseWonId = reader.GetInt32(reader.GetOrdinal("HorseWonId")),
                AmountBet = reader.GetInt32(reader.GetOrdinal("AmountBet")),
                NewAmount = reader.GetInt32(reader.GetOrdinal("NewAmount")),
                Win = reader.GetBoolean(reader.GetOrdinal("Win")),
                Featured = reader.GetBoolean(reader.GetOrdinal("Featured")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
            };

            return horseGame;
        }
    }
}