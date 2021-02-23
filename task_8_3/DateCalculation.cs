using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8_3
{
    class DateCalculation
    {
        public static int[] DateToNumber(string date)
        {
            date.Split('.');
            int[] arrDate = new int[3];
            for (int i = 0; i < arrDate.Length; i++)
            {
                arrDate[i] = int.Parse(date[i].ToString());
            }
            int[] ErrorDate = new int[1];

            return CheackDate(arrDate) ? arrDate : ErrorDate; 
        }

        private static bool CheackDate(int[] arrDate)
        {
            return arrDate[2] > 0 && arrDate[1] >= 12 && arrDate[1] > 0 && arrDate[0] > 0 && arrDate[0] <= AmountDays(arrDate[1], arrDate[2]);
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

        public static bool IsInDates (int[]date1, int[]checkDate, int[]date2)
        {
            return false; 
        }

    }
}
