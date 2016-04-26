using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Assignment {
    class Program {
        enum Months {January = 1, February, March, April, May, June, July, August, September, October, November, December};
        static int[] daysInMonth = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        const int MONTHS_IN_YEAR = 12;
		static Random randomValue = new Random(10);

		static void Main() {
			// Change the Console Window Size.
			Console.SetWindowSize(80, 41);

			// Provided Rainfall Data Array.
			int[][] rainfall = new int[MONTHS_IN_YEAR] [];
			
			// Welcome Message
            Welcome();
			
			// Generate rainfall rata and display initial report.
			GenRainfall(rainfall);
			DisplayRainfallYear(rainfall);

			// User Input and Calculations for Monthly Rainfall Stats.
			int month = InputRainfallMonth();
			Tuple<int, int> rainDays = CalculateRainDays(rainfall, month);
			Tuple<int, int> rainMax = CalculateRainMax(rainfall, month);
			int rainTotal = CalculateRainTotal(rainfall, month);
            double rainAverage = CalculateRainAverage(rainfall, month, rainTotal);
            DisplayRainfallMonth(month, rainDays, rainMax, rainTotal, rainAverage);

			// Reprompt the user to select another month or quit.
			RepromptRainfallMonth(rainfall);
        }//end Main

		/// <summary>
		/// Clear unnecessary text from the Console below the Yearly Rainfall Report and relocate the cursor.
		/// </summary>
		static void ClearConsole() {
			// Goto the starting position, after the Yearly Rainfall Report.
			Console.SetCursorPosition(0, 39);

			// Clear 10 lines below the starting position.
			for (int i = 0; i < 10; i++) {
				Console.WriteLine(new string(' ', Console.WindowWidth - 1));
			}

			// Return to the origional starting position.
			Console.SetCursorPosition(0, 39);

			// Return the Console to the top of the window.
			Console.SetWindowPosition(0, 0);
		}

		/// <summary>
		/// Welcome Message
		/// </summary>
        static void Welcome() {
			// Display a nice Welcome Message
			string welcomeMessage = "| Welcome to the Yearly Rainfall Report |";
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("\n" + welcomeMessage.PadLeft((Console.WindowWidth / 2) + (welcomeMessage.Length / 2)));
			Console.ForegroundColor = ConsoleColor.White;
		}//end Welcome

		/// <summary>
		/// Generate Rainfall Data and populate the rainfall Array.
		/// </summary>
		/// <param name="rainfall"></param>
		static void GenRainfall(int[][] rainfall) {
			// For every Month in the Year.
			for (int m = 0; m < MONTHS_IN_YEAR; m++) {
				// Use the Days in a Month as indexes.
				rainfall[m] = new int[daysInMonth[m]];
				// For every Day in the Month.
				for (int d=0; d < rainfall[m].Length; d++) {
					// Did it rain today? Generate a Rainfall value between 1 and 27 inclusive.
					rainfall[m][d] = (DidItRain()) ? randomValue.Next(1, 28) : 0;
                }
            }
		} //end genRainfall

		/// <summary>
		/// Did it rain on a iven day? There is a 25% change it did!
		/// </summary>
		/// <returns>True or False</returns>
		static bool DidItRain() {
			// Generate a Random Number between 0 and 3.
			int rainCheck = randomValue.Next(4); ;
			// Simulate a 25% change of Rainfall.
			return rainCheck == 0;
        }//end didItRain

		/// <summary>
		/// Displays Yearly Rainfall Data
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		static void DisplayRainfallYear(int[][] rainfall) {
			// For every Month in the Year.
			for (int i = 0; i < MONTHS_IN_YEAR; i++) {
				// Display the Month and Number of Days.
				Months month = (Months)i + 1;
				Console.WriteLine("\n\n " + month + ": " + rainfall[i].Length + " days");
				Console.Write("  ");
				// For every Day in the Month.
                for (int j = 0; j < rainfall[i].Length; j++) {
					// If it has rained, Display Rainfall Ammount.
                    if (rainfall[i][j] != 0) {
						Console.Write(rainfall[i][j].ToString().PadLeft(2) + " ");
					}
				}
			}
		}//end displayRainfallYear

		/// <summary>
		/// Prompt the user to input a number to correspond to a month. Handle invalid input with and overloaded method.
		/// </summary>
		/// <returns>Valid User Input</returns>
		static int InputRainfallMonth() {
			// Clear unnecessary text from the console and resize the window to display the new text. 
			ClearConsole();
			Console.SetWindowSize(80, 41);

			// Prompt the user for input.
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.Write(" Enter a value between 1 and " + MONTHS_IN_YEAR + " which corresponds to a month of the year: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			string input = Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.White;

			// Check users input is valid.
			int month;
			bool result = int.TryParse(input, out month);

			if (!result || month <= 0 || month > MONTHS_IN_YEAR) {
				month = InputRainfallMonth(input);
			}

			return month - 1;
		}//end inputRainfallMonth

		/// <summary>
		/// Display an invalid input error and re-prompt the user for input.
		/// </summary>
		/// <param name="inputOld">Old input string</param>
		/// <returns>Valid User Input</returns>
		static int InputRainfallMonth(string inputOld) {
			// Clear unnecessary text from the console and resize the window to display the new text. 
			ClearConsole();
			Console.SetWindowSize(80, 43);

			// Display error and re-prompt the user for input.
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(" Oops! " + inputOld + " doesn't correspond to a month of the year!");
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.Write("\n Enter a value between 1 and " + MONTHS_IN_YEAR + " which corresponds to a month of the year: ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			string input = Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.White;

			// Check users new input is valid.
			int month;
			bool result = int.TryParse(input, out month);

			if (!result || month <= 0 || month > MONTHS_IN_YEAR) {
				month = InputRainfallMonth(input);
			}

			return month;
		}//end inputRainfallMonth

		/// <summary>
		/// Calculates the number of Days it has rained during the given Month.
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		/// <param name="month">User selected Month</param>
		/// <returns>Days of and not of rain in Month as Tuple</returns>
		static Tuple<int, int> CalculateRainDays(int[][] rainfall, int month) {
			int rainDays = 0;

			// Keep a tally of the days that it has rained in rainDays.
			for (int i = 0; i < rainfall[month].Length; i++) {
				if (rainfall[month][i] > 0) { rainDays++; }
			}

			// Days it hasn't rained = Days in Month - Days it has Rained.
			int rainDaysNot = rainfall[month].Length - rainDays;

			return Tuple.Create(rainDays, rainDaysNot);
		}//end calculateRainDays

		/// <summary>
		/// Calculates and Returns the Maximum Rainfall on a single day of the given Month.
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		/// <param name="month">User selected Month</param>
		/// <returns>Maximum Rainfall value and Day in a Tuple</returns>
		static Tuple<int, int> CalculateRainMax(int[][] rainfall, int month)
		{
			int rainMax = 0;
			int rainMaxDay = 0;

			// Check if each days rainfall is the new rainMax and save that day to rainMaxDay.
			for (int i = 0; i < rainfall[month].Length; i++)
			{
				if (rainfall[month][i] > rainMax) {
					rainMax = rainfall[month][i];
					rainMaxDay = i + 1;
                }
			}

			return Tuple.Create(rainMax, rainMaxDay);
		}//end calculateRainMax

		/// <summary>
		/// Calculates and Returns the Total Rainfall of the given Month.
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		/// <param name="month">User selected Month</param>
		/// <returns>Total Rianfall of Month</returns>
		static int CalculateRainTotal(int[][] rainfall, int month) {
			int rainTotal = 0;

			// Add rainfall for each day of the month to rainTotal.
			for (int i = 0; i < rainfall[month].Length; i++) {
				rainTotal += rainfall[month][i];
			}

			return rainTotal;
		}//end calculateRainTotal

		/// <summary>
		/// Calculates the Average Rainfall of the given Month.
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		/// <param name="month">User selected Month</param>
		/// <param name="total">Total Rainfall of given Month</param>
		/// <returns>Average Rainfall for the Month</returns>
		static double CalculateRainAverage(int[][] rainfall, int month, int total) {
			// Average Rainfall = Total Rainfall / Days in Month
			double rainAverage = (double)total / (double)rainfall[month].Length;
            return rainAverage;
		}//end calculateRainAverage

		/// <summary>
		/// Reprompt the user to select another month.
		/// </summary>
		/// <param name="rainfall"></param>
		static void RepromptRainfallMonth(int[][] rainfall) {
			// Prompt the user for input.
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write("\n Press <Y> to select another month or <N> to quit...");
			Console.ForegroundColor = ConsoleColor.White;

			ConsoleKeyInfo input;

			do {
				input = Console.ReadKey(true);

				// Evaluate the Users response.
				if (input.Key == ConsoleKey.Y)
				{
					LetsDoEverythingAgainBecauseMikeSaidSomethingOnFacebook(rainfall);
				}
				else if (input.Key == ConsoleKey.N)
				{
					System.Environment.Exit(1);
				}
			} while (input.Key != ConsoleKey.Y || input.Key != ConsoleKey.N);
		}//end RepromptRainfallMonth

		/// <summary>
		/// It's not mentioned anywhere in the assignment spec or the CRA but Mike said on Facebook that
		/// we needed to allow the user to select a new month to display over and over so here it is...
		/// </summary>
		/// <param name="rainfall">Array of Rainfall data</param>
		static void LetsDoEverythingAgainBecauseMikeSaidSomethingOnFacebook(int[][] rainfall)
		{
			// User Input and Calculations for Monthly Rainfall Stats.
			int month = InputRainfallMonth();
			Tuple<int, int> rainDays = CalculateRainDays(rainfall, month);
			Tuple<int, int> rainMax = CalculateRainMax(rainfall, month);
			int rainTotal = CalculateRainTotal(rainfall, month);
			double rainAverage = CalculateRainAverage(rainfall, month, rainTotal);
			DisplayRainfallMonth(month, rainDays, rainMax, rainTotal, rainAverage);

			// Reprompt the user to select another month or quit.
			RepromptRainfallMonth(rainfall);
		}//end LetsDoEverythingAgainBecauseMikeSaidSomethingOnFacebook

		/// <summary>
		/// Final output for the program. Takes all of the previous calculations and outputs statistics relivant to the selected month.
		/// </summary>
		/// <param name="month">Selected Month</param>
		/// <param name="rainDays">Number of days it rained in the month</param>
		/// <param name="rainMax">Maximum rainfall (mm)</param>
		/// <param name="rainTotal">Total rainfall (mm)</param>
		/// <param name="rainAverage">Average rainfall (mm)</param>
		static void DisplayRainfallMonth(int month, Tuple<int, int> rainDays, Tuple<int, int> rainMax, int rainTotal, double rainAverage) {
			// Clear unnecessary text from the console and resize the window to display the new text.
			ClearConsole();
			Console.SetWindowSize(80, 48);

			// Fetch the name of the Month from our enum Array.
			Months rainMonth = (Months)month + 1;

			// Create an Ordinal Indicator to be used when displaying the date on which the maximum rainfall occurred.
			string ordinal = (rainMax.Item2 == 1) ? "st" : (rainMax.Item2 == 2) ? "nd" : (rainMax.Item2 == 3) ? "rd" : (rainMax.Item2 == 21) ? "st" : (rainMax.Item2 == 22) ? "nd" : (rainMax.Item2 == 23) ? "rd" : (rainMax.Item2 == 31) ? "st" : "th";

			// Output the users selection of Month and some interesting rainfall stats associated with that month.
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(" You have selected {0}! Here are some interesting rainfall stats:", rainMonth);
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\n There were {0} days without rain in the month of {1} and {2} with rain.", rainDays.Item2, rainMonth, rainDays.Item1);
			Console.WriteLine(" The maximum amount of rain on a single day was {0}mm.", rainMax.Item1);
			Console.WriteLine(" That rainfall occurred on the {0}{1} of {2}.", rainMax.Item2, ordinal, rainMonth);
			Console.WriteLine(" The average rainfall for the month of " + rainMonth + " was {0:F2}mm.", rainAverage);
        }//end displayRainfallMonth
    }//end class
}//end namespace