namespace GameCaro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlChessboard = new Panel();
            panel2 = new Panel();
            ptbAvatar = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            btnLAN = new Button();
            ptrbMark = new PictureBox();
            txtbIP = new TextBox();
            CountDown = new ProgressBar();
            txtPlayerName = new TextBox();
            tmCountDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbAvatar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptrbMark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessboard
            // 
            pnlChessboard.BackColor = SystemColors.Control;
            pnlChessboard.Location = new Point(12, 39);
            pnlChessboard.Name = "pnlChessboard";
            pnlChessboard.Size = new Size(711, 559);
            pnlChessboard.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(ptbAvatar);
            panel2.Location = new Point(741, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 264);
            panel2.TabIndex = 1;
            // 
            // ptbAvatar
            // 
            ptbAvatar.Image = Properties.Resources.avatar;
            ptbAvatar.Location = new Point(3, 3);
            ptbAvatar.Name = "ptbAvatar";
            ptbAvatar.Size = new Size(244, 257);
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAvatar.TabIndex = 0;
            ptbAvatar.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnLAN);
            panel3.Controls.Add(ptrbMark);
            panel3.Controls.Add(txtbIP);
            panel3.Controls.Add(CountDown);
            panel3.Controls.Add(txtPlayerName);
            panel3.Location = new Point(741, 309);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 289);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 209);
            label1.Name = "label1";
            label1.Size = new Size(179, 31);
            label1.TabIndex = 5;
            label1.Text = "5 in line to win";
            // 
            // btnLAN
            // 
            btnLAN.Location = new Point(22, 114);
            btnLAN.Name = "btnLAN";
            btnLAN.Size = new Size(94, 29);
            btnLAN.TabIndex = 4;
            btnLAN.Text = "LAN";
            btnLAN.UseVisualStyleBackColor = true;
            // 
            // ptrbMark
            // 
            ptrbMark.BackColor = SystemColors.ActiveCaption;
            ptrbMark.Location = new Point(139, 13);
            ptrbMark.Name = "ptrbMark";
            ptrbMark.Size = new Size(108, 122);
            ptrbMark.SizeMode = PictureBoxSizeMode.StretchImage;
            ptrbMark.TabIndex = 3;
            ptrbMark.TabStop = false;
            // 
            // txtbIP
            // 
            txtbIP.Location = new Point(8, 81);
            txtbIP.Name = "txtbIP";
            txtbIP.Size = new Size(125, 27);
            txtbIP.TabIndex = 2;
            // 
            // CountDown
            // 
            CountDown.Location = new Point(8, 46);
            CountDown.Name = "CountDown";
            CountDown.Size = new Size(125, 29);
            CountDown.TabIndex = 1;
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(8, 13);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(125, 27);
            txtPlayerName.TabIndex = 0;
            // 
            // tmCountDown
            // 
            tmCountDown.Interval = 1000;
            tmCountDown.Tick += tmCoundDown_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1003, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(224, 26);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(224, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(224, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 610);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlChessboard);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Caro LAN";
            FormClosing += Form1_FormClosing;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptbAvatar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptrbMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlChessboard;
        private Panel panel2;
        private Panel panel3;
        private Button btnLAN;
        private PictureBox ptrbMark;
        private TextBox txtbIP;
        private ProgressBar CountDown;
        private TextBox txtPlayerName;
        private Label label1;
        private PictureBox ptbAvatar;
        private System.Windows.Forms.Timer tmCountDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}
