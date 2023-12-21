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
            listView1 = new ListView();
            groupBox3 = new GroupBox();
            totalPriceTxt = new Label();
            label2 = new Label();
            addBTN = new Button();
            BackBTN = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(14, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1154, 631);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Order Info";
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.FullRowSelect = true;
            listView1.HideSelection = true;
            listView1.Location = new Point(7, 29);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(524, 592);
            listView1.TabIndex = 41;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ControlLight;
            groupBox3.Controls.Add(totalPriceTxt);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(538, 29);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(318, 593);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            // 
            // totalPriceTxt
            // 
            totalPriceTxt.AutoSize = true;
            totalPriceTxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            totalPriceTxt.Location = new Point(81, 551);
            totalPriceTxt.Name = "totalPriceTxt";
            totalPriceTxt.Size = new Size(143, 37);
            totalPriceTxt.TabIndex = 41;
            totalPriceTxt.Text = "totalprice";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(7, 548);
            label2.Name = "label2";
            label2.Size = new Size(96, 37);
            label2.TabIndex = 40;
            label2.Text = "Total: ";
            // 
            // addBTN
            // 
            addBTN.BackColor = Color.FromArgb(1, 90, 132);
            addBTN.FlatStyle = FlatStyle.Flat;
            addBTN.ForeColor = Color.White;
            addBTN.Location = new Point(643, 647);
            addBTN.Margin = new Padding(3, 4, 3, 4);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(112, 47);
            addBTN.TabIndex = 41;
            addBTN.Text = "Create Order";
            addBTN.UseVisualStyleBackColor = false;
            addBTN.Click += addBTN_Click;
            // 
            // BackBTN
            // 
            BackBTN.Location = new Point(762, 647);
            BackBTN.Margin = new Padding(3, 4, 3, 4);
            BackBTN.Name = "BackBTN";
            BackBTN.Size = new Size(107, 47);
            BackBTN.TabIndex = 42;
            BackBTN.Text = "Cancel";
            BackBTN.UseVisualStyleBackColor = true;
            BackBTN.Click += BackBTN_Click;
            // 
            // New_Order
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 705);
            Controls.Add(BackBTN);
            Controls.Add(addBTN);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 4, 3, 4);
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
        private GroupBox groupBox3;
        private ListView listView1;
        private Label totalPriceTxt;
    }
}