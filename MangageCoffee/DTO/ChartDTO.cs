using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class DailyProfitDTO
    {
        public DateTime SummaryDate { get; set; }
        public decimal Profit { get; set; }

        public int OrderCount { get; set; }
    }

}
