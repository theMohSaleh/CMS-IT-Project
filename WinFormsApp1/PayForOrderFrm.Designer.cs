namespace POS
{
    partial class PayForOrderFrm
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
            payBtn = new Button();
            cancelOrderBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            tableNoTxt = new Label();
            priceTxt = new Label();
            backBtn = new Button();
            officeLbl = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // payBtn
            // 
            payBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            payBtn.Location = new Point(86, 230);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(105, 28);
            payBtn.TabIndex = 0;
            payBtn.Text = "Print Receipt";
            payBtn.UseVisualStyleBackColor = true;
            payBtn.Click += payBtn_Click;
            // 
            // cancelOrderBtn
            // 
            cancelOrderBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancelOrderBtn.ForeColor = Color.Red;
            cancelOrderBtn.Location = new Point(197, 230);
            cancelOrderBtn.Name = "cancelOrderBtn";
            cancelOrderBtn.Size = new Size(105, 28);
            cancelOrderBtn.TabIndex = 1;
            cancelOrderBtn.Text = "Cancel Order";
            cancelOrderBtn.UseVisualStyleBackColor = true;
            cancelOrderBtn.Click += cancelOrderBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(102, 44);
            label1.Name = "label1";
            label1.Size = new Size(128, 21);
            label1.TabIndex = 2;
            label1.Text = "Order for table: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(102, 91);
            label2.Name = "label2";
            label2.Size = new Size(86, 21);
            label2.TabIndex = 3;
            label2.Text = "Total price";
            // 
            // tableNoTxt
            // 
            tableNoTxt.AutoSize = true;
            tableNoTxt.Location = new Point(246, 49);
            tableNoTxt.Name = "tableNoTxt";
            tableNoTxt.Size = new Size(64, 15);
            tableNoTxt.TabIndex = 4;
            tableNoTxt.Text = "tableNoTxt";
            // 
            // priceTxt
            // 
            priceTxt.AutoSize = true;
            priceTxt.Location = new Point(246, 97);
            priceTxt.Name = "priceTxt";
            priceTxt.Size = new Size(57, 15);
            priceTxt.TabIndex = 5;
            priceTxt.Text = "totalPrice";
            // 
            // backBtn
            // 
            backBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            backBtn.ForeColor = SystemColors.ControlText;
            backBtn.Location = new Point(308, 230);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(82, 28);
            backBtn.TabIndex = 6;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // officeLbl
            // 
            officeLbl.AutoSize = true;
            officeLbl.Location = new Point(246, 153);
            officeLbl.Name = "officeLbl";
            officeLbl.Size = new Size(53, 15);
            officeLbl.TabIndex = 8;
            officeLbl.Text = "officeLbl";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(102, 147);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 7;
            label4.Text = "Delivery to:";
            // 
            // PayForOrderFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 294);
            Controls.Add(officeLbl);
            Controls.Add(label4);
            Controls.Add(backBtn);
            Controls.Add(priceTxt);
            Controls.Add(tableNoTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelOrderBtn);
            Controls.Add(payBtn);
            Name = "PayForOrderFrm";
            Text = "PayForOrderFrm";
            Load += PayForOrderFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button payBtn;
        private Button cancelOrderBtn;
        private Label label1;
        private Label label2;
        private Label tableNoTxt;
        private Label priceTxt;
        private Button backBtn;
        private Label officeLbl;
        private Label label4;
    }
}