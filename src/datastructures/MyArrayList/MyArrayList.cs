using System;
using System.Collections;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            // Check for invalid capacity
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than 0");
            }

            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            // Check if array is full
            if (size >= data.Length)
            {
                throw new MyArrayListFullException();
            }
            
            data[size] = n;
            size++;
        }

        public int Get(int index)
        {
            // Check if index is valid
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
            
            return data[index];
        }

        public void Set(int index, int n)
        {
            // Check if index is valid
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
            
            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
            // Optional: clear the array values (not strictly necessary)
            // Array.Clear(data, 0, data.Length);
        }

        public int CountOccurences(int n)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] == n)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }
            
            if (size == 1)
            {
                return "[" + data[0] + "]";
            }
            
            string result = "[";
            for (int i = 0; i < size; i++)
            {
                result += data[i];
                if (i < size - 1)
                {
                    result += ",";
                }
            }
            result += "]";
            
            return result;
        }
    }
}