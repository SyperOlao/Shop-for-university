using System;

namespace LibStore
{
   public class DateCalculation
    {
        public static int[] DateToNumber(string date)
        {
            string[] dateSplit = date.Split('.');
            int[] arrDate = new int[3];
            for (int i = 0; i < arrDate.Length; i++)
            {
                arrDate[i] = int.Parse(dateSplit[i].ToString());
            }

            int[] errorDate = new int[1];

            return CheckDate(arrDate) ? arrDate : errorDate;
        }

        private static bool CheckDate(int[] arrDate)
        {
            return arrDate[2] > 0 && arrDate[1] <= 12 && arrDate[1] > 0 && arrDate[0] > 0 &&
                   arrDate[0] <= AmountDays(arrDate[1], arrDate[2]);
        }

        private static int AmountDays(int mouth, int year)
        {
            switch (mouth)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((year % 400 == 0 || year % 4 == 0) && year % 100 != 0) return 29;
                    else return 28;
                default:
                    return 0;
            }
        }

        public static bool IsInDates(int[] date1, int[] checkDate, int[] date2)
        {
            DateTime d1 = new DateTime(date1[2], date1[1], date1[0]);
            DateTime d2 = new DateTime(date2[2], date2[1], date2[0]);
            DateTime dCD = new DateTime(checkDate[2], checkDate[1], checkDate[0]);

            return d1 <= dCD && dCD <= d2;
        }
    }
}