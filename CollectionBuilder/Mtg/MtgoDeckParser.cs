using CollectionBuilder.Common;

namespace CollectionBuilder.Mtg;

public class MtgoDeckParser : IDeckParser
{
    public IDeck ParseDeck(string deck)
    {
        var retVal = new MtgDeck();

        var deckLines = deck.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in deckLines)
        {
            var workingLine = line;

            if (workingLine.ToLower().Contains("sideboard")) { continue; }

            if (workingLine.StartsWith("//")) { continue; }

            if (workingLine.Contains('\t')) { workingLine = workingLine.Replace('\t', ' '); }

            if (!workingLine.Contains(' ')) { continue; }

            var countString = workingLine.Split(' ')[0];
            int countNum;

            if (!int.TryParse(countString, out countNum)) { continue; }

            var cardName = workingLine.Substring(workingLine.IndexOf(' ')).Trim();

            for (var i = 0; i < countNum; i++)
                retVal.AddCard(cardName);
        }

        return retVal;
    }
}
