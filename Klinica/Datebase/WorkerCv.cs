using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinica.Datebase
{
    public partial class Worker
    {
        public string WorkerName
        {
            get
            {
                return String.Join(" ",new string[] {LastName,Name,Patronymic});
            }
        }

    }
}
