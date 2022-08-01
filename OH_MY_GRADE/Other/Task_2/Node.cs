namespace OH_MY_GRADE
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public int a;

        public Node(T data)
        {
            Data = data;
        }
    }
}
