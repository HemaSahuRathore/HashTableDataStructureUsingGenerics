namespace HashTableNBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;

            Console.WriteLine("Welcome to the Hash table and BST Data Structures using Generics");

            do
            {
                Console.WriteLine("\nPlease select from below use case to execute");
                Console.WriteLine("1.Find frequency of words in a sentence like 'To be or not to be' ");
                Console.WriteLine("2.Frequency of words in a large paragraph phrase 'Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations'");
                Console.WriteLine("3.Remove avoidable word from the phrase 'Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations'");
                Console.Write("4.Exit   ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        string paragraph = "To be or not to be";
                        CountNumOfOccurence(paragraph);
                        break;
                    case 2:
                        string phrase = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                        CountNumOfOccurence(phrase);
                        break;
                    case 3:
                        string phrases = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                        CountNumOfOccurence(phrases);
                        break;
                }

            } while (option != 4);
        }

        //Method to find the frequency
        public static void CountNumOfOccurence(string phrase)
        {
            MyMapNode<string, int> hashTable = new MyMapNode<string, int>(6);

            string[] words = phrase.Split(' ');

            foreach (string word in words)
            {
                if (hashTable.Exists(word.ToLower()))
                    hashTable.Add(word.ToLower(), hashTable.GetValue(word.ToLower()) + 1);
                else
                    hashTable.Add(word.ToLower(), 1);
            }
            Console.WriteLine("\nFrequency of words in given phrase : ");
            hashTable.Display();
            string rem = "avoidable";
            hashTable.Remove(rem);
            Console.WriteLine("\nFrequency of words after removing '{0}' : ", rem);
            hashTable.Display();

        }
    }
}



