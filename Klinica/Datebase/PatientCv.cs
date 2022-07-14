using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinica.Datebase
{
    public partial class Patient
    {
        public string PatientName
        {
            get
            {
                return String.Join(" ", new string[] {Id.ToString(), LastName, Name, Patronymic });
            }
        }
        public string PatientDate
        {
            get
            {
                return String.Format("{0:MM/dd/yyyy}", Birthday);
                    
            }
        }
        public string PatientPassportDate
        {
            get
            {
                return String.Format("{0:MM/dd/yyyy}", PassportDate);

            }
        }
        public int PatientSex
        {
            get
            {
                if (Sex == "м")
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                if (PatientSex == 0)
                {
                    Sex= "м";
                }
                else
                {
                    Sex = "ж";
                }
            }
        }

    }
}
