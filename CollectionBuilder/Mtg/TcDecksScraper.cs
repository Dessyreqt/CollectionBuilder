using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CollectionBuilder.Data;

namespace CollectionBuilder.Mtg
{
    public class TcDecksScraper : DeckScraperBase
    {
        public override void GetDecks(string url, IDeckWriter writer)
        {
            var response = GetResponse(url);

            if (String.IsNullOrWhiteSpace(response))
                return;

            var urlPattern = new Regex(@"id=\d+&iddeck=\d+");
            var matches = urlPattern.Matches(response);
            var deckUrls = (from Match match in matches select string.Format("https://tcdecks.net/download.php?ext=txt&{0}", match.Value)).ToList();

            foreach (var deckUrl in deckUrls.Distinct())
            {
                var deck = GetDeck(deckUrl);
                deck = CleanDeck(deck);

                var parser = new MtgoDeckParser();
                var parsedDeck = parser.ParseDeck(deck);
                if (parsedDeck.IsValid())
                {
                    writer.WriteDeck(parsedDeck);
                }

                Thread.Sleep(100);
            }
        }

        public override string GetDeck(string url)
        {
            var deckList = GetResponse(url);
            return deckList;
        }
    }
}
