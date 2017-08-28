using IMapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace C_ProxyPattern
{
    public class CMain:IMApp
    {
        public void RunMethod()
        {
            IPrintable p = new PrinterProxy("Alice");

            Console.WriteLine(String.Format("이름은 현재 {0} 입니다.", p.getPrinterName()));

            p.setPrinterName("Bob");
            Console.WriteLine(String.Format("이름은 현재 {0} 입니다.", p.getPrinterName()));
            p.print("Hello World");
        }
    }

    public interface IPrintable
    {
        void setPrinterName(String _name);
        string getPrinterName();
        void print(String _msg);
    }

    public class Printer: IPrintable
    {
        private String name;

        #region 생성자

        public Printer()
        {
            heavyJob("Printer의 인스턴스를 생성 중");
        }

        public Printer(String _name)
        {
            this.name = _name;
            heavyJob(String.Format("Printer의 인스턴스 ({0})을 생성 중", name));
        }

        #endregion
        
        #region Method 무거운 일


        /// <summary>
        /// 무거운 일을 시킴(가상)
        /// </summary>
        /// <param name="msg"></param>
        private void heavyJob(string msg)
        {
            Console.WriteLine(msg);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("완료");
        }

        #endregion

        #region Interface 구현
        
        public void setPrinterName(String _name)
        {
            this.name = _name;
        }

        public string getPrinterName()
        {
            return this.name;
        }

        public void print(String _msg)
        {
            Console.WriteLine(String.Format("======={0}========",this.name));
            Console.WriteLine(_msg);
        }
        #endregion
        
    }

    public class PrinterProxy:IPrintable
    {
        private String name;
        private Printer real;
        
        #region 생성자
        public PrinterProxy() { }
        public PrinterProxy(String _name)
        {
            this.name = _name;
        }

        #endregion
        
        #region Interface 구현


        public void setPrinterName(String _name)
        {
            if(null!=real)
            {
                real.setPrinterName(_name);
            }

            this.name = _name;

        }

        public string getPrinterName()
        {
            return this.name;
        }

        private void realize()
        {
            if (null == real)
                real = new Printer(name);
        }

        public void print(String _msg)
        {
            realize();
            real.print(_msg);
        }




        #endregion

    }


}
