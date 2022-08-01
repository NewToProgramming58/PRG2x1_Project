using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Stopwatch
{
    class Stopwatch
    {
        int x = 0;
        int y = 0;
        bool continueLoop = true;

        public Stopwatch()
        {
        }

        public void StopwatchSeconds()
        {
            while (continueLoop)
            {
                Thread.Sleep(1000);
                if (x >= 59)
                {
                    x = 1;
                }
                else
                {
                    x++;
                }
                Console.Clear();
                Console.WriteLine(y + ":" + x);
            }
        }

        public void StopwatchMinutes()
        {
            while (continueLoop)
            {
                Thread.Sleep(1000);
                if (x >= 59)
                {
                    y++;
                }
            }
        }
    }
}
