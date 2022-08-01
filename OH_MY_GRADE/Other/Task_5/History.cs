namespace OH_MY_GRADE.Other
{
    public class History
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public OpertationType OpertationType { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
    }

    public enum OpertationType
    {
        Input = 0,
        Output = 1
    }
}
