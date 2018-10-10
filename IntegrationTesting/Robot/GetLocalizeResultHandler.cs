using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Robot
{
    public delegate bool GetLocalizeResultHandler(ref double PosX, ref double PosY, ref double theta, ref int posture);
}