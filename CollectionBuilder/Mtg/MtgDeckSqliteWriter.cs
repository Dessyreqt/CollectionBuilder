using CollectionBuilder.Common;
using CollectionBuilder.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CollectionBuilder.Mtg;

public class MtgDeckSqliteWriter : BaseSqliteDeckDatabase, IDeckWriter
{
    public void WriteDeck(IDeck deck)
    {
        if (ConnectionString == null) { throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck."); }

        if (!(deck is MtgDeck)) { throw new ArgumentException("Deck must be an MtgDeck.", "deck"); }

        var filename = GetFileNameFromConnectionString();
        var initializeData = !File.Exists(filename);

        using (var conn = new SqliteConnection(ConnectionString))
        {
            conn.Open();

            if (initializeData) { InitializeDatabase(conn); }

            InsertCards(conn, (MtgDeck)deck);
        }
    }

    public IDeck GetDeckFromCollection()
    {
        var retVal = new MtgDeck();

        if (ConnectionString == null) { throw new InvalidOperationException("The ConnectionString property must be set before calling GetDeckFromCollection."); }

        var filename = GetFileNameFromConnectionString();

        if (!File.Exists(filename)) { throw new ArgumentException("The database selected is invalid. Please check the filename."); }

        using (var conn = new SqliteConnection(ConnectionString))
        {
            conn.Open();

            var cmdText = "select * from Collection order by Card";
            var cmd = new SqliteCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var card = reader["Card"].ToString();
                retVal.AddCard(card.Substring(0, card.IndexOf("#") - 1));
            }
        }

        return retVal;
    }

    public async Task ClearCollectionAsync()
    {
        await using var connection = new SqliteConnection(ConnectionString);
        var query = "delete from Collection";
        await connection.ExecuteAsync(query);
    }

    private void InsertCards(SqliteConnection conn, MtgDeck deck)
    {
        var deckList = deck.GetContents();

        foreach (var card in deckList)
            if (!CollectionContainsCard(conn, card))
            {
                var cmdText = "insert into Collection (Card) values (@card)";
                var cmd = new SqliteCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@card", card);
                cmd.ExecuteNonQuery();
            }
    }

    private bool CollectionContainsCard(SqliteConnection conn, string card)
    {
        var cmdText = "select Card from Collection where Card = @card";
        var cmd = new SqliteCommand(cmdText, conn);
        cmd.Parameters.AddWithValue("@card", card);
        var reader = cmd.ExecuteReader();

        return reader.Read();
    }
}
