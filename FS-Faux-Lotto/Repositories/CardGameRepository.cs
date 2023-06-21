using FS_Faux_Lotto.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using FS_Faux_Lotto.Repositories.Interfaces;

namespace FS_Faux_Lotto.Repositories
{
    public class CardGameRepository : BaseRepository, ICardGameRepository
    {
        public CardGameRepository(IConfiguration configuration) : base(configuration) { }

        public List<CardGame> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT cg.Id, cg.UserId, cg.AmountBet,
	                        cg.NewAmount, cg.Win, cg.Featured, cg.Date
                        FROM CardGame cg";

                    var bounties = new List<CardGame>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bounties.Add(MakeCardGame(reader));
                    }

                    reader.Close();

                    return bounties;
                }
            }
        }

        public CardGame GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT cg.Id, cg.UserId, cg.AmountBet,
	                        cg.NewAmount, cg.Win, cg.Featured, cg.Date
	                    FROM CardGame cg
                        WHERE cg.Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    CardGame cardGame = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cardGame = MakeCardGame(reader);
                    }

                    reader.Close();

                    return cardGame;
                }
            }
        }

        public void Add(CardGame cardGame)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO CardGame ( UserId, AmountBet, NewAmount, Win, Featured, Date )
                        OUTPUT INSERTED.ID
                        VALUES ( @UserId, @AmountBet, @NewAmount, @Choice, @Featured, @Date )";
                    cmd.Parameters.AddWithValue("@UserId", cardGame.UserId);
                    cmd.Parameters.AddWithValue("@AmountBet", cardGame.AmountBet);
                    cmd.Parameters.AddWithValue("@NewAmount", cardGame.NewAmount);
                    cmd.Parameters.AddWithValue("@Win", cardGame.Win);
                    cmd.Parameters.AddWithValue("@Featured", cardGame.Featured);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    cardGame.Id = (int)cmd.ExecuteScalar();
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
                        DELETE FROM CardGame
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public CardGame MakeCardGame(SqlDataReader reader)
        {
            CardGame cardGame = new CardGame()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                AmountBet = reader.GetInt32(reader.GetOrdinal("AmountBet")),
                NewAmount = reader.GetInt32(reader.GetOrdinal("NewAmount")),
                Win = reader.GetBoolean(reader.GetOrdinal("Win")),
                Featured = reader.GetBoolean(reader.GetOrdinal("Featured")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
            };

            return cardGame;
        }
    }
}