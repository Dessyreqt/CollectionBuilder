using System.Collections.Generic;

namespace CollectionBuilder.Common
{
    public interface IDeck
    {
        bool IsValid();
        void AddCard(string card);
        List<string> GetContents();
        string GetFormattedList();
    }
}
