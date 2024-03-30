
namespace Assignment3
{
    public class Node
    {
        public User Value { get; set; }
        public Node Next { get; set; }
        public Node()
        {
            Value = null;
            Next = null;
        }
    }
}
