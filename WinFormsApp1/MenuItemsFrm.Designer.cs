namespace POS
{
    partial class MenuItemsFrm
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
            imageBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            imageTitleTxt = new TextBox();
            pictureBoxTest = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTest).BeginInit();
            SuspendLayout();
            // 
            // imageBtn
            // 
            imageBtn.Location = new Point(1194, 526);
            imageBtn.Name = "imageBtn";
            imageBtn.Size = new Size(75, 23);
            imageBtn.TabIndex = 0;
            imageBtn.Text = "img";
            imageBtn.UseVisualStyleBackColor = true;
            imageBtn.Click += imageBtn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageTitleTxt
            // 
            imageTitleTxt.Location = new Point(1182, 400);
            imageTitleTxt.Name = "imageTitleTxt";
            imageTitleTxt.Size = new Size(100, 23);
            imageTitleTxt.TabIndex = 1;
            // 
            // pictureBoxTest
            // 
            pictureBoxTest.Location = new Point(737, 12);
            pictureBoxTest.Name = "pictureBoxTest";
            pictureBoxTest.Size = new Size(439, 459);
            pictureBoxTest.TabIndex = 2;
            pictureBoxTest.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1319, 671);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // MenuItemsFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 671);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pictureBoxTest);
            Controls.Add(imageTitleTxt);
            Controls.Add(imageBtn);
            MinimumSize = new Size(1335, 710);
            Name = "MenuItemsFrm";
            Text = "MenuItemsFrm";
            Load += MenuItemsFrm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxTest).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button imageBtn;
        private OpenFileDialog openFileDialog1;
        private TextBox imageTitleTxt;
        private PictureBox pictureBoxTest;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}