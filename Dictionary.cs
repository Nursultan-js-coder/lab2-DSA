
using System;
using System.Collections.Generic;
using System.Reflection;

namespace main
{
    public class Dictionary<T>
    {
        LinkedList<T>[] data;
        public int count = 0;
        public List<((string, T), (int, int))> KeyValuePair;
        public Dictionary()
        {
            this.KeyValuePair = new List<((string, T), (int, int))>();
            this.data = new LinkedList<T>[10000];
        }
        public void Add(string key, T value)
        {
            int index = HashTable(Convert.ToString(key));
            if (data[index] == null)
            {
                data[index] = new LinkedList<T>();
                data[index].AddFirst(value);


                ((string, T), (int, int)) myTuple = ((key, data[index].Last.Value), (index, 0));

                KeyValuePair.Add(myTuple);
            }
            else
            {
                data[index].AddLast(value);
                int subIndex=data[index].Count;
                ((string, T), (int, int)) myTuple = ((key, data[index].Last.Value), (index, subIndex));
                KeyValuePair.Add(myTuple);

            }
            count++;
        }
        public int HashTable(string key)
        {
            char[] chArr = key.ToCharArray();
            int sum = 0;
            foreach (char ch in chArr)
            {
                sum += (int)ch;
            }
            return sum % data.GetUpperBound(0);

        }

        public T Get(string key)
        {
            int index = HashTable(Convert.ToString(key));
           foreach (var item in data[index])
                {
                    object obj = (object)item;

                    Type type = obj.GetType();
                    PropertyInfo propInfo = type.GetProperty("name"); //this returns null
                    object itemValue = propInfo.GetValue(obj);

                    if (itemValue.ToString() == key.ToString())
                    {
                        return item;
                    }
                    
                }
                T value = data[index].First.Value;
                return value;

            
          
            
        }

    }
}
