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
                string title = imageTitleTxt.Text;
                byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                SaveImage(title, imageData);

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
                    pictureBoxTest.Image = image;
                    pictureBoxTest.SizeMode = PictureBoxSizeMode.Zoom; // You can adjust the size mode as needed
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
            // retrieve all images from the database, ordered by ImageId
            var images = dbContext.Images.OrderBy(img => img.ImageId).ToList();

            // foreach loop to display all menu items
            foreach (var imageEntity in images)
            {
                // convert the binary image data to an image
                Image image;
                using (MemoryStream ms = new MemoryStream(imageEntity.ImageData))
                {
                    image = Image.FromStream(ms);
                }

                // create a PictureBox for each image
                PictureBox pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 150,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Create a label for item name
                Label itemName = new Label
                {
                    Text = imageEntity.Title,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 15, FontStyle.Bold),
                    AutoSize = false,
                    Width = 100, 
                    Height = 40, 
                    Dock = DockStyle.Bottom
                };

                // Create a label for item price
                Label itemPrice = new Label
                {
                    Text = "$3.99",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 14, FontStyle.Regular),
                    AutoSize = false,
                    Width = 100,
                    Height = 20,
                    Dock = DockStyle.Bottom
                };

                // Create a container (e.g., Panel) to hold the PictureBox and Label
                Panel panel = new Panel
                {
                    Width = 150,
                    Height = 200
                }
                ;
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(itemName);
                panel.Controls.Add(itemPrice);

                // Add the PictureBox to a container or directly to the form
                flowLayoutPanel1.Controls.Add(panel);
            }
        }
    }
}
