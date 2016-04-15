using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using CollectionBuilder.Common;
using CollectionBuilder.Data;

namespace CollectionBuilder.Mtg
{
    public class MtgDeckSqlCeWriter : BaseSqlCeDeckDatabase, IDeckWriter
    {
        public void WriteDeck(IDeck deck)
        {
            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck.");
            }

            if (!(deck is MtgDeck))
            {
                throw new ArgumentException("Deck must be an MtgDeck.", "deck");
            }

            var filename = GetFileNameFromConnectionString();
            var initializeData = false;

            if (!File.Exists(filename))
            {
                var en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();
                initializeData = true;
            }

            using (var conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                if (initializeData)
                {
                    InitializeDatabase(conn);
                }

                InsertCards(conn, (MtgDeck)deck);
            }
        }

        public IDeck GetDeckFromCollection()
        {
            MtgDeck retVal = new MtgDeck();

            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling GetDeckFromCollection.");
            }

            var filename = GetFileNameFromConnectionString();
            
            if (!File.Exists(filename))
            {
                throw new ArgumentException("The database selected is invalid. Please check the filename.");
            }

            using (var conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                var cmdText = "select * from Collection order by Card";
                var cmd = new SqlCeCommand(cmdText, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var card = reader["Card"].ToString();
                    retVal.AddCard(card.Substring(0, card.IndexOf("#") - 1));
                }
            }

            return retVal;
        }

        private void InsertCards(SqlCeConnection conn, MtgDeck deck)
        {
            var deckList = deck.GetContents();

            foreach (var card in deckList)
            {
                if (!CollectionContainsCard(conn, card))
                {
                    var cmdText = "insert into Collection (Card) values (@card)";
                    var cmd = new SqlCeCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@card", card);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool CollectionContainsCard(SqlCeConnection conn, string card)
        {
            var cmdText = "select Card from Collection where Card = @card";
            var cmd = new SqlCeCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@card", card);
            var reader = cmd.ExecuteReader();
            
            return reader.Read();
        }


    }
}
