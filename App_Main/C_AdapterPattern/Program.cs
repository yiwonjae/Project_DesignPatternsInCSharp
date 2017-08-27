using IMapp;
using System;

namespace C_AdapterPattern
{
    public class CMain: IMApp
    {
        public void RunMethod()
        {
            IPrint p = new PrintBanner("hello");

            p.printWeek();
            p.printStrong();
        }
    }

    /// <summary>
    /// 실제 구현
    /// </summary>
    public class Banner
    {
        private String name{get;set;}

        public Banner(String _name)
        {
            this.name = _name;
        }

        public void showWithParen()
        {
            Console.WriteLine("({0})", this.name);
        }

        public void showWithAster()
        {
            Console.WriteLine("*{0}*", this.name);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public interface IPrint
    {
        void printWeek();
        void printStrong();
    }


    public class PrintBanner : Banner, IPrint
    {
        public PrintBanner(String _name):base(_name)
        {   
        }
        
        public void printStrong()
        {
            showWithAster();
        }

        public void printWeek()
        {
            showWithParen();
        }
    }
    

}
