namespace OH_MY_GRADE
{
    public class Footballer : IComparable<Footballer>
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public int CompareTo(Footballer? other)
        {
            if (Number > other.Number)
            {
                return 1;
            }
            if (Number < other.Number)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
