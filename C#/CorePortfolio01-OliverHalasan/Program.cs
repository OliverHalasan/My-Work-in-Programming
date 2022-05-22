using System;

namespace CorePortfolio01_OliverHalasan
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable
            double EstimatedFlight, AcceptError, actualflight, margintime = 0, remaingingtime;
            
            //input

            Console.WriteLine("This program is used to detemine if the estimated flight time is acceptable\n\n");

            Console.Write("enter estimated flight time in minutes: ");
            EstimatedFlight = double.Parse(Console.ReadLine());

            Console.Write("Enter actual flight time in minutes: ");
            actualflight = double.Parse(Console.ReadLine());

            //margine time solution
            if (EstimatedFlight < actualflight)
            {
                AcceptError = actualflight - EstimatedFlight;
            }
            else
            { 
            AcceptError = EstimatedFlight - actualflight;
            }

           



            //margine time on the table

            if (EstimatedFlight > 0 && EstimatedFlight <= 29)
            { 
                margintime = 1;
            }
            if (EstimatedFlight > 29 && EstimatedFlight <= 59)
            {
                margintime = 2;
            }
            if (EstimatedFlight > 59 && EstimatedFlight <= 89)
            {
                margintime = 3;
            }
            if (EstimatedFlight > 89 && EstimatedFlight <= 119)
            {
                margintime = 4;
            }
            if (EstimatedFlight > 119 && EstimatedFlight <= 179)
            {
                margintime = 6;
            }
            if (EstimatedFlight > 179 && EstimatedFlight <= 239)
            {
                margintime = 8;
            }
            if (EstimatedFlight > 239 && EstimatedFlight <= 359)
            {
                margintime = 13;
            }
            if (EstimatedFlight > 359)
            {
                margintime = 17;
            }

                //margin out come
                if (AcceptError < margintime)
            {
                remaingingtime = margintime - AcceptError;
            }
            else
            { 
            remaingingtime = AcceptError - margintime;
            }

            

            //output
            if (margintime == AcceptError)
            {
                Console.WriteLine("Estimated Time is acceptable");
            }
            else
            { 
                if (EstimatedFlight < actualflight )
                {
                Console.WriteLine("Estimated time too small (by {0} minute)", remaingingtime);
                }
                else
                {
                Console.WriteLine("Estimated time too big (by {0} minutes)", remaingingtime);
                }
            }
          

            



            //output
        }
    }
}
