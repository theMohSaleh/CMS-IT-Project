﻿using Microsoft.EntityFrameworkCore;
using POS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class PayForOrderFrm : Form
    {
        int currentTableNo;
        Order order;
        ProjectDBContext dBContext;
        public PayForOrderFrm(int tableNo)
        {
            InitializeComponent();
            currentTableNo = tableNo;
            dBContext = new ProjectDBContext();
        }

        private void PayForOrderFrm_Load(object sender, EventArgs e)
        {
            order = dBContext.Orders.Where(x => x.TableNumber == currentTableNo && x.IsPaid == 0).FirstOrDefault()!;

            tableNoTxt.Text = order.TableNumber.ToString();
            priceTxt.Text = order.TotalAmount.ToString()+" BD";
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to print receipt for this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                order.IsPaid = 1;
                order.IsOccupied = 0;
                dBContext.Orders.Update(order);

                dBContext.SaveChanges();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelOrderBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you cancel and delete this order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var relatedOrderItems = dBContext.OrderItems.Where(item => item.OrderId == order.OrderId);
                dBContext.OrderItems.RemoveRange(relatedOrderItems);

                dBContext.Orders.Remove(order);

                dBContext.SaveChanges();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}