using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelConsuptionCalculator {
    /*
    * Calculates fuel consumption in l/100km and the equivalent mpg,
    * input units of measurement are litres (l) for the fuel used and
    * kilometres (km) for the distance travelled
    *
    * Author: Tylor Stewart, n9013555
    * Date: 10 August 2015
    *
    */

    class Program {
        static void Main() {
			welcomeMessage();
			calculate();
            reCalculate();
		} //End Main

		static void welcomeMessage() {
			Console.WriteLine("\n\tWelcome to Fuel Consumption Calculator!\n");
		} //End welcomeMessage

		static void calculate() {
			double fuel = 0;
			double distance = 0;

			fuel = inputFuel();
			distance = inputDistance(fuel);
			fuelConsumption(fuel, distance);
		} //End calculate

		static double inputFuel() {
			string input = String.Empty;
			double fuel = 0;

			Console.Write("\nEnter the amount of fuel used in Litres: ");
			input = Console.ReadLine();

			if (!double.TryParse(input, out fuel)) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Oops! " + input + " is not a number!");
				Console.ForegroundColor = ConsoleColor.White;
				inputFuel();
			}
			
			else if (fuel < 20) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Oops! " + fuel + " is blow the minimum value of 20L!");
				Console.ForegroundColor = ConsoleColor.White;
				inputFuel();
			}

			return fuel;
		} //End inputFuel

		static double inputDistance(double fuel) {
			string input = String.Empty;
			double distance = 0;

			Console.Write("\nEnter the distance traveled in Kilometers: ");
			input = Console.ReadLine();

			if (!double.TryParse(input, out distance)) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Oops! " + input + " is not a number!");
				Console.ForegroundColor = ConsoleColor.White;
				inputDistance(fuel);
			}

			else if (distance < (8 * fuel)) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Oops! " + distance + " is blow the minimum distance of " + (8 * fuel) +"km");
				Console.ForegroundColor = ConsoleColor.White;
				inputDistance(fuel);
			}

			return distance;
		} //End inputDistance

		static void fuelConsumption(double fuel, double distance) {
			double consumptionKml = 0;
			double consumptionMpg = 0;

			consumptionKml = (fuel * 100) / distance;
			consumptionMpg = 282.48 * consumptionKml;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nYour fuel consumption rate is {0:F2}lt/100km", consumptionKml);
			Console.WriteLine("\twhich is equivilant to {0:F2}mpg", consumptionMpg);
			Console.ForegroundColor = ConsoleColor.White;
		} //End fuelConsumption

		static void reCalculate() {
			Console.Write("\nWould you like to run another calculation?  <Y/N>? ");

			while (true)
			{
				ConsoleKeyInfo result = Console.ReadKey();
				if (result.KeyChar == 'Y' || result.KeyChar == 'y') {
					Console.Clear();
					Main();
				}

				else if (result.KeyChar == 'N' || result.KeyChar == 'n') {
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("\n\nGoodbye!");
					System.Threading.Thread.Sleep(1000);
					System.Environment.Exit(1);
				}
			}
		} //End reCalculate
	}
}