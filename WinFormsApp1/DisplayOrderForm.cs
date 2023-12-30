using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class DisplayOrderForm : Form
    {
        // variables
        int orderID;
        ProjectDBContext dbContext;
        public DisplayOrderForm(int orderId)
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
            orderID = orderId;
        }

        private void DisplayOrderForm_Load(object sender, EventArgs e)
        {
            DisplayAllItems();

        }

        private void DisplayAllItems()
        {
            // retrieve all items from the database, ordered by ItemId
            var orderItems = dbContext.OrderItems
                .Include(o => o.Item)
                .Where(x => x.OrderId == orderID)
                .ToList();

            listView1.LargeImageList = new ImageList { ImageSize = new Size(200, 200) };

            // foreach loop to display all menu items
            foreach (var item in orderItems)
            {
                // convert the binary image data to an image
                Image image;
                var imageDataVar = dbContext.Images.Where(x => x.ImageId == item.Item.ImageId).First(); // get image of item by ImageId
                using (MemoryStream ms = new MemoryStream(imageDataVar.ImageData))
                {
                    image = Image.FromStream(ms);
                }

                // add the image to the LargeImageList
                listView1.LargeImageList.Images.Add(item.Item.ItemName.ToString(), image);

                // create a ListViewItem for each image
                ListViewItem listItem = new ListViewItem(item.Item.ItemName +
                    "\n" + item.Item.Price.ToString() + " BD" +
                    "\n Quantity:" + item.Quantity.ToString())
                {
                    ImageKey = item.Item.ItemName,
                    Tag = item
                };

                // add the ListViewItem to the ListView
                listView1.Items.Add(listItem);

            }
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            PayForOrderFrm payForm = new PayForOrderFrm(0, orderID);
            DialogResult payDialog = payForm.ShowDialog();
            if (payDialog == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
