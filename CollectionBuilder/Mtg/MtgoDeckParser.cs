using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionBuilder.Common;

namespace CollectionBuilder.Mtg
{
    public class MtgoDeckParser : IDeckParser
    {
        public IDeck ParseDeck(string deck)
        {
            var retVal = new MtgDeck();

            var deckLines = deck.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in deckLines)
            {
                if (line.ToLower().Contains("sideboard"))
                {
                    continue;
                }
                if (line.StartsWith("//"))
                {
                    continue;
                }
                if (!line.Contains(' '))
                {
                    continue;
                }

                var countString = line.Split(' ')[0];
                int countNum;
                if (!int.TryParse(countString, out countNum))
                {
                    continue;
                }

                var cardName = line.Substring(line.IndexOf(' ')).Trim();
                for (int i = 0; i < countNum; i++)
                {
                    retVal.AddCard(cardName);
                }
            }

            return retVal;
        }
    }
}
