using System;

namespace wa03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Take user inputs for personal biological stats
            Console.Write("What is your diastolic blood pressure (mmHg)?: ");
            double pressureDias = double.Parse(Console.ReadLine());
			Console.Write("What is your age?: ");
			double age = double.Parse(Console.ReadLine());
			Console.Write("What is your biological gender (M or F)?: ");
			string gender = (Console.ReadLine());
			
			// Call function and report PPT per unit distance
			Console.WriteLine($"Your pulse transit time per unit distance is: {pptPerD(pressureDias, age, gender)} msec/m");	
        }
        
        // define helper method
        static double pptPerD(double pressureDias, double age, string gender)
        {
			// define constants
			double K = 2819.7;
			double pOne = 57 - 0.44*age;
			double pZero = 0;
			// user input error check
			while(!(gender == "M"|| gender == "F"))
			{
				Console.Write("Improper gender input. Please input either \"M\" or \"F\": ");
				gender = Console.ReadLine();
			}
			// differentiate between male and female, and then output value 
			if(gender == "M")
			{
				pZero = 76 - (0.89*age);
			}
			if(gender == "F")
			{
				pZero = 72 - (0.89*age);
			}
			return K/(Math.Sqrt(Math.PI*(pOne)*(1+Math.Pow((pressureDias-pZero)/pOne, 2))*(0.5+(1/Math.PI)*Math.Atan((pressureDias-pZero)/pOne))));
		}
    }
}
