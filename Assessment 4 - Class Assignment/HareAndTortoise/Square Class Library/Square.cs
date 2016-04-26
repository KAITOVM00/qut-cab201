// ---------------------------------------------------------------------------
// -----| Authors: Tylor Stewart (n9013555) and Nicholas Bensein (n9377859)
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player_Class_Library;
using Die_Class_Library;

namespace Square_Class_Library {
	/// <summary>
	/// A standard Square and the suberclass for Win_Square, Lose_Square and Chance_Square.
	/// </summary>
	public class Square {
		// --------------------------------------------------
		// -----| Square | Variables.
		// --------------------------------------------------
		private string name;
		private int number;

		// --------------------------------------------------
		// -----| Square | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// Standard Constructor. This will not be used.
		/// </summary>
		public Square() {
			throw new ArgumentException("Nah bro! The use of this constructor is invalid.");
		} //end Square

		/// <summary>
		/// Square Constructor builds a square with the provided name and number.
		/// </summary>
		/// <param name="name">name of the square</param>
		/// <param name="number">number of the square</param>
		public Square(string name, int number) {
			this.name = name;
			this.number = number;
		} //end Square

		// --------------------------------------------------
		// -----| Square | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Fetch the name of the square
		/// </summary>
		/// <returns>name of the square</returns>
		public string GetName() {
			return name;
		} //end GetName

		/// <summary>
		/// Fetch the number of the square
		/// </summary>
		/// <returns>number of the square</returns>
		public int GetNumber() {
			return number;
		} //end GetNumber

		/// <summary>
		/// Standard square has no effect on the player.
		/// </summary>
		/// <param name="who"></param>
		public virtual void EffectOnPlayer(Player who) {

		} //end EffectOnPlayer
	} //end class

	/// <summary>
	/// Win_Square is a subclass of Square.
	/// </summary>
	public class Win_Square : Square {
		// --------------------------------------------------
		// -----| Win_Square | Variables.
		// --------------------------------------------------
		// This is completely stupid as we already have dice in our H&T Game but apparently someone likes Circular Dependencies...
		public static Die dieOne = new Die();
		public static Die dieTwo = new Die();

		// --------------------------------------------------
		// -----| Win_Square | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// Constructs a Square that will add $15 to the players money and roll the dice again.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="number"></param>
		public Win_Square(string name, int number) : base(name, number) {

		} //end Win_Square

		// --------------------------------------------------
		// -----| Win_Square | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Add $15 to the players money and roll the dice again.
		/// </summary>
		/// <param name="who">player</param>
		public override void EffectOnPlayer(Player who) {
			// Add $15 to the players money.
			who.Add(15);

			// ReRoll the dice.
			who.rollDice(dieOne, dieTwo);
		} //end EffectOnPlayer
	} //end class

	/// <summary>
	/// Lose_Square is a subclass of Square.
	/// </summary>
	public class Lose_Square : Square {
		// --------------------------------------------------
		// -----| Lose_Square | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// Constructs a Square that will deduct $55 to the players money and move them back 3 squares.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="number"></param>
		public Lose_Square(string name, int number) : base(name, number) {

		} //end Lose_Square

		// --------------------------------------------------
		// -----| Lose_Square | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Deduct $55 to the players money and move them back 3 squares.
		/// </summary>
		/// <param name="who">player</param>
		public override void EffectOnPlayer(Player who) {
			// Deduct $25 from the players money.
			who.Deduct(25);

			// Move the player back 3 squares.
			who.MovePlayer(3);
		} //end EffectOnPlayer
	} //end class

	/// <summary>
	/// Chance_Square is a subclass of Square.
	/// </summary>
	public class Chance_Square : Square {
		// --------------------------------------------------
		// -----| Chance_Square | Variables.
		// --------------------------------------------------
		private Random rand = new Random();

		// --------------------------------------------------
		// -----| Chance_Square | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// Constructs a Square that will add $50 to or deduct $50 from the players money and move them back or foward 5 squares.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="number"></param>
		public Chance_Square(string name, int number) : base(name, number) {

		} //end Chance_Square

		// --------------------------------------------------
		// -----| Chance_Square | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Add $50 to or deduct $50 from the players money and move them back or foward 5 squares.
		/// </summary>
		/// <param name="who"></param>
		public override void EffectOnPlayer(Player who) {
			if (rand.Next(0, 2) == 0) {
				// Add $50 to the players money.
				who.Add(50);
				// Move the player foward 5 squares.
				who.MovePlayer(5);
			} else {
				// Deduct $50 from the players money.
				who.Deduct(50);
				// Move the player back 5 squares.
				who.MovePlayer(-5);
			}
		} //end EffectOnPlayer
	} //end class
}