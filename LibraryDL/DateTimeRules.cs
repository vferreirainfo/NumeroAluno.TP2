using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDL
{

    // Esta classe tem metodos para verificar a data inserida
    class DateTimeRules
    {

        bool returnMethod;
        DateTime data;
        int mes, dia, ano;
        int hor, sec, min;


        public DateTimeRules()
        {

        }


        public DateTimeRules (DateTime d)
        {
            dia=d.Day;
            mes = d.Month;
            ano = d.Year;
            hor = d.Hour;
            sec = d.Second;
            min = d.Minute;
        }


        public bool CheckWholeDate (DateTime d)
        {
            returnMethod = true;
            //se dia<1 ou dia>31 retomar falso
            if (d.Day < 1 || d.Day > 31)
                returnMethod = false; // dia invalido -> data invalida
            else
            {
                //mes 2
                if (d.Month == 2 && d.Day > 28) // remotar falso
                    returnMethod = false;
                //mes 1, 3, 5, 7, 8, 10
                if (d.Month == 01 || d.Month == 03 || d.Month== 05 || d.Month== 07 ||d.Month == 08 || d.Month== 10 | d.Month == 12 )
                {
                    // testar se dia > 31
                    if (d.Day > 31)
                        returnMethod = false;
                }
                else if (d.Month == 04 || d.Month == 06 || d.Month == 09 || d.Month == 11)
                {
                    // testar se dia > 31
                    if (d.Day > 31)
                        returnMethod = false;
                }
            }


        }
        
    }

}
