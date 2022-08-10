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
                Console.WriteLine("1.Find frequency of words in a sentence like “To be or not to be");
                Console.Write("2.Exit   ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        string paragraph = "To be or not to be";
                        MyMapNode<string, int>.CountNumOfOccurence(paragraph);
                        break;

                }

            } while (option != 2);
        }
    }
}



