// ---------------------------------------------------------------------------
// -----| Authors: Tylor Stewart (n9013555) and Nicholas Bensein (n9377859)
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Square_Class_Library;
using Die_Class_Library;
using Board_Class_Library;

namespace Player_Class_Library {
	/// <summary>
	/// Models a player who currently has a certain amount of money and is located on a particular square.
	/// </summary>
	public class Player {
		// --------------------------------------------------
		// -----| Player | Constants.
		// --------------------------------------------------
		public const int DEFAULT_MONEY = 100;

		// --------------------------------------------------
		// -----| Player | Variables.
		// --------------------------------------------------
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		private int money;
		public int Money {
			get {
				return money;
			}
			set {
				money = value;
			}
		}

		private bool hasWon;
		public bool HasWon {
			get {
				return hasWon;
			}
			set {
				hasWon = value;
			}
		}

		private Square location;
		public Square Location {
			get {
				return location;
			}
			set {
				location = value;
			}
		}

		private Image playerTokenImage;
		public Image PlayerTokenImage {
			get {
				return playerTokenImage;
            }
		}

		private Brush playerTokenColour;
		public Brush PlayerTokenColour {
			get {
				return playerTokenColour;
			}
			set {
				playerTokenColour = value;
				playerTokenImage = new Bitmap(1, 1);
				using (Graphics g = Graphics.FromImage(playerTokenImage)) {
					g.FillRectangle(playerTokenColour, 0, 0, 1, 1);
				}
			}
		}


		// --------------------------------------------------
		// -----| Player | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// Standard Player Constructor. This will not be used.
		/// </summary>
		public Player() {
			throw new ArgumentException("Nah bro! The use of this constructor is invalid.");
		}

		/// <summary>
		/// Player Constructor used to contruct a Player object.
		/// </summary>
		/// <param name="name">Name of the Player</param>
		/// <param name="square">Square where player is to be located</param>
		public Player(string name, Square square) {
			this.name = name;
			money = DEFAULT_MONEY;
			hasWon = false;
            location = square;
		}

		// --------------------------------------------------
		// -----| Player | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Moves the player a specified number of squares.
		/// </summary>
		/// <param name="numSquares">number of squares to move the player</param>
		public void MovePlayer(int numSquares) {
			int newLocation = (location.GetNumber() + numSquares);
			if (newLocation > Board.FINISH) newLocation = Board.FINISH;
			location = Board.GetBoardSquare(newLocation);
		} //end MovePlayer

		/// <summary>
		/// Rolls the provided Dice and moves the player the number of squares returned from the dice.
		/// </summary>
		/// <param name="dieOne">Die object used to generate a number</param>
		/// <param name="dieTwo">Die object used to generate a number</param>
		public void rollDice(Die dieOne, Die dieTwo) {
			int numSquares = dieOne.Roll() + dieTwo.Roll();
			MovePlayer(numSquares);
		}

		/// <summary>
		/// Adds an amount to the players money.
		/// </summary>
		/// <param name="amount">amount of money to add</param>
		public void Add(int amount) {
			money += amount;
        } //end Add

		/// <summary>
		/// Deducts an amount to the players money.
		/// </summary>
		/// <param name="amount">amount of money to deduct</param>
		public void Deduct(int amount) {
			money = (money - amount < 0) ? 0 : money - amount;
		}  //end Deduct
	}
}