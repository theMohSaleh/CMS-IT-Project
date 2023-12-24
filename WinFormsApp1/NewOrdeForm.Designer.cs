namespace WinFormsApp1
{
    partial class NewOrder
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
            components = new System.ComponentModel.Container();
            groupBox2 = new GroupBox();
            listView1 = new ListView();
            groupBox3 = new GroupBox();
            label1 = new Label();
            orderTypeTxt = new Label();
            itemsListBox = new ListBox();
            totalPriceTxt = new Label();
            label2 = new Label();
            addBTN = new Button();
            BackBTN = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(785, 473);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Order Info";
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.FullRowSelect = true;
            listView1.HideSelection = true;
            listView1.Location = new Point(6, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(459, 445);
            listView1.TabIndex = 41;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ControlLight;
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(orderTypeTxt);
            groupBox3.Controls.Add(itemsListBox);
            groupBox3.Controls.Add(totalPriceTxt);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(471, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(308, 445);
            groupBox3.TabIndex = 43;
            groupBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 13);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 44;
            label1.Text = "Order for: ";
            // 
            // orderTypeTxt
            // 
            orderTypeTxt.AutoSize = true;
            orderTypeTxt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            orderTypeTxt.Location = new Point(91, 13);
            orderTypeTxt.Name = "orderTypeTxt";
            orderTypeTxt.Size = new Size(112, 21);
            orderTypeTxt.TabIndex = 43;
            orderTypeTxt.Text = "OrderTypeTxt";
            // 
            // itemsListBox
            // 
            itemsListBox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            itemsListBox.FormattingEnabled = true;
            itemsListBox.HorizontalScrollbar = true;
            itemsListBox.ItemHeight = 20;
            itemsListBox.Location = new Point(6, 37);
            itemsListBox.Name = "itemsListBox";
            itemsListBox.Size = new Size(296, 344);
            itemsListBox.TabIndex = 42;
            itemsListBox.SelectedIndexChanged += itemsListBox_SelectedIndexChanged;
            // 
            // totalPriceTxt
            // 
            totalPriceTxt.AutoSize = true;
            totalPriceTxt.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            totalPriceTxt.Location = new Point(71, 413);
            totalPriceTxt.Name = "totalPriceTxt";
            totalPriceTxt.Size = new Size(59, 30);
            totalPriceTxt.TabIndex = 41;
            totalPriceTxt.Text = "0 BD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 411);
            label2.Name = "label2";
            label2.Size = new Size(73, 30);
            label2.TabIndex = 40;
            label2.Text = "Total: ";
            // 
            // addBTN
            // 
            addBTN.BackColor = Color.FromArgb(1, 90, 132);
            addBTN.FlatStyle = FlatStyle.Flat;
            addBTN.ForeColor = Color.White;
            addBTN.Location = new Point(599, 485);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(98, 35);
            addBTN.TabIndex = 41;
            addBTN.Text = "Place Order";
            addBTN.UseVisualStyleBackColor = false;
            addBTN.Click += addBTN_Click;
            // 
            // BackBTN
            // 
            BackBTN.Location = new Point(703, 485);
            BackBTN.Name = "BackBTN";
            BackBTN.Size = new Size(94, 35);
            BackBTN.TabIndex = 42;
            BackBTN.Text = "Clear";
            BackBTN.UseVisualStyleBackColor = true;
            BackBTN.Click += BackBTN_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // NewOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 529);
            Controls.Add(BackBTN);
            Controls.Add(addBTN);
            Controls.Add(groupBox2);
            Name = "NewOrder";
            Text = "New Order";
            FormClosed += NewOrder_FormClosed;
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
        private ListBox itemsListBox;
        private ContextMenuStrip contextMenuStrip1;
        private Label orderTypeTxt;
        private Label label1;
    }
}