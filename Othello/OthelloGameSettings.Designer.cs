namespace Othello
{
    public partial class OthelloGameSettingsForm
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
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayVsPC = new System.Windows.Forms.Button();
            this.buttonPlayVsPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoardSize.Location = new System.Drawing.Point(12, 12);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(370, 50);
            this.buttonBoardSize.TabIndex = 0;
            this.buttonBoardSize.Text = "Board Size: 6x6 (click to increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonPlayVsPC
            // 
            this.buttonPlayVsPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayVsPC.Location = new System.Drawing.Point(12, 69);
            this.buttonPlayVsPC.Name = "buttonPlayVsPC";
            this.buttonPlayVsPC.Size = new System.Drawing.Size(180, 50);
            this.buttonPlayVsPC.TabIndex = 1;
            this.buttonPlayVsPC.Text = "Play against the computer";
            this.buttonPlayVsPC.UseVisualStyleBackColor = true;
            this.buttonPlayVsPC.Click += new System.EventHandler(this.buttonPlayVsPC_Click);
            // 
            // buttonPlayVsPlayer
            // 
            this.buttonPlayVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayVsPlayer.Location = new System.Drawing.Point(202, 69);
            this.buttonPlayVsPlayer.Name = "buttonPlayVsPlayer";
            this.buttonPlayVsPlayer.Size = new System.Drawing.Size(180, 50);
            this.buttonPlayVsPlayer.TabIndex = 2;
            this.buttonPlayVsPlayer.Text = "Play against your friend";
            this.buttonPlayVsPlayer.UseVisualStyleBackColor = true;
            this.buttonPlayVsPlayer.Click += new System.EventHandler(this.buttonPlayVsPlayer_Click);
            // 
            // OthelloGameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 131);
            this.Controls.Add(this.buttonPlayVsPlayer);
            this.Controls.Add(this.buttonPlayVsPC);
            this.Controls.Add(this.buttonBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OthelloGameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonPlayVsPC;
        private System.Windows.Forms.Button buttonPlayVsPlayer;
    }
}