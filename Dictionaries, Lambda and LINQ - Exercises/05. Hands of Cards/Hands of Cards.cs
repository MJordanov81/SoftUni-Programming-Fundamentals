using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_of_Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var playerHands = new Dictionary<string, string[]>();
            var inputHand = Console.ReadLine();

            var indexOfColumn = inputHand.IndexOf(':');

            var name = string.Empty;

            if (indexOfColumn == -1)
            {
                return;
            }

            name = inputHand.Substring(0, indexOfColumn);

            inputHand = inputHand.Substring(indexOfColumn, inputHand.Length - indexOfColumn); 
                
            var currentHand = inputHand.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (name != "JOKER")
            {
                currentHand = currentHand.Skip(1).ToArray();
                if (!playerHands.ContainsKey(name))
                {
                    playerHands[name] = currentHand.ToArray();
                }

                playerHands[name] = playerHands[name].Concat(currentHand).ToArray();

                inputHand = Console.ReadLine();

                indexOfColumn = inputHand.IndexOf(':');

                if (indexOfColumn == -1)
                {
                    name = "JOKER";
                }

                else
                {
                    name = inputHand.Substring(0, indexOfColumn);

                    inputHand = inputHand.Substring(indexOfColumn, inputHand.Length - indexOfColumn);

                    currentHand = inputHand.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                }
            }

            //foreach (var item in playerHands)
            //{
            //    Console.WriteLine("{0} {1}", item.Key, string.Join(" ", item.Value));
            //}

            foreach (var item in playerHands)
            {
                long result = GetResult(item.Value);

                Console.WriteLine("{0}: {1}", item.Key, result);
            }
        }

        public static long GetResult(string[] hands)
        {
            long result = 0;

            hands = hands.Distinct().ToArray();

            foreach (var hand in hands)
            {
                int power = 0;
                int color = 0;

                if (hand.Length == 2 && char.IsDigit(hand[0]))
                {
                    power = int.Parse(hand[0].ToString());
                    color = CalculateColor(hand[1]);
                }

                else if (hand.Length == 2 && !char.IsDigit(hand[0]))
                {
                    switch (hand[0].ToString())
                    {
                        case "J": power = 11; break;
                        case "Q": power = 12; break;
                        case "K": power = 13; break;
                        case "A": power = 14; break;

                        default: break;
                    }

                    color = CalculateColor(hand[1]);
                }

                else
                {
                    power = 10;
                    color = CalculateColor(hand[2]);
                }

                result += color * power;
            }

            return result;
        }

        public static int CalculateColor (char colorChar)
        {
            int color = 0;
            switch (colorChar.ToString())
            {
                case "S": color = 4; break;
                case "H": color = 3; break;
                case "D": color = 2; break;
                case "C": color = 1; break;

                default:
                    break;
            }

            return color;
        }
    }
}
