using System;
using System.Windows.Forms;

namespace HareAndTortoise {
	partial class HareAndTortoiseForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.gameBoardPanel = new System.Windows.Forms.TableLayoutPanel();
			this.playersDataGridView = new System.Windows.Forms.DataGridView();
			this.playerTokenColourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hasWonDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.traceListBox = new System.Windows.Forms.ListBox();
			this.rollButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.playersLabel = new System.Windows.Forms.Label();
			this.numPlayersComboBox = new System.Windows.Forms.ComboBox();
			this.numPlayersLabel = new System.Windows.Forms.Label();
			this.titleLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.gameBoardPanel);
			this.splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel1_Paint);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.playersDataGridView);
			this.splitContainer.Panel2.Controls.Add(this.traceListBox);
			this.splitContainer.Panel2.Controls.Add(this.rollButton);
			this.splitContainer.Panel2.Controls.Add(this.exitButton);
			this.splitContainer.Panel2.Controls.Add(this.resetButton);
			this.splitContainer.Panel2.Controls.Add(this.playersLabel);
			this.splitContainer.Panel2.Controls.Add(this.numPlayersComboBox);
			this.splitContainer.Panel2.Controls.Add(this.numPlayersLabel);
			this.splitContainer.Panel2.Controls.Add(this.titleLabel);
			this.splitContainer.Size = new System.Drawing.Size(884, 662);
			this.splitContainer.SplitterDistance = 664;
			this.splitContainer.TabIndex = 0;
			// 
			// gameBoardPanel
			// 
			this.gameBoardPanel.AutoSize = true;
			this.gameBoardPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gameBoardPanel.ColumnCount = 7;
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.gameBoardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gameBoardPanel.Location = new System.Drawing.Point(0, 0);
			this.gameBoardPanel.Margin = new System.Windows.Forms.Padding(2);
			this.gameBoardPanel.Name = "gameBoardPanel";
			this.gameBoardPanel.RowCount = 8;
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.gameBoardPanel.Size = new System.Drawing.Size(664, 662);
			this.gameBoardPanel.TabIndex = 0;
			// 
			// playersDataGridView
			// 
			this.playersDataGridView.AutoGenerateColumns = false;
			this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerTokenColourDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn,
            this.hasWonDataGridViewCheckBoxColumn});
			this.playersDataGridView.DataSource = this.playerBindingSource;
			this.playersDataGridView.Location = new System.Drawing.Point(24, 109);
			this.playersDataGridView.Name = "playersDataGridView";
			this.playersDataGridView.RowHeadersVisible = false;
			this.playersDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.playersDataGridView.Size = new System.Drawing.Size(180, 155);
			this.playersDataGridView.TabIndex = 8;
			// 
			// playerTokenColourDataGridViewTextBoxColumn
			// 
			this.playerTokenColourDataGridViewTextBoxColumn.DataPropertyName = "PlayerTokenImage";
			this.playerTokenColourDataGridViewTextBoxColumn.HeaderText = "Colour";
			this.playerTokenColourDataGridViewTextBoxColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
			this.playerTokenColourDataGridViewTextBoxColumn.Name = "playerTokenColourDataGridViewTextBoxColumn";
			this.playerTokenColourDataGridViewTextBoxColumn.ReadOnly = true;
			this.playerTokenColourDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.playerTokenColourDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.playerTokenColourDataGridViewTextBoxColumn.Width = 40;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.Width = 60;
			// 
			// moneyDataGridViewTextBoxColumn
			// 
			this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
			this.moneyDataGridViewTextBoxColumn.HeaderText = "$";
			this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
			this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
			this.moneyDataGridViewTextBoxColumn.Width = 30;
			// 
			// hasWonDataGridViewCheckBoxColumn
			// 
			this.hasWonDataGridViewCheckBoxColumn.DataPropertyName = "HasWon";
			this.hasWonDataGridViewCheckBoxColumn.HeaderText = "Winner";
			this.hasWonDataGridViewCheckBoxColumn.Name = "hasWonDataGridViewCheckBoxColumn";
			this.hasWonDataGridViewCheckBoxColumn.ReadOnly = true;
			this.hasWonDataGridViewCheckBoxColumn.Width = 50;
			// 
			// playerBindingSource
			// 
			this.playerBindingSource.DataSource = typeof(Player_Class_Library.Player);
			// 
			// traceListBox
			// 
			this.traceListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.traceListBox.FormattingEnabled = true;
			this.traceListBox.Location = new System.Drawing.Point(13, 287);
			this.traceListBox.Name = "traceListBox";
			this.traceListBox.Size = new System.Drawing.Size(195, 251);
			this.traceListBox.TabIndex = 7;
			// 
			// rollButton
			// 
			this.rollButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rollButton.Location = new System.Drawing.Point(69, 591);
			this.rollButton.Name = "rollButton";
			this.rollButton.Size = new System.Drawing.Size(75, 23);
			this.rollButton.TabIndex = 6;
			this.rollButton.Text = "Roll Dice";
			this.rollButton.UseVisualStyleBackColor = true;
			this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(138, 627);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 5;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resetButton.Location = new System.Drawing.Point(3, 627);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 4;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// playersLabel
			// 
			this.playersLabel.AutoSize = true;
			this.playersLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playersLabel.Location = new System.Drawing.Point(69, 79);
			this.playersLabel.Name = "playersLabel";
			this.playersLabel.Size = new System.Drawing.Size(85, 27);
			this.playersLabel.TabIndex = 3;
			this.playersLabel.Text = "Players";
			// 
			// numPlayersComboBox
			// 
			this.numPlayersComboBox.FormattingEnabled = true;
			this.numPlayersComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.numPlayersComboBox.Location = new System.Drawing.Point(141, 50);
			this.numPlayersComboBox.Name = "numPlayersComboBox";
			this.numPlayersComboBox.Size = new System.Drawing.Size(32, 21);
			this.numPlayersComboBox.TabIndex = 2;
			this.numPlayersComboBox.SelectedIndexChanged += new System.EventHandler(this.numPlayersComboBox_SelectedIndexChanged);
			// 
			// numPlayersLabel
			// 
			this.numPlayersLabel.AutoSize = true;
			this.numPlayersLabel.Location = new System.Drawing.Point(42, 53);
			this.numPlayersLabel.Name = "numPlayersLabel";
			this.numPlayersLabel.Size = new System.Drawing.Size(93, 13);
			this.numPlayersLabel.TabIndex = 1;
			this.numPlayersLabel.Text = "Number of Players";
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.Red;
			this.titleLabel.Location = new System.Drawing.Point(11, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(193, 27);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Hare and Tortoise";
			// 
			// HareAndTortoiseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 662);
			this.Controls.Add(this.splitContainer);
			this.Name = "HareAndTortoiseForm";
			this.Text = "Hare and Tortoise";
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e) {

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.TableLayoutPanel gameBoardPanel;
		private ListBox traceListBox;
		private Button rollButton;
		private Button exitButton;
		private Button resetButton;
		private Label playersLabel;
		private ComboBox numPlayersComboBox;
		private Label numPlayersLabel;
		private Label titleLabel;
		private DataGridView playersDataGridView;
		private BindingSource playerBindingSource;
		private DataGridViewImageColumn playerTokenColourDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
		private DataGridViewCheckBoxColumn hasWonDataGridViewCheckBoxColumn;
	}
}

