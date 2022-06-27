using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab1
{
    public class MonthlySalary
    {
        public string taxpayerCardID { get; set; }
        public DateTime monthYear { get; set; }
        public int salary { get; set; }
        public MonthlySalary(string taxpayerCardID, DateTime monthYear, int salary)
        {
            this.taxpayerCardID = taxpayerCardID;
            this.monthYear = monthYear;
            this.salary = salary;
        }
        public override string ToString()
        {
            return string.Format($"Date: {monthYear.ToString("MM/yyyy")} - {salary} UAH Tax Payers Card ID:{taxpayerCardID}");
        }
    }
}
