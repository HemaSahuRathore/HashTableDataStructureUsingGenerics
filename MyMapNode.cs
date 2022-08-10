using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableNBinaryTree
{
    internal class MyMapNode<K, V>
    {
        public struct KeyValue<k, v> 
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }

        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items; //int[] array;

        //Constructor
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
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
            Console.WriteLine("Frequency of words in given phrase : ");
            hashTable.Display();
        }

        //check if word in paragraph already exists
        public bool Exists(K key) 
        {
            var linkedList = GetArrayPositionNLinkedList(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        //Method to get the linked list available in the key's position
        public LinkedList<KeyValue<K, V>> GetArrayPositionNLinkedList(K key)
        {
            int position = GetArrayPosition(key); //index of array
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            return linkedList;
        }

        //Method to get the Position/index of key in LinkedList array
        protected int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }

        //Method to add the key to LinkedList array
        public void Add(K key, V value)
        {
            var linkedList = GetArrayPositionNLinkedList(key);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };

            if (linkedList.Count != 0)
            {
                foreach (KeyValue<K, V> items in linkedList)
                {
                    if (items.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }
                }
            }
            linkedList.AddLast(item);
        }

        //Method to remove linkedList storing Key
        public void Remove(K key)
        {
            var linkedList = GetArrayPositionNLinkedList(key);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item; //storing item to remove it using in-built method
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }


        //Method to find the value of key
        public V GetValue(K key)
        {
            var linkedList = GetArrayPositionNLinkedList(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            return default(V);
        }

        //Method to get the linked list present in particular position
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        //Method to display the Keys and Values stored in item(Array)
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " -  " + element.Value);
                    }
            }

        } 

    }

}
