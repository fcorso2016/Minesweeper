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
            IGeneratorFactory factory = new GeneratorFactory();
            _gameMode = new GameInstance(factory);
            IBoard board = new Board(_gameMode);
            _gameMode.GenerateBoard(panel1);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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

        private void PlayZone_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
