using Microsoft.EntityFrameworkCore;
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
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class CurrentOrdersFrm : Form
    {
        // variables
        ProjectDBContext dbContext;

        public CurrentOrdersFrm()
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label1.ForeColor = ThemeColor.SecondaryColor;
            //label2.ForeColor = ThemeColor.SecondaryColor;
        }

        private void CurrentOrdersFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            // get delivery orders
            var deliveryOrders = dbContext.Orders
                .Include(o => o.User)
                .Where(x => x.IsOccupied == 1
                && x.IsPaid == 0)
                .ToList();
            // get takeAway orders
            var takeAwayOrders = dbContext.Orders
                .Include(o => o.User)
                .Where(x => x.IsOccupied == 0
                && x.IsPaid == 0)
                .ToList();

            // clear items for when resetting the data
            listView1.Items.Clear();
            listView2.Items.Clear();

            // loop through each delivery item
            foreach (var order in deliveryOrders)
            {
                if (order.User != null) {
                    // create a list item for each order
                    ListViewItem listItem = new ListViewItem(order.User!.Name)
                    {
                        Tag = order
                    };

                    // add the ListViewItem to the ListView
                    listView1.Items.Add(listItem);
                }
            }

            // loop through each take away item
            foreach (var order in takeAwayOrders)
            {
                if (order.User != null)
                {
                    // create a list item for each order
                    ListViewItem listItem = new ListViewItem(order.User!.Name)
                    {
                        Tag = order
                    };

                    // add the ListViewItem to the ListView
                    listView2.Items.Add(listItem);
                } else
                {
                    ListViewItem listItem = new ListViewItem("Order: "+order.OrderId.ToString())
                    {
                        Tag = order
                    };
                    // add the ListViewItem to the ListView
                    listView2.Items.Add(listItem);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                // get order tag
                Order selectedOrder = e.Item.Tag as Order;

                // check if order exists and display order items
                if (selectedOrder != null)
                {
                    using (DisplayOrderForm displayDialog = new DisplayOrderForm(selectedOrder.OrderId))
                    {
                        DialogResult newDialog = displayDialog.ShowDialog();
                        if (newDialog == DialogResult.OK)
                        {
                            DisplayOrders();
                        }
                    }
                }
            }
        }
    }
}
