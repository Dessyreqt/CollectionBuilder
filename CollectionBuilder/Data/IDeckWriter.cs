using CollectionBuilder.Common;

namespace CollectionBuilder.Data;

public interface IDeckWriter
{
    void WriteDeck(IDeck deck);
    IDeck GetDeckFromCollection();
    Task ClearCollectionAsync();
}
