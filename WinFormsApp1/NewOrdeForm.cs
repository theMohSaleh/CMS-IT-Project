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

namespace WinFormsApp1
{
    public partial class New_Order : Form
    {
        // variables
        ProjectDBContext dbContext;
        public New_Order()
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
        }

        private void New_Order_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DisplayAllItems();
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label2.ForeColor = ThemeColor.SecondaryColor;
        }

        private void DisplayAllItems()
        {
            // retrieve all items from the database, ordered by ItemId
            var Items = dbContext.Items.OrderBy(x => x.ItemId).ToList();

            listView1.LargeImageList = new ImageList { ImageSize = new Size(100, 100) };

            // foreach loop to display all menu items
            foreach (var itemEntity in Items)
            {
                // convert the binary image data to an image
                Image image;
                var imageDataVar = dbContext.Images.Where(x => x.ImageId == itemEntity.ImageId).First(); // get image of item by ImageId
                using (MemoryStream ms = new MemoryStream(imageDataVar.ImageData))
                {
                    image = Image.FromStream(ms);
                }

                // Add the image to the LargeImageList
                listView1.LargeImageList.Images.Add(itemEntity.ItemName.ToString(), image);

                // Create a ListViewItem for each image
                ListViewItem listItem = new ListViewItem(itemEntity.ItemName + "\n" + itemEntity.Price.ToString() + " BD")
                {
                    ImageKey = itemEntity.ItemName,
                    Tag = itemEntity
                };

                // Add the ListViewItem to the ListView
                listView1.Items.Add(listItem);

            }
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            CreateNewOrder();
        }

        private void CreateNewOrder()
        {
            // get and store order info in variables
            int tableNo;
            float totalPrice;
            

            // create order object

            
            // add order object to database


            // update db


        }
    }
}
