using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Magic_exchangeable_words
{
    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var wordOne = input[0];
            var wordTwo = input[1];

            bool areExchangeable = true;

            if (wordOne.Length == wordTwo.Length)
            {
                var checkWordOne = GetWordDictionary(wordOne);
                var checkWordTwo = GetWordDictionary(wordTwo);

                areExchangeable = CheckExchangeable(checkWordOne, checkWordTwo);
            }

            else if (wordTwo.Length > wordOne.Length)
            {
                string temp = wordOne;
                wordOne = wordTwo;
                wordTwo = temp;
            }

            if (wordOne.Length > wordTwo.Length)
            {
                var difference = wordOne.Length - wordTwo.Length;
                for (int i = 0; i < wordOne.Length - wordTwo.Length; i++)
                {
                    var substringToCheck = wordOne.Substring(i, wordTwo.Length);

                    var checkWordOne = GetWordDictionary(substringToCheck);
                    var checkWordTwo = GetWordDictionary(wordTwo);

                    areExchangeable = CheckExchangeable(checkWordOne, checkWordTwo);

                    if (areExchangeable == false)
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (!substringToCheck.Contains(wordOne[j]))
                            {
                                areExchangeable = false;
                            }
                        }

                        for (int j = i + wordTwo.Length; j < wordOne.Length; j++)
                        {
                            if (!substringToCheck.Contains(wordOne[j]))
                            {
                                areExchangeable = false;
                            }
                        }

                    }

                    if (areExchangeable)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(areExchangeable.ToString().ToLower());
        }

        public static Dictionary<int, List<int>> GetWordDictionary (string stringToCheck)
        {

            var CheckWord = new Dictionary<int, List<int>>();
            var indexLetter = 0;

            foreach (var letter in stringToCheck)
            {
                var currentOccurance = 0;
                var indexOccurance = 0;
                var listOccurances = new List<int>();

                do
                {
                    currentOccurance = stringToCheck.IndexOf(letter, indexOccurance);

                    if (currentOccurance != -1)
                    {
                        listOccurances.Add(currentOccurance);
                    }

                    indexOccurance = currentOccurance + 1; ;

                } while (currentOccurance != -1);

                if (!CheckWord.ContainsKey(indexLetter))
                {
                    CheckWord[indexLetter] = new List<int>();
                }

                CheckWord[indexLetter].AddRange(listOccurances);

                indexLetter++;
            }

            return CheckWord;
        }

        public static bool CheckExchangeable (Dictionary<int, List<int>> dictionaryOne, Dictionary<int, List<int>> dictionaryTwo)
        {
            bool areExchangeable = true;

            if (dictionaryOne.Count != dictionaryTwo.Count)
            {
                areExchangeable = false;
            }

            else
            {
                for (int i = 0; i < dictionaryOne.Count; i++)
                {
                    if (dictionaryOne[i].Count != dictionaryTwo[i].Count)
                    {
                        areExchangeable = false;
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < dictionaryOne[i].Count; j++)
                        {
                            if (dictionaryOne[i][j] != dictionaryTwo[i][j])
                            {
                                areExchangeable = false;
                            }
                        }
                    }
                }
            }

            return areExchangeable;
        }
    }
}
