using IMapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_MementoPattern
{
    public class CMain: IMApp
    {
        public void RunMethod()
        {

            Gamer gamer = new Gamer(100);

            Memento m = gamer.createMemento();

            for(int i=0;i<100;i++)
            {
                Console.WriteLine("{0}", i);
                Console.WriteLine("{0}", gamer.ToString());

                gamer.bet();

                Console.WriteLine("소지금이 {0}가 되었습니다.", gamer.getMoney());

                if(gamer.getMoney()>m.getMoney())
                {
                    Console.WriteLine("많이 증가했으므로 현재 상태를 저장한다.");
                    m = gamer.createMemento();
                }
                else if(gamer.getMoney()<m.getMoney()/2)
                {
                    Console.WriteLine("많이 감소했으므로 이전 상태 저장합니다.");
                    gamer.restoreMemento(m);
                }


                Thread.Sleep(1000);

                Console.WriteLine(" ");
            }



        }
    }

    public class Memento
    {
        private int money;
        private List<String> fruits;
        
        public Memento(int _money)
        {
            this.money = _money;
            this.fruits = new List<String>();
        }

        public int getMoney()
        {
            return this.money;
        }

        public void addFruit(String fruit)
        {
            fruits.Add(fruit);
        }

        public List<String> getFruits()
        {
            return fruits.Clone<String>();
        }

    }


    public class Gamer
    {
        private int money;
        private List<String> fruits = new List<String>();
        private Random random = new Random();
        private static List<String> fruitsname = new List<String> {
            "사과",
            "포도",
            "바나나",
            "귤",
        };

        public Gamer(int _money)
        {
            this.money = _money;
        }

        public int getMoney()
        {
            return this.money;
        }


        public void bet()
        {
            int dice = random.Next(1, 6);

            Console.WriteLine("Dice:{0}", dice);

            if(1 == dice)
            {
                money += 100;
                Console.WriteLine("소지금이 증가하였습니다.");
            }
            else if(2 == dice)
            {
                money /= 2;
                Console.WriteLine("소지금이 절반이되었습니다.");
            }
            else if(5 == dice)
            {
                String f = getFruit();

                fruits.Add(f);

                Console.WriteLine("과일({0})을 받았습니다.", f);
            }
            else
            {
                Console.WriteLine("변경 없음");
            }
        }
        

        public String ToString()
        {
            String retString = String.Join(",", this.fruits);

            return String.Format("money: {0}, fruits: {1}", this.money, retString);
        }

        private String getFruit()
        {
            String preFix = String.Empty;

            if (0 == random.Next() % 2)
            {
                preFix = "맛있는";
            }

            return preFix + fruitsname[random.Next(fruitsname.Count)];

        }






        /// <summary>
        /// 스냅샵 만들기
        /// </summary>
        /// <returns></returns>
        public Memento createMemento()
        {
            Memento m = new Memento(money);

            foreach(var item in fruits)
            {
                m.addFruit(item);
            }


            return m;
        }

        /// <summary>
        /// undo
        /// </summary>
        /// <param name="memento"></param>
        public void restoreMemento(Memento memento)
        {
            this.money = memento.getMoney();
            this.fruits = memento.getFruits();
        }


    }
















    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
