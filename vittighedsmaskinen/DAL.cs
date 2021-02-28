using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vittighedsmaskinen.Controllers
{
    public static class DAL
    {
        static List<string> yaMammaJokes = new List<string>()
        {
            "Din mor er så fed, at hver gang hun vender sig har hun fødselsdag",
            "Din mor er så dum, at hun prøvede at klatre Mountain Dew",
            "Din mor snorker så højt, at hun vækker de døde",
            "Din mor er så fedt, at selv Dora ikke kunne udforske hende",
            "Din mor er så fed, at hun kan kickstarte en rumfærge",
            "Din mor er så fed, at vis hun satte sig iPhone ville det blive til en iPad",
            "Din mor er så stor at hun kan udfylde den mur, som Trump vil bygge",
            "Din mor så fed at hvis hun ikke var blevet født, havde fedme ikke været et globalt sundhedsproblem.",
            "Din mor er mere åben end 7-Eleven.",
            "Hvorfor skød Hitler sig selv? Han så din mor!"
        };
        static List<string> dadJokes = new List<string>()
        {
            "Hvorfor skulle skyen i skole? – Fordi den skulle lære at regne",
            "Hvad er det mindst talte sprog i verden? – Tegnsprog",
            "Hvilken slags slik kan bilister ikke lide? – Lak-riser",
            "Hvad kalder man en fuld frø? – en sprit tusse",
            "Mine sko har lige forladt mig – De følte sig bundet",
            "Hvordan bliver man ekspert i tordenvejr? – Man tager et lynkursus",
            "Hvad hedder verdens fattigste konge? – Kong Kurs"
        };
        static List<string> dirtyJokes = new List<string>()
        {
            "Prøv at sige “på et knæ” på engelsk hurtigt efter hinanden",
            "– Eva: Adam elsker du mig? – Adam: nej – Eva (grædende): Hvorfor dyrker du så sex med mig? – Adam: Kan du se andre?",
            "Mor og far lå og elskede i sengen da lille Karl kom ind. Karl: “hvad laver i?” Far: “vi bager boller..” Karl: “så er det derfor mor har glasur i hele hovedet!”",
            "Hvad er forskellen på et fransk hotdog brød og en kvinde? Et fransk hotdog brød stønner ikke bare fordi den for en pølse i sig.",
            "Jeg håber ikke du er bange for klovne for jeg gør dig hvid i hovedet i nat",
            "Det var den 15 årige bror der lå i sengen med sin 14 årige søster og bollede. Da søsteren siger “ahhh hvor er du god, du er bedre end far” “Ja” svare broderen. “Det siger mor også”"
        };
        static List<string> enJokes = new List<string>()
        {
            "What did the dog say to his doctor? Be careful with the thermometer, last time it was a bit ruff.",
            "I'm looking for the man who shot my paw.",
            "What did the dog in the hard hat say? My specialty is roofing.",
            "My buddy said he threw a stick five miles and his dog managed to find it and brought it back. Seems a little far fetched.",
            "Today is ruff."
        };
        public static string Joke(string category)
        {
            Random r = new Random();
            category = category.ToLower();
            string joke;
            if (category == "dadjoke")
            {
                joke = dadJokes[r.Next(0, dadJokes.Count - 1)];
            }
            else if (category == "yamammajoke")
            {
                joke = yaMammaJokes[r.Next(0, yaMammaJokes.Count - 1)];
            }
            else if (category == "dirtyjoke")
            {
                joke = dirtyJokes[r.Next(0, dirtyJokes.Count - 1)];
            }
            else if (category == "enjokes")
            {
                joke = enJokes[r.Next(0, enJokes.Count - 1)];
            }
            else
            {
                joke = "not a valid category";
            }
            return joke;
        }
        public static  int ListLenght(string category)
        {
            if (category == "dadjoke")
            {
                return dadJokes.Count;
            }
            else if (category == "yaMammaJoke")
            {
                return yaMammaJokes.Count;
            }
            else if (category == "dirtyJoke")
            {
                return dirtyJokes.Count;
            }
            else
            {
                return 5000;
            }
        }
    }
}
