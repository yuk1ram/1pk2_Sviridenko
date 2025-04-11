namespace Task_21_02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace WordCounter
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sampleText = "Интересный текст о Боромире. " +
                                  "Боромир один из гланвых героев книги Властелин колец. " +
                                  "В этом тексте о Боромире и о Властелине колец сказано немного интересного.";

                Console.WriteLine("Исходный текст:");
                Console.WriteLine(sampleText);
                Console.WriteLine("\nРезультат подсчета слов:");

                Dictionary<string, int> wordCount = CountWords(sampleText);

                foreach (var pair in wordCount)
                {
                    Console.WriteLine($"Слово: '{pair.Key}', Количество: {pair.Value}");
                }
            }

            // метод для подсчета вхождений каждого слова в тексте
            static Dictionary<string, int> CountWords(string text)
            {
                // создание словаря для хранения результатов
                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                // разбиваем текст на слова, игнорируя знаки препинания
                char[] separators = new char[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    // приводим слово к нижнему регистру для унификации
                    string normalizedWord = word.ToLower();

                    // если слово уже есть в словаре, то увеличиваем счетчик
                    if (wordCount.ContainsKey(normalizedWord))
                    {
                        wordCount[normalizedWord]++;
                    }
                    // иначе добавляем слово в словарь с начальным значением 1
                    else
                    {
                        wordCount.Add(normalizedWord, 1);
                    }
                }

                return wordCount;
            }
        }
    }
}
