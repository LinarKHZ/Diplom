using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicaConsole.DataBase
{
    public partial class TimeTable
    {
        public string TimeName
        {
            get
            {
                return Time.ToString();
            }
        }
        public string TimeDate
        {
            get
            {
                return Date.ToString("");
            }
        }
    }
}
