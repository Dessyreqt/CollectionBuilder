using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionBuilder.Common;

namespace CollectionBuilder.Mtg
{
    public class MtgDeck : IDeck
    {
        private List<string> DeckContents { get; set; }
        private List<string> Errors { get; set; }

        public MtgDeck()
        {
            DeckContents = new List<string>();
            Errors = new List<string>();
        }

        public bool IsValid()
        {
            Errors.Clear();

            if (DeckContents.Count < MtgDeckRules.MinDeckSize)
            {
                Errors.Add(string.Format("Deck must have at least {0} cards.", MtgDeckRules.MinDeckSize));
            }

            foreach (var card in DeckContents)
            {
                if (MtgDeckRules.IgnoreMaxCards.Contains(card))
                {
                    continue;
                }

                if (DeckContents.Count(x => x == card) > MtgDeckRules.MaxPerCard)
                {
                    Errors.Add(string.Format("Deck and sideboard cannot contain more than {0} cards named \"{1}\"", MtgDeckRules.MaxPerCard, card));
                }
            }

            return Errors.Count == 0;
        }

        public void AddCard(string card)
        {
            DeckContents.Add(card);
        }

        public List<string> GetContents()
        {
            DeckContents.Sort();

            var retVal = new List<string>();

            for (int i = 0; i < DeckContents.Count; i++)
            {
                var card = DeckContents[i];
                retVal.Add(string.Format("{0} #{1}", card, DeckContents.GetRange(0, i).Count(x => x == card) + 1));
            }

            return retVal;
        }

        public string GetFormattedList()
        {
            DeckContents.Sort();

            var retVal = new StringBuilder();

            WriteContents(retVal, DeckContents);

            return retVal.ToString();
        }

        private void WriteContents(StringBuilder retVal, List<string> contents)
        {
            var count = 1;
            var cardDatabase = new CardDatabase();
            var outputLists = new Dictionary<string, List<string>>();

            for (int i = 0; i < contents.Count(); i++)
            {
                if (i + 1 < contents.Count)
                {
                    if (contents[i] == contents[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        AddCardToOutputList(outputLists, cardDatabase, contents[i], count);
                        count = 1;
                    }
                }
                else
                {
                    AddCardToOutputList(outputLists, cardDatabase, contents[i], count);
                }
            }

            retVal.Append(OutputLists(outputLists));
        }

        private string OutputLists(Dictionary<string, List<string>> outputLists)
        {
            var retVal = new StringBuilder();

            AppendList(outputLists, retVal, "White");
            AppendList(outputLists, retVal, "Blue");
            AppendList(outputLists, retVal, "Black");
            AppendList(outputLists, retVal, "Red");
            AppendList(outputLists, retVal, "Green");
            AppendList(outputLists, retVal, "Colorless");
            AppendList(outputLists, retVal, "Multicolor");
            AppendList(outputLists, retVal, "Land");

            return retVal.ToString();
        }

        private static void AppendList(Dictionary<string, List<string>> outputLists, StringBuilder retVal, string group)
        {
            if (outputLists.ContainsKey(group))
            {
                retVal.AppendLine(string.Format("{0}:", group));

                foreach (var card in outputLists[group])
                {
                    retVal.AppendLine(card);
                }
            }
        }

        private void AddCardToOutputList(Dictionary<string, List<string>> outputLists, CardDatabase cardDatabase, string card, int count)
        {
            card = card.Trim();

            if (cardDatabase.Cards[card] == null)
            {
                var fixedCard = FixCardName(card);
                if (cardDatabase.Cards.data[fixedCard] == null)
                {
                    throw new Exception("Could not find card! Please check name!");
                }
                else
                {
                    string group = GetCardGroup(cardDatabase.Cards.data[fixedCard], card);
                    AddCardToGroup(outputLists, group, card, count);
                }
            }
            else
            {
                string group = GetCardGroup(cardDatabase.Cards.data[card], card);
                AddCardToGroup(outputLists, group, card, count);
            }
        }

        private void AddCardToGroup(Dictionary<string, List<string>> outputLists, string @group, string card, int count)
        {
            if (!outputLists.ContainsKey(group))
            {
                outputLists[group] = new List<string>();
            }

            outputLists[group].Add(string.Format("{0}\t{1}", count, card, MtgDeckRules.ReservedList.Contains(card) ? " ®" : ""));
        }

        private string GetCardGroup(dynamic card, string cardName)
        {
            foreach (string type in card[0].types)
            {
                if (type == "Land")
                {
                    return "Land";
                }
            }

            int actualColors = 0;

            if (card[0].manaCost != null)
            {
                if (card[0].manaCost.ToString().IndexOf("W") > -1)
                {
                    actualColors++;
                }
                if (card[0].manaCost.ToString().IndexOf("U") > -1)
                {
                    actualColors++;
                }
                if (card[0].manaCost.ToString().IndexOf("B") > -1)
                {
                    actualColors++;
                }
                if (card[0].manaCost.ToString().IndexOf("R") > -1)
                {
                    actualColors++;
                }
                if (card[0].manaCost.ToString().IndexOf("G") > -1)
                {
                    actualColors++;
                }
            }

            if (actualColors == 0)
            {
                return "Colorless";
            }

            if (actualColors > 1 || (card[0].colors != null && card[0].colors.Count > 1) || (cardName.Contains(" // ") && card[0].colorIdentity.Count > 1))
            {
                return "Multicolor";
            }

            if (actualColors == 1)
            {
                if (card[0].manaCost.ToString().IndexOf("W") > -1)
                {
                    return "White";
                }
                if (card[0].manaCost.ToString().IndexOf("U") > -1)
                {
                    return "Blue";
                }
                if (card[0].manaCost.ToString().IndexOf("B") > -1)
                {
                    return "Black";
                }
                if (card[0].manaCost.ToString().IndexOf("R") > -1)
                {
                    return "Red";
                }
                if (card[0].manaCost.ToString().IndexOf("G") > -1)
                {
                    return "Green";
                }
            }

            return "Colorless";
        }

        private string FixCardName(string card)
        {
            //card = card.Replace("Ae", "Æ");

            var replacements = new Dictionary<string, string>()
            {
                { "Bonecrusher Giant", "Bonecrusher Giant // Stomp" },
                { "Brazen Borrower", "Brazen Borrower // Petty Theft" },
                { "Jace, Vryn's Prodigy", "Jace, Vryn's Prodigy // Jace, Telepath Unbound" },
                { "Malevolent Hermit", "Malevolent Hermit // Benevolent Geist" },
                { "Outland Liberator", "Outland Liberator // Frenzied Trapbreaker" },
                { "Sea Gate Restoration", "Sea Gate Restoration // Sea Gate, Reborn" },
                { "Shatterskull Smashing", "Shatterskull Smashing // Shatterskull, the Hammer Pass" },
                { "Silundi Vision", "Silundi Vision // Silundi Isle" },
                { "Thing in the Ice", "Thing in the Ice // Awoken Horror" },
                { "Valakut Awakening", "Valakut Awakening // Valakut Stoneforge" },
            };

            if (replacements.ContainsKey(card))
            {
                card = replacements[card];
            }
            //if (card.Contains(" // "))
            //{
            //    card = card.Substring(0, card.IndexOf(" // "));
            //}

            return card;
        }
    }
}
