using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace nostalebot
{
    class Methods
    {       

        /// <summary>
        /// Checking if raid is now
        /// </summary>
        /// <param name="screenshot"></param>
        public void CheckIfRaid(Bitmap screenshot)
        {
            Color RaidCheckerDemons = screenshot.GetPixel(1029, 976);
            if (RaidCheckerDemons.R == 229)
            {
                               
                SendKeys.SendWait($"Mamy rajdzik !");
                Thread.Sleep(500);
                SendKeys.SendWait("{ENTER}");
            }
            Color RaidCheckerAngels = screenshot.GetPixel(889, 978);
            if (RaidCheckerAngels.R == 255)
            {
                
                SendKeys.SendWait($"Anioły mają rajd");
                Thread.Sleep(500);
                SendKeys.SendWait("{ENTER}");               
            }
        }

        int leftsideofbar = 1030;
        int rightsideofbar = 1341;
        int Rcolorofbar = 185;

        /// <summary>
        /// Checking percentage of raid
        /// </summary>
        /// <param name="screenshot"></param>
        public void CheckPercantage(Bitmap screenshot)
        {
            
            for (int i = leftsideofbar; i < rightsideofbar; i+=2)
            {
                Color Checker = screenshot.GetPixel((int)i, 976);

                if (Checker.R == Rcolorofbar || Checker.R == Rcolorofbar-1)
                {
                    float Finalvalue = CalculatePerc(i);

                    Color MoreThan90 = screenshot.GetPixel((int)1049, 978);
                    if (MoreThan90.R == 154)
                    {
                        SendKeys.SendWait($"Za chwile bedzie rajd! (wiecej niz 90 procent)");
                        Thread.Sleep(500);
                        SendKeys.SendWait("{ENTER}");
                    }
                    else
                    {
                        SendKeys.SendWait($"Na glacy jest {Finalvalue} procent.");
                        Thread.Sleep(500);
                        SendKeys.SendWait("{ENTER}");
                    }
                    break;
                }
            }

            
        }

        private static float CalculatePerc(int i)
        {
            float percantage = ((float)(i - 1030) / (float)311) * 100;
            percantage = (float)System.Math.Round(percantage, 0);
            var Finalvalue = 101 - percantage;
            return Finalvalue;
        }
    }
}
