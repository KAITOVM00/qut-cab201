// ---------------------------------------------------------------------------
// -----| Authors: Tylor Stewart (n9013555) and Nicholas Bensein (n9377859)
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Board_Class_Library;
using Square_Class_Library;
using Player_Class_Library;
using System.Diagnostics;
using System.Threading;

namespace HareAndTortoise {
	/// <summary>
	/// The form that displays the GUI for the game.
	/// </summary>
	public partial class HareAndTortoiseForm : Form {
		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Constants.
		// --------------------------------------------------
		const int NUM_OF_ROWS = 8;
		const int NUM_OF_COLUMNS = 7;

		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Variables.
		// --------------------------------------------------
		const int GUI_INDEX = 2;

		// Options to be used as parameters for methods.
		public enum playerUpdate {addPlayer, removePlayer};
		public enum rollDiceButton {enable, dissable};
		public enum comboBox { enable, dissable };

		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Constructors.
		// --------------------------------------------------
		/// <summary>
		/// HareAndTortoiseForm Constructor. This constructor will initialise the HareAndTortoiseForm with default values and have it ready for the game to begin.
		/// </summary>
		public HareAndTortoiseForm() {
            InitializeComponent();
            HareAndTortoiseGame.SetUpGame();
			ResizeGameBoard();
            SetUpGameBoard();
			SetupDataGrid();
			numPlayersComboBox.SelectedIndex = HareAndTortoiseGame.MAX_PLAYERS - GUI_INDEX;
			UpdatePlayerLocation(playerUpdate.addPlayer);
			Trace.Listeners.Add(new ListBoxTraceListener(traceListBox));
		} //end HareAndTortoiseForm

		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Methods.
		// --------------------------------------------------
		/// <summary>
		/// Resizes the game board to be approperate for our game.
		/// </summary>
		private void ResizeGameBoard() {
			const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
			int currentHeight = gameBoardPanel.Size.Height;
			int currentWidth = gameBoardPanel.Size.Width;
			int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
			int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
			int increaseInHeight = desiredHeight - currentHeight;
			int increaseInWidth = desiredWidth - currentWidth;
			this.Size += new Size(increaseInWidth, increaseInHeight);
			gameBoardPanel.Size = new Size(desiredWidth, desiredHeight);
		} //end ResizeGameBoard

		/// <summary>
		/// Setup the game board so as it's ready for the game to begin. This mapps Square Control objects to each square on the board.
		/// </summary>
		private void SetUpGameBoard() {
			int row, col;

			for (int i = 0; i <= Board.FINISH; i++) {
				SquareControl newSquare = new SquareControl(Board.GetBoardSquare(i), HareAndTortoiseGame.Players);

				MapSquareToTablePanel(Board.GetBoardSquare(i).GetNumber(), out row, out col);

				gameBoardPanel.Controls.Add(newSquare, col, row);

				if (i == Board.START || i == Board.FINISH) {
					newSquare.BackColor = Color.BurlyWood;
				}
			}
		} //end SetUpGameBoard

		/// <summary>
		/// Initalise the DataGrid with the correct DataSource.
		/// </summary>
		private void SetupDataGrid() {
			playersDataGridView.AutoGenerateColumns = false;
			playersDataGridView.DataSource = HareAndTortoiseGame.Players;
		} //end SetupDataGrid

		/// <summary>
		/// Updates the players location (add or remove) based on their current location.
		/// </summary>
		/// <param name="playerUpdate">enum - addPlayer or removePlayer</param>
		public void UpdatePlayerLocation(playerUpdate playerUpdate) {
			for (int i = 0; i < HareAndTortoiseGame.numOfPlayers; i++) {
				// Get the players current location.
				int playerLocation = GetSquareNumberOfPlayer(i);

				// Get the SquareControl for the square the player is currently on.
				SquareControl squareControl = GetSquareControl(playerLocation);

				// Update (add or remove) the ContainsPlayers for the fetched SquareControl.
				if (playerUpdate == playerUpdate.addPlayer && i < HareAndTortoiseGame.numOfPlayers) {
					squareControl.ContainsPlayers[i] = true;
				} else if (playerUpdate == playerUpdate.removePlayer && i < HareAndTortoiseGame.numOfPlayers) {
					squareControl.ContainsPlayers[i] = false;
				}
			}

			// Redisplay the GUI Board.
			RefreshBoard();
        } //end UpdatePlayerLocation

		/// <summary>
		/// Outputs details of each player to the ListBox.
		/// </summary>
		private void OutputPlayersDetails() {
			HareAndTortoiseGame.OutputAllPlayerDetails();
			traceListBox.Items.Add("");
			traceListBox.SelectedIndex = traceListBox.Items.Count - 1;
		} //end OutputPlayersDetails

		/// <summary>
		/// Updates the DataGrid to display the current data.
		/// </summary>
		public static void UpdateDataGrid() {
			HareAndTortoiseGame.Players.ResetBindings();
		} //end UpdateDataGrid

		/// <summary>
		/// Forcefully clears all player tokens from the game board.
		/// </summary>
		private void ClearTokensGameBoard() {
			for (int i = 0; i < Board.FINISH; i++) {
				for (int j = 0; j < HareAndTortoiseGame.MAX_PLAYERS; j++) {
					GetSquareControl(i).ContainsPlayers[j] = false;
				}
			}
		} //end ClearTokensGameBoard

		/// <summary>
		/// Provides easy ability to enable or dissable the Roll Dice Button.
		/// </summary>
		/// <param name="option">enum - enable or dissable</param>
		public void RollDiceButton(rollDiceButton option) {
			if (option == rollDiceButton.enable) rollButton.Enabled = true;
			else if (option == rollDiceButton.dissable) rollButton.Enabled = false;
		} //end RollDiceButton

		/// <summary>
		/// Provides easy ability to enable or dissable the Number of PLayers ComboBox.
		/// </summary>
		/// <param name="option">enum - enable or dissable</param>
		public void ComboBox(comboBox option) {
			if (option == comboBox.enable) numPlayersComboBox.Enabled = true;
			else if (option == comboBox.dissable) numPlayersComboBox.Enabled = false;
		} //end ComboBox

		/// <summary>
		/// Resets the game to default locations and values.
		/// </summary>
		private void ResetGame() {
			ClearTokensGameBoard();
			UpdatePlayerLocation(playerUpdate.removePlayer);
			HareAndTortoiseGame.ResetPlayerData();
			UpdatePlayerLocation(playerUpdate.addPlayer);
			RefreshBoard();
			UpdateDataGrid();
			SetupDataGrid();
			ClearListBox();

			HareAndTortoiseGame.GameFinished = false;

			ComboBox(comboBox.enable);
			RollDiceButton(rollDiceButton.enable);
		} //end ResetGame

		/// <summary>
		/// Animated variant of UpdatePlayerLocation.
		/// </summary>
		private void UpdatePlayerLocationAnimated() {
			// Get the current location of our players.
			int[] posStart = PlayerPositions();

			// Play a round of the game.
			HareAndTortoiseGame.PlayOneRound();

			// Get the current location of our players.
			int[] posFinish = PlayerPositions();

			for (int i = 0; i < HareAndTortoiseGame.MAX_PLAYERS; i++) {
				// Calculate the total number of squares the player needs to move.
				int squaresToMove = posFinish[i] - posStart[i];

				// Fetch the square that the player ended up on.
				SquareControl control = GetSquareControl(posFinish[i]);

				if (i < HareAndTortoiseGame.numOfPlayers) {
					// Move each of our players individually the required number of squares.
					for (int j = 0; j <= squaresToMove; j++) {
						// Remove the player from their current square and add them to the next.
						control.ContainsPlayers[i] = false;
						control = GetSquareControl(posStart[i] + j);
						control.ContainsPlayers[i] = true;

						// Animation Magic.
						RefreshBoard();
						Application.DoEvents();
						Thread.Sleep(100);
					}
				} else {
					control.ContainsPlayers[i] = false;
				}
			}
		} //end UpdatePlayerLocationAnimated

		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Helper Methods.
		// --------------------------------------------------
		/// <summary>
		/// Returns the approperate Row and Column for the specefied Square to be mapped to the Board.
		/// </summary>
		/// <param name="squareNumber">Number representing the square on the board</param>
		/// <param name="row">Row on the Board</param>
		/// <param name="col">Column on the Board</param>
		private void MapSquareToTablePanel(int squareNumber, out int row, out int col) {
			row = NUM_OF_ROWS - (squareNumber / NUM_OF_COLUMNS) - 1;

			if (row % 2 == 1) {
				col = squareNumber % NUM_OF_COLUMNS;
			} else {
				col = NUM_OF_COLUMNS - (squareNumber % NUM_OF_COLUMNS + 1);
			}
		}//end MapSquareToTablePanel

		/// <summary>
		/// Fetches the number of the square a player currently resides on.
		/// </summary>
		/// <param name="playerNumber">Number of the Player</param>
		/// <returns>Number of the Square</returns>
		private int GetSquareNumberOfPlayer(int playerNumber) {
			Square playerSquare = HareAndTortoiseGame.Players[playerNumber].Location;
			return playerSquare.GetNumber();
		} //end GetSquareNumberOfPlayer

		/// <summary>
		/// Fetches the Square Control for the square.
		/// </summary>
		/// <param name="squareNumber">Number of a Square</param>
		/// <returns>Square Control object</returns>
		private SquareControl GetSquareControl(int squareNumber) {
			int row, col;

			MapSquareToTablePanel(squareNumber, out row, out col);

			return (SquareControl) gameBoardPanel.GetControlFromPosition(col, row);
		} //end GetSquareControl

		/// <summary>
		/// Refreshes the Game Board.
		/// </summary>
		private void RefreshBoard() {
			gameBoardPanel.Invalidate(true);
		} //end RefreshBoard

		/// <summary>
		/// Clears all items from the ListBox.
		/// </summary>
		private void ClearListBox() {
			traceListBox.Items.Clear();
		} //end ClearListBox

		/// <summary>
		/// Fetches a location for each player.
		/// </summary>
		/// <returns>Array of Player locations</returns>
		private int[] PlayerPositions() {
			int[] playerPos = new int[HareAndTortoiseGame.MAX_PLAYERS];
			for (int i = 0; i < HareAndTortoiseGame.MAX_PLAYERS; i++) playerPos[i] = GetSquareNumberOfPlayer(i);
			return playerPos;
		} //end PlayerPositions

		// --------------------------------------------------
		// -----| Hare and Tourtoise Form | Event Handlers.
		// --------------------------------------------------
		private void numPlayersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			HareAndTortoiseGame.numOfPlayers = numPlayersComboBox.SelectedIndex + GUI_INDEX;
			ResetGame();
		} //end numPlayersComboBox_SelectedIndexChanged

		private void rollButton_Click(object sender, EventArgs e) {
			// Dissable the Roll Dice button.
			RollDiceButton(rollDiceButton.dissable);

			// Dissable the ComboBox to select the number of players.
			ComboBox(comboBox.dissable);

			// This is our old round code. It's not used anymore but I wanted to leave it here to show it was done.
			/*
			// Remove the player from their current location on the Game Board.
			//UpdatePlayerLocation(playerUpdate.removePlayer);
			//
			// Play one round of the Hare and Tourtoise Game.
			//HareAndTortoiseGame.playOneRound();
			//
			// Add the player to their new location on the Game Board.
			//UpdatePlayerLocation(playerUpdate.addPlayer);
			*/

			// Play one round of the Hare and Tourtoise Game, Animated Style!
			UpdatePlayerLocationAnimated();

			// Log to the traceListBox.
			OutputPlayersDetails();

			// If the game is not finished, enable the Roll Dice Button.
			if (!HareAndTortoiseGame.GameFinished) RollDiceButton(rollDiceButton.enable);
		} //end rollButton_Click

		private void resetButton_Click(object sender, EventArgs e) {
			ResetGame();
        } //end resetButton_Click

		private void exitButton_Click(object sender, EventArgs e) {
			DialogResult dialogResult = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes) Environment.Exit(0);
		} //end exitButton_Click
	} //end class
} //end namespace