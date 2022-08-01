using System.Collections;

namespace OH_MY_GRADE
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (_head == null)
            {
                _head = node;
                _tail = node;
                _tail.Next = node;
            } else
            {
                _tail.Next = node;
                node.Next = _head;
                _tail = node;
            }
            _count++;
        }

        public bool Remove(T data)
        {
            if (_head != null)
            {
                var current = _head;
                var previous = _tail;
                do
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        _count--;
                        if (_count == 0)
                        {
                            Clear();
                            return true;
                        }
                        if (current == _head)
                        {
                            _head = current.Next;
                        }
                        if (current == _tail)
                        {
                            _tail = previous;
                        }
                        current = null;
                        return true;
                    }
                    previous = current;
                    current = current.Next;
                } while (current != _head);
                return false;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T data)
        {
            if (_head != null)
            {
                var current = _head;
                do
                {
                    if (current.Data.Equals(data))
                    {
                        return true;
                    }
                    current = current.Next;
                } while (current != _head);
                return false;
            }
            return false;
        }

        public T GetByIndex(int index)
        {
            var node = GetNodeByIndex(index);
            return node != null ? node.Data : default;
        }

        public Node<T> GetNodeByIndex(int index)
        {
            if (_head == null || index >= _count)
            {
                return default;
            }
            var current = _head;
            var counter = 0;

            while(counter < index)
            {
                current = current.Next;
                counter++;
            }
            return current;
        }

        public void AddByIndex(T data, int index)
        {
            if (_head == null)
            {
                return;
            }
            var node = new Node<T>(data);
            var current = GetNodeByIndex(index);
            Node<T> previous = null;

            if (current == null && _tail != null)
            {
                _tail.Next = node;
                node.Next = _head;
            } else
            {
                if (index == 0)
                {
                    previous = _tail;
                    _head = node;
                } else
                {
                    previous = GetNodeByIndex(index - 1);
                }
                node.Next = current;
                previous.Next = node;
            }
        }

        public void Swap(Node<T> first, Node<T> second)
        {
            var temp = second.Data;
            second.Data = first.Data;
            first.Data = temp;
        }

        public void SimpleSort()
        {
            for (int i = 0; i < _count; i++)
            {
                for (int j = i + 1; j < _count; j++)
                {
                    var current = GetNodeByIndex(i);
                    var next = GetNodeByIndex(j);

                    var a = current.Data as IComparable;
                    var b = next.Data as IComparable;

                    if (a.CompareTo(b) == 1)
                    {
                        Swap(current, next);
                    }
                }
            }
        }

        public void QuickSort(int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            int pivotIndex = GetPivotIndex(minIndex, maxIndex);

            QuickSort(minIndex, pivotIndex - 1);
            QuickSort(pivotIndex + 1, maxIndex);
        }

        private int GetPivotIndex(int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                var current = GetNodeByIndex(i);
                var next = GetNodeByIndex(maxIndex);

                var a = current.Data as IComparable;
                var b = next.Data as IComparable;

                if (a.CompareTo(b) == -1)
                {
                    pivot++;
                    Swap(GetNodeByIndex(pivot), current);
                }
            }
            pivot++;
            Swap(GetNodeByIndex(pivot), GetNodeByIndex(maxIndex));

            return pivot;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            do
            {
                if (node != null)
                {
                    yield return node.Data;
                    node = node.Next;
                }
            } while (node != _head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
