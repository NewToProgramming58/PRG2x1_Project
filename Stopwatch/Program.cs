using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueLoop = true;

            Stopwatch sw = new Stopwatch();
            Thread StopwatchSecondsThread = new Thread(sw.StopwatchSeconds);
            Thread StopwatchMinutesThread = new Thread(sw.StopwatchMinutes);
            StopwatchSecondsThread.Start();
            StopwatchMinutesThread.Start();

            while (continueLoop)
            {
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    continueLoop = false;
                    StopwatchSecondsThread.Abort();
                    StopwatchMinutesThread.Abort();
                }
            }
        }
    }
}
