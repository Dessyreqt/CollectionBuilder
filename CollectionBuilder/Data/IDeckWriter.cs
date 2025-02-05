using CollectionBuilder.Common;

namespace CollectionBuilder.Data;

public interface IDeckWriter
{
    void WriteDeck(IDeck deck, bool addCards = false);
    Task<IDeck> GetDeckFromCollectionAsync();
    Task ClearCollectionAsync();
}
