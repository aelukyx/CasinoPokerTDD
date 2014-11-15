using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.IO;

namespace CasinoPoker
{
    public class PokerGame
    {
        public string GetGanadorPoker(string mano1)
        {
            string result = "Carta Alta";

            var cartas = new Dictionary<string, int>();
            cartas.Add("2", 2);
            cartas.Add("3", 3);
            cartas.Add("4", 4);
            cartas.Add("5", 5);
            cartas.Add("6", 6);
            cartas.Add("7", 7);
            cartas.Add("8", 8);
            cartas.Add("9", 9);
            cartas.Add("I", 10);
            cartas.Add("J", 11);
            cartas.Add("Q", 12);
            cartas.Add("K", 13);
            cartas.Add("A", 14);

            List<string> ListCartasMano1 = new List<string>();
            List<int> ListCartasNumericoTemporal = new List<int>();

            Regex delimitador = new Regex("-");
            string[] subCarta = delimitador.Split(mano1);
            foreach (string Cartita in subCarta)
            {
                ListCartasMano1.Add(Cartita);
                ListCartasNumericoTemporal.Add(cartas[Cartita.Substring(0,1)]);
            }

            //******************** Lista String ************************
            IEnumerable<string> query = from word in ListCartasMano1
                                        orderby word.Substring(0, 1) descending //Menor a Mayor
                                        select word;

            foreach (string str in query)
            {
                ListCartasMano1.Insert(0, str);
            }
            //**********************************************************

            ListCartasNumericoTemporal.Sort();

            //********************************************************

            result = UnPar(result, cartas, ListCartasMano1);

            result = DosPares(result, cartas, ListCartasMano1);

            result = Trio(result, cartas, ListCartasMano1);

            result = Escalera(result, ListCartasNumericoTemporal);

            result = Color(result, ListCartasMano1, ListCartasNumericoTemporal);

            result = Full(result, cartas, ListCartasMano1);

            result = Poker(result, cartas, ListCartasMano1);

            result = EscaleraColor(result, ListCartasMano1, ListCartasNumericoTemporal);

            result = EscaleraReal(result, ListCartasMano1, ListCartasNumericoTemporal);

            return result;

        }

        private static string EscaleraReal(string result, List<string> ListCartasMano1, List<int> ListCartasNumericoTemporal)
        {
            if (ListCartasNumericoTemporal[0] == 10 && ListCartasNumericoTemporal[1] == 11 &&
                ListCartasNumericoTemporal[2] == 12 && ListCartasNumericoTemporal[3] == 13 &&
                ListCartasNumericoTemporal[4] == 14 &&

                ListCartasMano1[0].Substring(1, 2) == ListCartasMano1[1].Substring(1, 2) &&
                ListCartasMano1[1].Substring(1, 2) == ListCartasMano1[2].Substring(1, 2) &&
                ListCartasMano1[2].Substring(1, 2) == ListCartasMano1[3].Substring(1, 2) &&
                ListCartasMano1[3].Substring(1, 2) == ListCartasMano1[4].Substring(1, 2))
            {
                result = "Escalera Real";
            }
            return result;
        }

        private static string EscaleraColor(string result, List<string> ListCartasMano1, List<int> ListCartasNumericoTemporal)
        {
            if (ListCartasNumericoTemporal[0] + 1 == ListCartasNumericoTemporal[1] &&
                ListCartasNumericoTemporal[1] + 1 == ListCartasNumericoTemporal[2] &&
                ListCartasNumericoTemporal[2] + 1 == ListCartasNumericoTemporal[3] &&
                ListCartasNumericoTemporal[3] + 1 == ListCartasNumericoTemporal[4] &&

                ListCartasMano1[0].Substring(1, 2) == ListCartasMano1[1].Substring(1, 2) &&
                ListCartasMano1[1].Substring(1, 2) == ListCartasMano1[2].Substring(1, 2) &&
                ListCartasMano1[2].Substring(1, 2) == ListCartasMano1[3].Substring(1, 2) &&
                ListCartasMano1[3].Substring(1, 2) == ListCartasMano1[4].Substring(1, 2))
            {
                result = "Escalera de Color";
            }

            //Escalera de Color Menor A-2-3-4-5
            if (ListCartasNumericoTemporal[0] == 2 && ListCartasNumericoTemporal[1] == 3 &&
                ListCartasNumericoTemporal[2] == 4 && ListCartasNumericoTemporal[3] == 5 &&
                ListCartasNumericoTemporal[4] == 14 &&

                ListCartasMano1[0].Substring(1, 2) == ListCartasMano1[1].Substring(1, 2) &&
                ListCartasMano1[1].Substring(1, 2) == ListCartasMano1[2].Substring(1, 2) &&
                ListCartasMano1[2].Substring(1, 2) == ListCartasMano1[3].Substring(1, 2) &&
                ListCartasMano1[3].Substring(1, 2) == ListCartasMano1[4].Substring(1, 2))
            {
                result = "Escalera de Color";
            }
            return result;
        }

        private static string Poker(string result, Dictionary<string, int> cartas, List<string> ListCartasMano1)
        {
            if (cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)] &&
                cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)] &&
                cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)])
            {
                result = "Poker";
            }

            if (cartas[ListCartasMano1[4].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)] &&
                cartas[ListCartasMano1[4].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)] &&
                cartas[ListCartasMano1[4].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)])
            {
                result = "Poker";
            }
            return result;
        }

        private static string Full(string result, Dictionary<string, int> cartas, List<string> ListCartasMano1)
        {
            if (cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)] &&
                cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)] &&
                cartas[ListCartasMano1[3].Substring(0, 1)] == cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Full";
            }

            if (cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)] &&
                 cartas[ListCartasMano1[2].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)] &&
                 cartas[ListCartasMano1[2].Substring(0, 1)] == cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Full";
            }
            return result;
        }

        private static string Color(string result, List<string> ListCartasMano1, List<int> ListCartasNumericoTemporal)
        {
            if (ListCartasMano1[0].Substring(1, 2) == ListCartasMano1[1].Substring(1, 2) &&
                ListCartasMano1[1].Substring(1, 2) == ListCartasMano1[2].Substring(1, 2) &&
                ListCartasMano1[2].Substring(1, 2) == ListCartasMano1[3].Substring(1, 2) &&
                ListCartasMano1[3].Substring(1, 2) == ListCartasMano1[4].Substring(1, 2))
            {
                result = "Color";
            }

            return result;
        }

        private static string Escalera(string result, List<int> ListCartasNumericoTemporal)
        {
            if (ListCartasNumericoTemporal[0] + 1 == ListCartasNumericoTemporal[1] &&
                ListCartasNumericoTemporal[1] + 1 == ListCartasNumericoTemporal[2] &&
                ListCartasNumericoTemporal[2] + 1 == ListCartasNumericoTemporal[3] &&
                ListCartasNumericoTemporal[3] + 1 == ListCartasNumericoTemporal[4])
            {
                result = "Escalera";
            }

            //Escalera A-2-3-4-5
            if (ListCartasNumericoTemporal[0] == 2 && ListCartasNumericoTemporal[1] == 3 &&
                ListCartasNumericoTemporal[2] == 4 && ListCartasNumericoTemporal[3] == 5 &&
                ListCartasNumericoTemporal[4] == 14)
            {
                result = "Escalera";
            }
            return result;
        }

        private static string Trio(string result, Dictionary<string, int> cartas, List<string> ListCartasMano1)
        {
            if ((cartas[ListCartasMano1[2].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[3].Substring(0, 1)] == cartas[ListCartasMano1[4].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[1].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[1].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)])
            {
                result = "Trio";
            }


            if ((cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[1].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[3].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)]
                    && cartas[ListCartasMano1[3].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)])
            {
                result = "Trio";
            }

            if ((cartas[ListCartasMano1[1].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[2].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)])
            {
                result = "Trio";
            }
            return result;
        }

        private static string DosPares(string result, Dictionary<string, int> cartas, List<string> ListCartasMano1)
        {
            if ((cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[3].Substring(0, 1)] == cartas[ListCartasMano1[4].Substring(0, 1)]

                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)])
            {
                result = "Dos Pares";
            }

            if ((cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[2].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)]

                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)]
                    && cartas[ListCartasMano1[2].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Dos Pares";
            }

            if ((cartas[ListCartasMano1[1].Substring(0, 1)] == cartas[ListCartasMano1[2].Substring(0, 1)]) &&
                 cartas[ListCartasMano1[3].Substring(0, 1)] == cartas[ListCartasMano1[4].Substring(0, 1)]

                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[1].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Dos Pares";
            }
            return result;
        }

        private static string UnPar(string result, Dictionary<string, int> cartas, List<string> ListCartasMano1)
        {
            if ((cartas[ListCartasMano1[0].Substring(0, 1)] == cartas[ListCartasMano1[1].Substring(0, 1)])
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[3].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)]

                    && cartas[ListCartasMano1[2].Substring(0, 1)] != cartas[ListCartasMano1[3].Substring(0, 1)]
                    && cartas[ListCartasMano1[2].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)]
                    && cartas[ListCartasMano1[3].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Un Par";
            }

            if ((cartas[ListCartasMano1[4].Substring(0, 1)] == cartas[ListCartasMano1[3].Substring(0, 1)])
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[0].Substring(0, 1)]
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[1].Substring(0, 1)]
                    && cartas[ListCartasMano1[4].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]


                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[1].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[2].Substring(0, 1)]
                    && cartas[ListCartasMano1[0].Substring(0, 1)] != cartas[ListCartasMano1[4].Substring(0, 1)])
            {
                result = "Un Par";
            }
            return result;
        }
    }
}



