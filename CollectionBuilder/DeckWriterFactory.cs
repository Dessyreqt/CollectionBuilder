using CollectionBuilder.Data;
using CollectionBuilder.Mtg;

namespace CollectionBuilder;

public class DeckWriterFactory
{
    private static readonly Func<string, IDeckWriter>[] outputObjects =
    {
        new Func<string, IDeckWriter>(
            output =>
            {
                var retVal = new MtgDeckSqliteWriter { ConnectionString = string.Format("DataSource=\"{0}\";", output) };
                return retVal;
            })
    };

    public static IDeckWriter GetDeckWriter(DeckWriterGameType gameType, string location)
    {
        if (string.IsNullOrWhiteSpace(location)) { throw new ArgumentException("Location cannot be blank.", "location"); }

        return outputObjects[(int)gameType](location);
    }
}
