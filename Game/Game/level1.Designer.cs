
namespace Game
{
    partial class Level1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Level1));
            this.FpsTime = new System.Windows.Forms.Timer(this.components);
            this.ExitButton = new System.Windows.Forms.Button();
            this.Countdown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FpsTime
            // 
            this.FpsTime.Enabled = true;
            this.FpsTime.Interval = 1;
            this.FpsTime.Tick += new System.EventHandler(this.FpsTimer);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(83, 83);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(77, 77);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitClick);
            // 
            // Countdown
            // 
            this.Countdown.Enabled = true;
            this.Countdown.Interval = 1000;
            this.Countdown.Tick += new System.EventHandler(this.Countdown_Tick);
            // 
            // Level1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2542, 1393);
            this.Controls.Add(this.ExitButton);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Level1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.Level1_Deactivate);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FpsTime;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Timer Countdown;
    }
}