using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_Calculator {
	/*
	* Author: Tylor Stewart
	* Student Number: n9013555
	* Description: This BMI Calculator takes input of the users Weight and Height to output their BMI and Weight Category.
	*/
	public partial class BMI_Calculator : Form {
		/// <summary>
		/// Verify the UserInput for the Weight is a number which is greater than or equal to 45.
		/// </summary>
		/// <param name="userInput">Users Weight in Kilograms</param>
		/// <returns>Boolean dependant on result</returns>
		static bool VerifyWeight(string userInput) {
			// Verify the Users Input.
			int weight;
			bool result = int.TryParse(userInput, out weight);

			// Display Error Message if needed.
			if (!result) {
				MessageBox.Show("Oops! The value you entered for Weight isn't a number...");
				return false;
			} else if (weight >= 45) {
				return true;
			} else {
				MessageBox.Show("Oh no! Your weight must be greater than or equal to 45kg.");
				return false;
			}
		} //end VerifyWeight

		/// <summary>
		/// Verify the UserInput for the Height is a number which is greater than or equal to 1.20 and less than or equal to 2.70.
		/// </summary>
		/// <param name="userInput">Users Height in Meters</param>
		/// <returns>Boolean dependant on result</returns>
		static bool VerifyHeight(string userInput) {
			// Verify the Users Input.
			double height;
			bool result = double.TryParse(userInput, out height);

			// Display Error Message if needed.
			if (!result) {
				MessageBox.Show("Oops! The value you entered for Height isn't a number...");
				return false;
			} else if (height >= 1.20 && height <= 2.70) {
				return true;
			} else {
				MessageBox.Show("Oh no! Your height must be greater than or equal to 1.20m and less than or equal to 2.70m.");
				return false;
			}
		} //end VerifyHeight

		/// <summary>
		/// Calculate the Users BMI, given their Weight and Height.
		/// </summary>
		/// <param name="weight">Users Weight</param>
		/// <param name="height">Users Height</param>
		/// <returns>Users BMI</returns>
		static double CaclulateBMI(double weight, double height) {
			return weight / Math.Pow(height, 2);
        } //end CaclulateBMI

		/// <summary>
		/// Weight Category based on the Users BMI
		/// </summary>
		/// <param name="bmi">Users BMI</param>
		/// <returns>Users Weight Category</returns>
		static string bmiCategory(double bmi) {
			string category = String.Empty;

			if (bmi < 18.5) {
				category = "Underweight";
			} else if (bmi >= 18.5 && bmi <= 24.99) {
				category = "Healthy";
			}
			else if (bmi >= 25 && bmi <= 29.99) {
				category = "Overweight";
			}
			else if (bmi >= 30) {
				category = "Obese";
			}

			return category;
		} //end bmiCategory

		public BMI_Calculator() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void label1_Click(object sender, EventArgs e) {

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e) {
			// Clear the Weight and Height TextBoxes.
			inputWeight.Clear();
			inputHeight.Clear();

			// Make the Weight TextBox the new Focus.
			inputWeight.Focus();

			// Make the 'Another Calculation' GroupBox visible.
			AnotherCalculation.Visible = false;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e) {
			// Diaplay an exit message.
			MessageBox.Show("That's all folks!");

			// Exit the Application.
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e) {
			// Check if the Weight and Height Input is valid.
			if (VerifyWeight(inputWeight.Text) && VerifyHeight(inputHeight.Text)) {
				// Calculate the Users BMI.
				double bmi = CaclulateBMI(Convert.ToDouble(inputWeight.Text), Convert.ToDouble(inputHeight.Text));

				// Get the BMI Category.
				string category = bmiCategory(bmi).ToString();

				// Display the Users BMI and Weight Category.
				MessageBox.Show(String.Format("Your BMI is {0:F2} and therefore you're {1}.", bmi, category));

				// Make the 'Another Calculation' GroupBox visible.
				AnotherCalculation.Visible = true;
			}
		}
	}
}