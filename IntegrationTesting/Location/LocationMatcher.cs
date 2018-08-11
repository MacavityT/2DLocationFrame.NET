using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    class LocationMatcher
    {
        private AqVision.Shape.AqGdiPointF m_CenterResult = new AqVision.Shape.AqGdiPointF();
        public AqVision.Shape.AqGdiPointF CenterResult
        {
            get { return m_CenterResult; }
            set { m_CenterResult = value; }
        }


        public bool RunMatcher()
        {
            //AqVision.Interaction.UI2LibInterface.GetImageSpecificLocation1()

            return true;
        }

    }
}
