using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinesweeperProject.Architecture.DynamicLinkage;
using MinesweeperProject.Architecture.Factory;
using MinesweeperProject.Architecture.Observer;

namespace MinesweeperProject
{
    public partial class Form1 : Form {

        private GameMode _gameMode;
        
        public Form1()
        {
            InitializeComponent();
            resizeWindow(8);
            IGeneratorFactory factory = new GeneratorFactory();
            _gameMode = new GameInstance(factory);
            IBoard board = new Board(_gameMode);
            _gameMode.MineCountField = textBox2;
            _gameMode.TimerField = textBox1;
            _gameMode.GenerateBoard(panel1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ToolbarHelp_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            
        }

        private void doTheSweepToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Minesweeper_(video_game)");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void resizeWindow(int size) {
            panel1.Size = new Size(30 * size, 30 * size);
            Size = new Size(panel1.Left + 30 * size + 20, panel1.Top + (30 * size) + 40);
            ResetButton.Left = Size.Width / 2 - 16;
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e) {
            _gameMode.SetDifficulty(Difficulty.Beginner);
            resizeWindow(8);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e) {
            _gameMode.SetDifficulty(Difficulty.Intermediate);
            resizeWindow(16);
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e) {
            _gameMode.SetDifficulty(Difficulty.Expert);
            resizeWindow(24);

        }

        private void ResetButton_Click(object sender, EventArgs e) {

        }
    }
}
