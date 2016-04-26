// ---------------------------------------------------------------------------
// -----| Authors: Tylor Stewart (n9013555) and Nicholas Bensein (n9377859)
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square_Class_Library;

namespace Board_Class_Library {
	/// <summary>
	/// Models a game board consisting of different types of squares.
	/// </summary>
	public static class Board {
		// --------------------------------------------------
		// -----| Board | Constants.
		// --------------------------------------------------
		public const int START = 0;
		public const int FINISH = 55;
		public const int NUM_SQUARES = 54;  // Value doesn't include Start or Finish squares.
		public const int NUM_OF_ROWS = 8;
		public const int NUM_OF_COLUMNS = 7;

		private static readonly int[] SQUARES_WIN = { 5, 15, 25, 35, 45 };
		private static readonly int[] SQUARES_LOSE = { 10, 20, 30, 40, 50 };
		private static readonly int[] SQUARES_CHANCE = { 6, 12, 18, 24, 36, 42, 48, 54 };

		// --------------------------------------------------
		// -----| Board | Variables.
		// --------------------------------------------------
		private static Square[] gameBoard = new Square[NUM_SQUARES + 2];

		// --------------------------------------------------
		// -----| Board | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Setup the gameBoard with the approperate Square types.
		/// </summary>
		public static void SetUpBoard() {
			// Setup the Start and Finish Squares.
			gameBoard[0] = new Square("Start", START);
			gameBoard[55] = new Square("Finish", FINISH);
			
			// Loop through the remaining squares and set them up as nessicarry.
			for (int i = 1; i <= FINISH - 1; i++) {
				if (SQUARES_WIN.Contains(i)) {
					gameBoard[i] = new Win_Square(i.ToString(), i);
                } else if (SQUARES_LOSE.Contains(i)) {
					gameBoard[i] = new Lose_Square(i.ToString(), i);
				} else if (SQUARES_CHANCE.Contains(i)) {
					gameBoard[i] = new Chance_Square(i.ToString(), i);
				} else {
					gameBoard[i] = new Square(i.ToString(), i);
				}
            }
		} //end SetUpBoard

		/// <summary>
		/// Fetches the Square object associated with the provided square number.
		/// </summary>
		/// <param name="square">number of a square</param>
		/// <returns>square object</returns>
		public static Square GetBoardSquare(int square) {
			if (square < gameBoard.Length) {
				return gameBoard[square];
			} else {
				throw new Exception("Hold up fool! That squared doesn't exist.");
			}
		} //end GetBoardSquare

		/// <summary>
		/// Fetches the Start Square
		/// </summary>
		/// <returns>square object</returns>
		public static Square StartSquare() {
			return gameBoard[START];
		} //end StartSquare

		/// <summary>
		/// Fetches the next Square object associated from the provided square number.
		/// </summary>
		/// <param name="square">number of a square</param>
		/// <returns>square object</returns>
		public static Square NextSquare(int square) {
			if (square <= 54 && square >= 0) {
				return gameBoard[square + 1];
			} else {
				throw new Exception("You dun goofed son! The square you have indicated doesn't have a next square.");
			}
		} //end NextSquare
	}
}