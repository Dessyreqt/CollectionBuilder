using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CollectionBuilder.Mtg
{
    public class CardDatabase
    {
        public dynamic Cards { get; set; }

        public CardDatabase()
        {
            StreamReader reader = new StreamReader("cards.json");
            var cardText = reader.ReadToEnd();
            Cards = JsonConvert.DeserializeObject<dynamic>(cardText);
        }
    }
}
