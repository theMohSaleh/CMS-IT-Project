using Microsoft.EntityFrameworkCore;
using POS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class MenuItemsFrm : Form
    {
        // variables
        ProjectDBContext dbContext;

        public MenuItemsFrm()
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
        }

        private void MenuItemsFrm_Load(object sender, EventArgs e)
        {
            // display all menu items upon loading the page
            DisplayAllItems();
        }

        // this is purely for testing purposes.
        private void imageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string title = imageTitleTxt.Text;
                byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                //SaveImage(title, imageData);

                // retrieve the first image from the database
                Images imageEntity = dbContext.Images.FirstOrDefault();

                if (imageEntity != null)
                {
                    // convert the binary image data to an image
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageEntity.ImageData))
                    {
                        image = Image.FromStream(ms);
                    }

                    // display image in the PictureBox control
                    //pictureBoxTest.Image = image;
                    //pictureBoxTest.SizeMode = PictureBoxSizeMode.Zoom; // You can adjust the size mode as needed
                }
            }
        }

        

        private void DisplayAllItems()
        {
            // retrieve all items from the database, ordered by ItemId
            var Items = dbContext.Items.OrderBy(x => x.ItemId).ToList();

            listView1.LargeImageList = new ImageList { ImageSize = new Size(200, 200) };

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

                // add the image to the LargeImageList
                listView1.LargeImageList.Images.Add(itemEntity.ItemName.ToString(), image);

                // create a ListViewItem for each image
                ListViewItem listItem = new ListViewItem(itemEntity.ItemName + "\n" + itemEntity.Price.ToString() + " BD")
                {
                    ImageKey = itemEntity.ItemName,
                    Tag = itemEntity
                };

                // add the ListViewItem to the ListView
                listView1.Items.Add(listItem);

            }
        }

        // event to get details of item selected
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;

            // Get the select iten from listview
            ListViewItem clickedItem = listView.GetItemAt(e.X, e.Y);

            if (clickedItem != null)
            {
                // create item object of selected item
                Item currentItem = (Item)clickedItem.Tag;

                // test 
                MessageBox.Show($"Item ID: {currentItem.ItemId}\nTitle: {currentItem.ItemName}\nDescription: {currentItem.ItemDescription} \nPrice: {currentItem.Price} BD");

                // remove focus after selecting item
                label1.Focus();
            }
        }

        private void MenuItemsFrm_Resize(object sender, EventArgs e)
        {
            listView1.Width = ClientSize.Width;
            listView1.Height = ClientSize.Height;
        }
    }
}
