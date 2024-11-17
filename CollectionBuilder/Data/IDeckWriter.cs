using CollectionBuilder.Common;

namespace CollectionBuilder.Data;

public interface IDeckWriter
{
    void WriteDeck(IDeck deck);
    Task<IDeck> GetDeckFromCollectionAsync();
    Task ClearCollectionAsync();
}
