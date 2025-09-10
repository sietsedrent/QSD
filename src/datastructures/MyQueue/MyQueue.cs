namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private MyQueueNode<T> front;
        private MyQueueNode<T> back;
        private int size = 0;
        
        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T data)
        {
            MyQueueNode<T> newNode = new MyQueueNode<T>(data, null);
            
            if (IsEmpty())
            {
                // First element: both front and back point to the new node
                front = newNode;
                back = newNode;
            }
            else
            {
                // Add to the back: link current back to new node, then update back pointer
                back.next = newNode;
                back = newNode;
            }
            
            size++;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }
            
            return front.data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }
            
            T data = front.data;
            front = front.next;
            size--;
            
            // If queue becomes empty after dequeue, reset back pointer
            if (size == 0)
            {
                back = null;
            }
            
            return data;
        }

        public void Clear()
        {
            front = null;
            back = null;
            size = 0;
        }
    }
}