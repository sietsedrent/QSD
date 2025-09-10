namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        private int size;

        public MyLinkedList()  // Fixed: constructor should have no parameters
        {
            first = null;
            size = 0;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(data);
            newNode.next = first;
            first = newNode;
            size++;
            // Removed the NotImplementedException
        }

        public T GetFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            return first.data;
        }

        public void RemoveFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            first = first.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            // Check bounds: index must be between 0 and size (inclusive)
            if (index < 0 || index > size)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            // Special case: insert at beginning
            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            // Find the position to insert
            MyLinkedListNode<T> current = first;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            // Create new node and insert
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(data);
            newNode.next = current.next;
            current.next = newNode;
            size++;
        }

        public override string ToString()
        {
            if (first == null)
            {
                return "NIL";
            }

            string result = "[";
            MyLinkedListNode<T> current = first;
            
            while (current != null)
            {
                result += current.data.ToString();
                if (current.next != null)
                {
                    result += ",";
                }
                current = current.next;
            }
            
            result += "]";
            return result;
        }
    }
}