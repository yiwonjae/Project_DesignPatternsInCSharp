using IMapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_StatePattern
{
    public class CMain:IMApp
    {
        public void RunMethod()
        {
        }
    }



    public interface IMybody
    {
        void 밥먹어();
        void 소화시켜();
        void 자버려();
    }

    public class HUNGRY : IMybody
    {
        public void 밥먹어()
        {
            throw new NotImplementedException();
        }

        public void 소화시켜()
        {
            throw new NotImplementedException();
        }

        public void 자버려()
        {
            throw new NotImplementedException();
        }
    }

    public class FULL : IMybody
    {
        public void 밥먹어()
        {
            throw new NotImplementedException();
        }

        public void 소화시켜()
        {
            throw new NotImplementedException();
        }

        public void 자버려()
        {
            throw new NotImplementedException();
        }
    }

    public class ANGRY : IMybody
    {
        public void 밥먹어()
        {
            throw new NotImplementedException();
        }

        public void 소화시켜()
        {
            throw new NotImplementedException();
        }

        public void 자버려()
        {
            throw new NotImplementedException();
        }
    }

    public class SLEEPING : IMybody
    {
        public void 밥먹어()
        {
            throw new NotImplementedException();
        }

        public void 소화시켜()
        {
            throw new NotImplementedException();
        }

        public void 자버려()
        {
            throw new NotImplementedException();
        }
    }


    public class TEST
    {
        enum Mybody { HUNGRY = 0, FULL, ANGRY, SLEEPING };

        enum EEvent { DoEatIt=0, DoSleeping, DoHungry, DoDigest }

        public void TE()
        {
            int State = 0;
            int flag = 0;

            if (State == (int)Mybody.HUNGRY)
            {
                FAction("밥먹어");
            }
            else if (State == (int)Mybody.FULL)
            {
                Random r = new Random();

                switch((EEvent)Enum.ToObject(typeof(EEvent), r.Next(0,3)))
                {
                    case EEvent.DoEatIt:    FAction("소화시켜"); break;
                    case EEvent.DoSleeping: FAction("자버려"); break;
                    case EEvent.DoHungry:   FAction("배고파"); break;
                    case EEvent.DoDigest:   FAction("소화시켜"); break;
                }
                

            }
            else if (State == (int)Mybody.ANGRY)
            {
                FAction("소화시켜");
            }
            else if (State == (int)Mybody.SLEEPING)
            {
                FAction("오늘은 끝");
            }
        }

        public void FAction(String temp)
        {

        }

    }
}
