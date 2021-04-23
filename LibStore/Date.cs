namespace LibStore
{
   public class Date
    {
        public string DateOfOperation { get; }
        public int Money { get; }

        public Date(int Money, string DateOfOperation)
        {
            this.DateOfOperation = DateOfOperation;
            this.Money = Money;
        }
    }
}
