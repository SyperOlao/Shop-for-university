namespace task_8_3
{
    class Date
    {
        public string DateOfOperation { set; get; }
        public int Money { set; get; }

        public Date(int Money, string DateOfOperation)
        {
            this.DateOfOperation = DateOfOperation;
            this.Money = Money;
        } 
        public Date() { }

    }
}
