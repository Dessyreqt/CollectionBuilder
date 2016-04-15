using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionBuilder.Common;

namespace CollectionBuilder.Data
{
    public interface IDeckWriter
    {
        void WriteDeck(IDeck deck);
        IDeck GetDeckFromCollection();
    }
}
