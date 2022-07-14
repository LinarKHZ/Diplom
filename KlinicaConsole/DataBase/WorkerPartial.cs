using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicaConsole.DataBase
{
    public partial class Worker
    {
        public string DoctorName
        {
            get
            {
                string[] worker = { LastName, Name, Patronymic };
                return String.Join(" ", worker);
            }
        }

    }
}