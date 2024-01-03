namespace POS
{
    partial class DisplayOrderForm
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            payBtn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(782, 461);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Order:";
            columnHeader1.Width = 200;
            // 
            // payBtn
            // 
            payBtn.Location = new Point(553, 479);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(132, 38);
            payBtn.TabIndex = 1;
            payBtn.Text = "Confirm Payment";
            payBtn.UseVisualStyleBackColor = true;
            payBtn.Click += payBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(691, 479);
            button1.Name = "button1";
            button1.Size = new Size(103, 38);
            button1.TabIndex = 2;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DisplayOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 529);
            Controls.Add(button1);
            Controls.Add(payBtn);
            Controls.Add(listView1);
            Name = "DisplayOrderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DisplayOrderForm";
            Load += DisplayOrderForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button payBtn;
        private Button button1;
        private ColumnHeader columnHeader1;
    }
}