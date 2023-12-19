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
            DisplayAllImages();
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

        public void SaveImage(string title, byte[] imageData)
        {
            using (dbContext)
            {
                // set title and imagedata of new image
                Images newImage = new Images
                {
                    Title = title,
                    ImageData = imageData
                };

                // add the entity to the context
                dbContext.Images.Add(newImage);

                // save changes to the database
                dbContext.SaveChanges();
            }
        }

        private void DisplayAllImages()
        {
            // retrieve all items from the database, ordered by ItemId
            var Items = dbContext.Items.OrderBy(x => x.ItemId).ToList();

            listView1.LargeImageList = new ImageList { ImageSize = new Size(150, 150) };

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

                // create a PictureBox for the item image
                PictureBox pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 150,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // create a label for item name
                Label itemName = new Label
                {
                    Text = itemEntity.ItemName,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = false,
                    Width = 100,
                    Height = 40,
                    Dock = DockStyle.Bottom
                };

                // create a label for item price
                Label itemPrice = new Label
                {
                    Text = itemEntity.Price.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    AutoSize = false,
                    Width = 100,
                    Height = 20,
                    Dock = DockStyle.Bottom
                };

                // label acting as a divider between each item
                Label divider = new Label
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Width = 3,
                    Height = pictureBox.Height + itemName.Height + itemPrice.Height  // Adjust the divider height to match panel
                };

                // create a panel to hold the item contents
                Panel panel = new Panel
                {
                    Width = 150,
                    Height = 200
                };

                // add all contents of the item to the panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(itemName);
                panel.Controls.Add(itemPrice);

                // Add the image to the LargeImageList
                listView1.LargeImageList.Images.Add(itemEntity.ItemName.ToString(), image);

                // Create a ListViewItem for each image
                ListViewItem listItem = new ListViewItem(itemEntity.ItemName.ToString() + "\n" +itemEntity.Price.ToString() +" BD")
                {
                    ImageKey = itemEntity.ItemName,
                };

                // Add the ListViewItem to the ListView
                listView1.Items.Add(listItem);

            }
        }
    }
}
