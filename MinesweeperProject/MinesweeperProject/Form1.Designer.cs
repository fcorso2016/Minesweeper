namespace MinesweeperProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlayZone = new System.Windows.Forms.Panel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Label();
            this.MinesRemaining = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolbarOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolbarHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.howDoMinesweepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doTheSweepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayZone
            // 
            this.PlayZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PlayZone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayZone.BackgroundImage")));
            this.PlayZone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayZone.Location = new System.Drawing.Point(12, 77);
            this.PlayZone.Name = "PlayZone";
            this.PlayZone.Size = new System.Drawing.Size(776, 419);
            this.PlayZone.TabIndex = 0;
            this.PlayZone.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayZone_Paint);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ResetButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResetButton.BackgroundImage")));
            this.ResetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResetButton.Location = new System.Drawing.Point(363, 31);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(40, 40);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(734, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 3;
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(13, 32);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(33, 13);
            this.Timer.TabIndex = 4;
            this.Timer.Text = "Timer";
            // 
            // MinesRemaining
            // 
            this.MinesRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinesRemaining.AutoSize = true;
            this.MinesRemaining.Location = new System.Drawing.Point(753, 35);
            this.MinesRemaining.Name = "MinesRemaining";
            this.MinesRemaining.Size = new System.Drawing.Size(35, 13);
            this.MinesRemaining.TabIndex = 5;
            this.MinesRemaining.Text = "Mines";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolbarOptions,
            this.ToolbarHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolbarOptions
            // 
            this.ToolbarOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.ToolbarOptions.Name = "ToolbarOptions";
            this.ToolbarOptions.Size = new System.Drawing.Size(61, 20);
            this.ToolbarOptions.Text = "Options";
            this.ToolbarOptions.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "New Game";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            // 
            // ToolbarHelp
            // 
            this.ToolbarHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howDoMinesweepToolStripMenuItem});
            this.ToolbarHelp.Name = "ToolbarHelp";
            this.ToolbarHelp.Size = new System.Drawing.Size(44, 20);
            this.ToolbarHelp.Text = "Help";
            this.ToolbarHelp.Click += new System.EventHandler(this.ToolbarHelp_Click);
            // 
            // howDoMinesweepToolStripMenuItem
            // 
            this.howDoMinesweepToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doTheSweepToolStripMenuItem});
            this.howDoMinesweepToolStripMenuItem.Name = "howDoMinesweepToolStripMenuItem";
            this.howDoMinesweepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.howDoMinesweepToolStripMenuItem.Text = "How Do Minesweep";
            // 
            // doTheSweepToolStripMenuItem
            // 
            this.doTheSweepToolStripMenuItem.Name = "doTheSweepToolStripMenuItem";
            this.doTheSweepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.doTheSweepToolStripMenuItem.Text = "Do The Sweep";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.MinesRemaining);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.PlayZone);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayZone;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label MinesRemaining;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolbarOptions;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolbarHelp;
        private System.Windows.Forms.ToolStripMenuItem howDoMinesweepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doTheSweepToolStripMenuItem;
    }
}

