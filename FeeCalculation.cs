using System;
using System.Collections.Generic;
using System.Text;

namespace Trailblazing_Technologies
{
    class FeeCalculation
    {
        private double offerRate;
        private double dicountedValue = 0.15;
        private double offerFee;
    
        public double CalculateOfferRate(int numberOfUsers)
        {
            if (numberOfUsers < 26)
                offerRate = 50.0;

            else if (numberOfUsers > 25 && numberOfUsers < 51)
                offerRate = 47.50;
            else
                offerRate = 45.0;

            return offerRate;
        }

        public double CalculateFee(int numberOfUsers, double offerRate, string offerType)
        {
            if (offerType == "Y")
                offerFee = numberOfUsers * offerRate * dicountedValue;
            else
                offerFee = numberOfUsers * offerRate;

            return offerFee;
        }
    }
}
