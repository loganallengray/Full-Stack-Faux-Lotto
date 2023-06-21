using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace FS_Faux_Lotto.Repositories
{
    public class CoinGameRepository : BaseRepository
    {
        public CoinGameRepository(IConfiguration configuration) : base(configuration) { }

        public List<CoinGame> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT cg.Id, cg.UserId, cg.AmountBet,
	                        cg.NewAmount, cg.Choice, cg.Outcome,
                            cg.Win, cg.Featured, cg.Date
                        FROM CoinGame cg";

                    var bounties = new List<CoinGame>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bounties.Add(MakeCoinGame(reader));
                    }

                    reader.Close();

                    return bounties;
                }
            }
        }

        public CoinGame GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT cg.Id, cg.UserId, cg.AmountBet,
	                        cg.NewAmount, cg.Choice, cg.Outcome,
                            cg.Win, cg.Featured, cg.Date
	                    FROM CoinGame cg
                        WHERE cg.Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    CoinGame coinGame = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        coinGame = MakeCoinGame(reader);
                    }

                    reader.Close();

                    return coinGame;
                }
            }
        }

        public void Add(CoinGame coinGame)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO CoinGame ( UserId, AmountBet, NewAmount, Choice, Outcome, Win, Featured, Date )
                        OUTPUT INSERTED.ID
                        VALUES ( @UserId, @AmountBet, @NewAmount, @Choice, @Outcome, @Win, @Featured, @Date )";
                    cmd.Parameters.AddWithValue("@UserId", coinGame.UserId);
                    cmd.Parameters.AddWithValue("@AmountBet", coinGame.AmountBet);
                    cmd.Parameters.AddWithValue("@NewAmount", coinGame.NewAmount);
                    cmd.Parameters.AddWithValue("@Choice", coinGame.Choice);
                    cmd.Parameters.AddWithValue("@Outcome", coinGame.Outcome);
                    cmd.Parameters.AddWithValue("@Win", coinGame.Win);
                    cmd.Parameters.AddWithValue("@Featured", coinGame.Featured);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    coinGame.Id = (int)cmd.ExecuteScalar();
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
                        DELETE FROM CoinGame
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public CoinGame MakeCoinGame(SqlDataReader reader)
        {
            CoinGame coinGame = new CoinGame()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                AmountBet = reader.GetInt32(reader.GetOrdinal("AmountBet")),
                NewAmount = reader.GetInt32(reader.GetOrdinal("NewAmount")),
                Choice = reader.GetString(reader.GetOrdinal("Choice")),
                Outcome = reader.GetString(reader.GetOrdinal("Outcome")),
                Win = reader.GetBoolean(reader.GetOrdinal("Win")),
                Featured = reader.GetBoolean(reader.GetOrdinal("Featured")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
            };

            return coinGame;
        }
    }
}