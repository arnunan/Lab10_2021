
namespace Game
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.level1 = new System.Windows.Forms.Button();
            this.level2 = new System.Windows.Forms.Button();
            this.level3 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // level
            // 
            this.level1.BackColor = System.Drawing.Color.Transparent;
            this.level1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.level1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.level1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.level1.FlatAppearance.BorderSize = 0;
            this.level1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.level1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level1.Font = new System.Drawing.Font("Haettenschweiler", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level1.Location = new System.Drawing.Point(450, 1000);
            this.level1.Name = "level";
            this.level1.Size = new System.Drawing.Size(250, 100);
            this.level1.TabIndex = 0;
            this.level1.Tag = "1";
            this.level1.Text = "level 1";
            this.level1.UseVisualStyleBackColor = false;
            this.level1.Click += new System.EventHandler(this.LevelClick);
            // 
            // button1
            // 
            this.level2.BackColor = System.Drawing.Color.Transparent;
            this.level2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.level2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.level2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.level2.FlatAppearance.BorderSize = 0;
            this.level2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.level2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level2.Font = new System.Drawing.Font("Haettenschweiler", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level2.Location = new System.Drawing.Point(930, 1000);
            this.level2.Name = "button1";
            this.level2.Size = new System.Drawing.Size(250, 100);
            this.level2.TabIndex = 1;
            this.level2.Tag = "2";
            this.level2.Text = "level 2";
            this.level2.UseVisualStyleBackColor = false;
            this.level2.Click += new System.EventHandler(this.LevelClick);
            // 
            // button2
            // 
            this.level3.BackColor = System.Drawing.Color.Transparent;
            this.level3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.level3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.level3.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.level3.FlatAppearance.BorderSize = 0;
            this.level3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.level3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level3.Font = new System.Drawing.Font("Haettenschweiler", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level3.Location = new System.Drawing.Point(1860, 1000);
            this.level3.Name = "button2";
            this.level3.Size = new System.Drawing.Size(250, 100);
            this.level3.TabIndex = 3;
            this.level3.Tag = "4";
            this.level3.Text = "level 4";
            this.level3.UseVisualStyleBackColor = false;
            this.level3.Click += new System.EventHandler(this.LevelClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Haettenschweiler", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(1380, 1000);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 100);
            this.button3.TabIndex = 2;
            this.button3.Tag = "3";
            this.button3.Text = "level 3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.LevelClick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(2542, 1393);
            this.Controls.Add(this.level3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.level2);
            this.Controls.Add(this.level1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button level1;
        private System.Windows.Forms.Button level2;
        private System.Windows.Forms.Button level3;
        private System.Windows.Forms.Button button3;
    }
}