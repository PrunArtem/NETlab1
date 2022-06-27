using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab1
{
    public class WorkerInfo
    {
        public int personalID { get; set; }
        public string taxpayerCardID { get; set; }
        public string specialization { get; set; }
        public DateTime hiredDate { get; set; }
        public WorkerInfo(int personalID, string taxpayerCardID, string specialization, DateTime hiredDate)
        {
            this.personalID = personalID;
            this.taxpayerCardID = taxpayerCardID;
            this.specialization = specialization;
            this.hiredDate = hiredDate;
        }
        public override string ToString()
        {
            return string.Format($"{personalID}. hired:{hiredDate.ToString("dd/MM/yyyy")}, spec: {specialization} - Tax Payers Card ID - {taxpayerCardID}");
        }
    }
}
