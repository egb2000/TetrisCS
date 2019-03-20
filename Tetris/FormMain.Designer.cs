namespace Tetris
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBtnStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuBtnSound = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBtnHeroList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuBtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGame,
            this.MenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuGame
            // 
            this.MenuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBtnStart,
            this.toolStripSeparator1,
            this.MenuBtnSound,
            this.MenuBtnHeroList,
            this.toolStripSeparator2,
            this.MenuBtnClose});
            this.MenuGame.Name = "MenuGame";
            this.MenuGame.Size = new System.Drawing.Size(61, 21);
            this.MenuGame.Text = "游戏(&G)";
            // 
            // MenuBtnStart
            // 
            this.MenuBtnStart.Name = "MenuBtnStart";
            this.MenuBtnStart.Size = new System.Drawing.Size(152, 22);
            this.MenuBtnStart.Text = "开局(&N)";
            this.MenuBtnStart.Click += new System.EventHandler(this.MenuBtnStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuBtnSound
            // 
            this.MenuBtnSound.Name = "MenuBtnSound";
            this.MenuBtnSound.Size = new System.Drawing.Size(152, 22);
            this.MenuBtnSound.Text = "声音(&S)";
            // 
            // MenuBtnHeroList
            // 
            this.MenuBtnHeroList.Name = "MenuBtnHeroList";
            this.MenuBtnHeroList.Size = new System.Drawing.Size(152, 22);
            this.MenuBtnHeroList.Text = "英雄榜(&T)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuBtnClose
            // 
            this.MenuBtnClose.Name = "MenuBtnClose";
            this.MenuBtnClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.MenuBtnClose.Size = new System.Drawing.Size(156, 22);
            this.MenuBtnClose.Text = "退出(&X)";
            this.MenuBtnClose.Click += new System.EventHandler(this.MenuBtnClose_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCatalog});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(61, 21);
            this.MenuHelp.Text = "帮助(&H)";
            // 
            // MenuCatalog
            // 
            this.MenuCatalog.Name = "MenuCatalog";
            this.MenuCatalog.Size = new System.Drawing.Size(116, 22);
            this.MenuCatalog.Text = "目录(&C)";
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBoxPreview.Controls.Add(this.textBoxScore);
            this.groupBoxPreview.Controls.Add(this.label5);
            this.groupBoxPreview.Controls.Add(this.textBox1);
            this.groupBoxPreview.Controls.Add(this.label4);
            this.groupBoxPreview.Location = new System.Drawing.Point(309, 155);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(125, 205);
            this.groupBoxPreview.TabIndex = 2;
            this.groupBoxPreview.TabStop = false;
            // 
            // textBoxScore
            // 
            this.textBoxScore.BackColor = System.Drawing.SystemColors.ControlText;
            this.textBoxScore.Enabled = false;
            this.textBoxScore.Font = new System.Drawing.Font("Arial Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxScore.ForeColor = System.Drawing.Color.Yellow;
            this.textBoxScore.Location = new System.Drawing.Point(12, 156);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(101, 34);
            this.textBoxScore.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 43);
            this.label5.TabIndex = 0;
            this.label5.Text = "SCORE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Arial Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(12, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 34);
            this.textBox1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(17, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 43);
            this.label4.TabIndex = 0;
            this.label4.Text = "HIGH";
            // 
            // labelPreview
            // 
            this.labelPreview.BackColor = System.Drawing.Color.Black;
            this.labelPreview.Location = new System.Drawing.Point(309, 27);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(125, 125);
            this.labelPreview.TabIndex = 4;
            this.labelPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.labelPreview_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tetris.Properties.Resources.c498;
            this.pictureBox1.Location = new System.Drawing.Point(311, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelDisplay
            // 
            this.labelDisplay.BackColor = System.Drawing.Color.Black;
            this.labelDisplay.Location = new System.Drawing.Point(0, 27);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(305, 545);
            this.labelDisplay.TabIndex = 3;
            this.labelDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.labelDisplay_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(436, 573);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "俄罗斯方块";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBoxPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MenuGame;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnStart;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnSound;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnHeroList;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuCatalog;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

