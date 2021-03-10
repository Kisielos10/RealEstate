using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.UnitTest
{
    public class ExpectedStatistics
    {
        public decimal ExpectedMeanArea { get; set; }
        public decimal ExpectedMeanPricePerMeter { get; set; }

        public ExpectedStatistics(decimal expectedMeanArea, decimal expectedMeanPricePerMeter)
        {
            ExpectedMeanArea = expectedMeanArea;
            ExpectedMeanPricePerMeter = expectedMeanPricePerMeter;
        }

    }
}
