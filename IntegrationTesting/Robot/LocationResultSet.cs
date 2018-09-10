using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Robot
{
    public class LocationResultSet
    {
        double m_centerX = 0;

        public double CenterX
        {
            get { return m_centerX; }
            set { m_centerX = value; }
        }
        double m_centerY = 0;

        public double CenterY
        {
            get { return m_centerY; }
            set { m_centerY = value; }
        }
        double m_angle = 0;

        public double Angle
        {
            get { return m_angle; }
            set { m_angle = value; }
        }
        ProductPosture posture = ProductPosture.Normal;

        public ProductPosture Posture
        {
            get { return posture; }
            set { posture = value; }
        }
        bool m_transmit = false;

        public bool Transmited
        {
            get { return m_transmit; }
            set { m_transmit = value; }
        }

        private double m_score = 0;

        public double Score
        {
            get { return m_score; }
            set { m_score = value; }
        }

    }
}
