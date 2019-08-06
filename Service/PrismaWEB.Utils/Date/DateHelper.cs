using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismaWEB.Utils.Date
{
    public static class DateHelper
    {
        public static FirstAndLastDay GetFirstAndLastDayOfWeek(DateTime day)
        {
            int diasParaSubtrair = 0;
            int diasParaSomar = 0;
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    diasParaSomar = 6;
                    break;
                case DayOfWeek.Tuesday:
                    diasParaSubtrair = 1;
                    diasParaSomar = 5;
                    break;
                case DayOfWeek.Wednesday:
                    diasParaSubtrair = 2;
                    diasParaSomar = 4;
                    break;
                case DayOfWeek.Thursday:
                    diasParaSubtrair = 3;
                    diasParaSomar = 3;
                    break;
                case DayOfWeek.Friday:
                    diasParaSubtrair = 5;
                    diasParaSomar = 2;
                    break;
                case DayOfWeek.Saturday:
                    diasParaSubtrair = 5;
                    diasParaSomar = 1;
                    break;
                case DayOfWeek.Sunday:
                    diasParaSubtrair = 6;
                    break;
            }

            DateTime firstDay = day.AddDays(-diasParaSubtrair);
            DateTime lastDay = day.AddDays(diasParaSomar);
            return new FirstAndLastDay(firstDay, lastDay);
        }
    }
}

public class FirstAndLastDay
{
    private DateTime _LastDay;
    private DateTime _FirstDay;

    public FirstAndLastDay(DateTime firstDay, DateTime lastDay)
    {
        _FirstDay = Convert.ToDateTime(firstDay.ToString());
        _LastDay = Convert.ToDateTime(lastDay.ToString());
    }

    public DateTime FirstDay { get => _FirstDay; }
    public DateTime LastDay { get => _LastDay; }
}
