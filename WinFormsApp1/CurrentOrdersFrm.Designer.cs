namespace POS
{
    partial class CurrentOrdersFrm
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
            label1 = new Label();
            label2 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            listView2 = new ListView();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            listView1.Location = new Point(28, 102);
            listView1.Name = "listView1";
            listView1.Size = new Size(340, 384);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 290;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(112, 52);
            label1.Name = "label1";
            label1.Size = new Size(164, 30);
            label1.TabIndex = 2;
            label1.Text = "Delivery Orders";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(506, 52);
            label2.Name = "label2";
            label2.Size = new Size(188, 30);
            label2.TabIndex = 3;
            label2.Text = "Take Away Orders";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listView2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            listView2.Location = new Point(425, 102);
            listView2.Name = "listView2";
            listView2.Size = new Size(340, 384);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.ItemSelectionChanged += listView1_ItemSelectionChanged;
            // 
            // columnHeader2
            // 
            columnHeader2.Width = 290;
            // 
            // CurrentOrdersFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 529);
            Controls.Add(listView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "CurrentOrdersFrm";
            Text = "CurrentOrdersFrm";
            Load += CurrentOrdersFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private Label label2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ColumnHeader columnHeader1;
        private ListView listView2;
        private ColumnHeader columnHeader2;
    }
}