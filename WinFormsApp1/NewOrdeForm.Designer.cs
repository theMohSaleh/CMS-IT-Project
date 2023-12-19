namespace WinFormsApp1
{
    partial class New_Order
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
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            addBTN = new Button();
            BackBTN = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1010, 541);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Order Info";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ControlLight;
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(732, 37);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(278, 498);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 465);
            label2.Name = "label2";
            label2.Size = new Size(73, 30);
            label2.TabIndex = 40;
            label2.Text = "Total: ";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlDark;
            groupBox1.Location = new Point(13, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(713, 498);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // addBTN
            // 
            addBTN.BackColor = Color.FromArgb(1, 90, 132);
            addBTN.FlatStyle = FlatStyle.Flat;
            addBTN.ForeColor = Color.White;
            addBTN.Location = new Point(824, 559);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(98, 35);
            addBTN.TabIndex = 41;
            addBTN.Text = "Create Order";
            addBTN.UseVisualStyleBackColor = false;
            // 
            // BackBTN
            // 
            BackBTN.Location = new Point(928, 559);
            BackBTN.Name = "BackBTN";
            BackBTN.Size = new Size(94, 35);
            BackBTN.TabIndex = 42;
            BackBTN.Text = "Cancel";
            BackBTN.UseVisualStyleBackColor = true;
            BackBTN.Click += BackBTN_Click;
            // 
            // New_Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 606);
            Controls.Add(BackBTN);
            Controls.Add(addBTN);
            Controls.Add(groupBox2);
            MinimumSize = new Size(1050, 645);
            Name = "New_Order";
            Text = "New Order";
            Load += New_Order_Load;
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button addBTN;
        private Button BackBTN;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
    }
}