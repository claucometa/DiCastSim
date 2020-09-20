namespace DiCastSim
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.huntMonster1 = new DiCastSim.HuntMonter();
            this.playerStatus2 = new DiCastSim.PlayerStatus();
            this.playerStatus1 = new DiCastSim.PlayerStatus();
            this.board1 = new DiCastSim.Board();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "monster (1).png");
            this.imageList1.Images.SetKeyName(1, "monster.png");
            this.imageList1.Images.SetKeyName(2, "swords.png");
            this.imageList1.Images.SetKeyName(3, "apple.png");
            this.imageList1.Images.SetKeyName(4, "bread.png");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(377, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 80);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Khaki;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(377, 472);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(422, 80);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(534, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 52);
            this.button1.TabIndex = 17;
            this.button1.Text = "*";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DiCastSim.Properties.Resources.right_arrow;
            this.pictureBox1.Location = new System.Drawing.Point(334, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DiCastSim.Properties.Resources.right_arrow;
            this.pictureBox2.Location = new System.Drawing.Point(334, 498);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 35);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // huntMonster1
            // 
            this.huntMonster1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.huntMonster1.Location = new System.Drawing.Point(386, 205);
            this.huntMonster1.Name = "huntMonster1";
            this.huntMonster1.Size = new System.Drawing.Size(362, 150);
            this.huntMonster1.TabIndex = 20;
            this.huntMonster1.Visible = false;
            // 
            // playerStatus2
            // 
            this.playerStatus2.Location = new System.Drawing.Point(917, 12);
            this.playerStatus2.Name = "playerStatus2";
            this.playerStatus2.Size = new System.Drawing.Size(206, 193);
            this.playerStatus2.TabIndex = 13;
            this.playerStatus2.Title = "Player 2";
            // 
            // playerStatus1
            // 
            this.playerStatus1.Location = new System.Drawing.Point(12, 12);
            this.playerStatus1.Name = "playerStatus1";
            this.playerStatus1.Size = new System.Drawing.Size(212, 193);
            this.playerStatus1.TabIndex = 12;
            this.playerStatus1.Title = "Player 1";
            // 
            // board1
            // 
            this.board1.Location = new System.Drawing.Point(230, 12);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(681, 701);
            this.board1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(917, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 52);
            this.button2.TabIndex = 21;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 687);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.huntMonster1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerStatus2);
            this.Controls.Add(this.playerStatus1);
            this.Controls.Add(this.board1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Board board1;
        private System.Windows.Forms.ImageList imageList1;
        private PlayerStatus playerStatus1;
        private PlayerStatus playerStatus2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private HuntMonter huntMonster1;
        private System.Windows.Forms.Button button2;
    }
}

