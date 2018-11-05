using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Robot
{
    public delegate int DoCalibrateHandler(double PosX, double PosY, double theta, bool terminal);
}