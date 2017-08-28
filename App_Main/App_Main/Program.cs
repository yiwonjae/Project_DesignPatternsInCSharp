using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMapp;

namespace App_Main
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputData = Console.ReadLine();

            IMApp MRun = null;

            switch(Convert.ToInt32(inputData))
            {
                case 0: MRun = new C_AdapterPattern.CMain(); break;
                case 1: MRun = new C_ProxyPattern.CMain(); break;
                case 2: MRun = new C_MementoPattern.CMain(); break;
                case 3: break;
                case 4: break;
                case 5: break;
            }

            MRun.RunMethod();

        }
    }




}
