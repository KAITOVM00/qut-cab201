// ---------------------------------------------------------------------------
// -----| Authors: Tylor Stewart (n9013555) and Nicholas Bensein (n9377859)
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board_Class_Library;
using Player_Class_Library;
using Square_Class_Library;
using System.Drawing;
using Die_Class_Library;
using System.Diagnostics;

namespace HareAndTortoise {
	/// <summary>
	/// Plays the game called Hare and Tortoise.
	/// </summary>
	public static class HareAndTortoiseGame {
		// --------------------------------------------------
		// -----| Hare and Tourtoise Game | Constants.
		// --------------------------------------------------
		private const int MIN_PLAYERS = 2;
		public const int MAX_PLAYERS = 6;

		// --------------------------------------------------
		// -----| Hare and Tourtoise Game | Variables.
		// --------------------------------------------------
		public static bool gameFinished;
        public static bool GameFinished {
			get {
				return gameFinished;
			}
			set {
				gameFinished = value;
            }
		} //end GameFinished

		public static int numOfPlayers = 6;

		private static string[] defaultNames = { "One", "Two", "Three", "Four", "Five", "Six" };

		private static Brush[] PlayerTokenColours = new Brush[] { Brushes.Black, Brushes.Red, Brushes.Gold, Brushes.GreenYellow, Brushes.Fuchsia, Brushes.BlueViolet };

		private static BindingList<Player> players = new BindingList<Player>();
		public static BindingList<Player> Players {
			get {
				return players;
			}
		} //end Players

		public static Die dieOne = new Die();
		public static Die dieTwo = new Die();

		// --------------------------------------------------
		// -----| Hare and Tourtoise Game | Methods.
		// --------------------------------------------------
		public static void SetUpGame() {

			Board.SetUpBoard();

			InitialisePlayers();

			//more code to be added later
		} // end SetUpGame

		/// <summary>
		/// Initialises the players and populates the Players binding list.
		/// </summary>
		public static void InitialisePlayers() {
			for (int i = 0; i < MAX_PLAYERS; i++) {
				players.Add(new Player(defaultNames[i], Board.GetBoardSquare(Board.START)));
				players[i].PlayerTokenColour = PlayerTokenColours[i];
            }
		} //end InitialisePlayers

		/// <summary>
		/// Resets all data associated with each player.
		/// </summary>
		public static void ResetPlayerData() {
			for (int i = 0; i < MAX_PLAYERS; i++) {
				players[i].Name = defaultNames[i];
				players[i].Money = Player.DEFAULT_MONEY;
				players[i].HasWon = false;
				players[i].Location = Board.StartSquare();
            }
		} //end ResetPlayerData

		/// <summary>
		/// Plays one round of the Game.
		/// </summary>
		public static void PlayOneRound() {
			for (int i = 0; i < numOfPlayers; i++) {
				players[i].rollDice(dieOne, dieTwo);
				players[i].Location.EffectOnPlayer(players[i]);
            }

			if (IsFinished()) FindWinner();

			HareAndTortoiseForm.UpdateDataGrid();
		} //end playOneRound

		/// <summary>
		/// Checks each players location against the Finish square.
		/// </summary>
		/// <returns>true if a player is on the Finish square</returns>
		public static bool IsFinished() {
			for (int i = 0; i < numOfPlayers; i++) {
				if (players[i].Location.GetNumber() == Board.FINISH) GameFinished = true;
            }

			return GameFinished;
		} //end IsFinished

		/// <summary>
		/// Finds the winner/s based on their money and position on the Board.
		/// </summary>
		public static void FindWinner() {
			int maxMoney = 0, maxSquare = 0;

			// Find the maximum money value from all of the players.
			for (int i = 0; i < numOfPlayers; i++) {
				maxMoney = (players[i].Money > maxMoney) ? players[i].Money : maxMoney;
			}

			// Find the maximumsquarevalue from all of the players
			for (int i = 0; i < numOfPlayers; i++) {
				//maxSquare = (players[i].Money == maxMoney) ? (players[i].Location.GetNumber() > maxSquare) ? players[i].Location.GetNumber() : maxSquare : maxSquare;

				if (players[i].Money == maxMoney) {
					if (players[i].Location.GetNumber() > maxSquare) {
						maxSquare = players[i].Location.GetNumber();
					}
				}
			}

			// The players with both of the above are our winners.
			for (int i = 0; i < numOfPlayers; i++) {
				players[i].HasWon = (players[i].Money == maxMoney && players[i].Location.GetNumber() == maxSquare) ? true : false;
			}

			//TODO: There has to be a cleaner way to do this...
		} //end FindWinner

		/// <summary>
		/// Calls OutputIndividualDetails() for each player.
		/// </summary>
		public static void OutputAllPlayerDetails() {
			for (int i = 0; i < numOfPlayers; i++) {
				OutputIndividualDetails(Players[i]);
			}
		} //end OutputAllPlayerDetails

		/// <summary>
		/// Outputs a player's current location and amount of money
		/// pre: player's object to display
		/// post: displayed the player's location and amount
		/// </summary>
		/// <param name="who">the player to display</param>
		public static void OutputIndividualDetails(Player who) {
			Square playerLocation = who.Location;
			Trace.WriteLine(String.Format("Player {0} on square {1} with {2:C}",
			who.Name, playerLocation.GetName(), who.Money));
		} //end OutputIndividualDetails

		// --------------------------------------------------
		// -----| Hare and Tourtoise Game | Helper Methods.
		// --------------------------------------------------
		/// <summary>
		/// Fetches the number of the square a player currently resides on.
		/// </summary>
		/// <param name="playerNumber">Number of the Player</param>
		/// <returns>Number of the Square</returns>
		private static int GetSquareNumberOfPlayer(int playerNumber) {
			Square playerSquare = HareAndTortoiseGame.Players[playerNumber].Location;
			return playerSquare.GetNumber();
		} //end GetSquareNumberOfPlayer
	}//end class
}//end namespace
