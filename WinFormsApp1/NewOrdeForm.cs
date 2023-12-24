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
    public partial class NewOrder : Form
    {
        // variables
        ProjectDBContext dbContext;
        private List<Cart> cartItems;
        private Landing landingForm;
        int tableNo = 0;
        public NewOrder(string? stringTableNo = null, Landing? landingForm = null)
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
            cartItems = new List<Cart>();
            if (stringTableNo != null)
            {
                tableNo = int.Parse(stringTableNo);
            }
            this.landingForm = landingForm;
        }

        private void New_Order_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DisplayAllItems();
            if (tableNo != 0)
            {
                orderTypeTxt.Text = "Table " + tableNo;
            }
            else
            {
                orderTypeTxt.Text = "Takeout";
            }
        }

        // clear all items in the cart
        private void BackBTN_Click(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
            cartItems.Clear();
            updateDisplayedItems();
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
            label1.ForeColor = ThemeColor.SecondaryColor;
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
            double roundedSum = Math.Round(cartItems.Sum(x => x.ItemPrice * x.Quantity), 3, MidpointRounding.AwayFromZero);
            // create order object
            Order newOrder = new Order();
            newOrder.TotalAmount = roundedSum;
            newOrder.TableNumber = tableNo;
            newOrder.IsOccupied = 1;

            // add order object to database
            dbContext.Orders.Add(newOrder);

            dbContext.SaveChanges();

            OrderItem orderItem;
            // get all items
            foreach (Cart currentItem in cartItems)
            {
                orderItem = new OrderItem();

                Item item = dbContext.Items.Where(x => x.ItemName == currentItem.ItemName).FirstOrDefault()!;

                orderItem.OrderId = newOrder.OrderId;
                orderItem.ItemId = item.ItemId;
                orderItem.Quantity = currentItem.Quantity;
                orderItem.Subtotal = roundedSum;

                dbContext.OrderItems.Add(orderItem);

                dbContext.SaveChanges();
            }

            MessageBox.Show("Order placed successfully.");
            this.Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;

            // Get the select item from listview
            ListViewItem clickedItem = listView.GetItemAt(e.X, e.Y);

            // make sure an item was clicked
            if (clickedItem != null)
            {
                // create item object of selected item
                Item currentItem = (Item)clickedItem.Tag;
                // add item to the cart
                AddItem(currentItem.ItemName, currentItem.Price);
                // remove focus after selecting item
                label2.Focus();
            }
        }

        // method to add item to cart
        private void AddItem(string itemName, double itemPrice)
        {
#nullable disable
            // Check if the item already exists in the list
            Cart existingItem = cartItems.Where(x => x.ItemName == itemName).FirstOrDefault();

            // if the item was previously added to the cart, update quantity of that item
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                // create and add new item to the cart if it was not previously added
                Cart newItem = new Cart
                {
                    ItemName = itemName,
                    Quantity = 1,
                    ItemPrice = (float)itemPrice
                };

                cartItems.Add(newItem);
            }
            // update list box
            updateDisplayedItems();
        }

        // method to delete item from cart
        private void ReduceQuantity()
        {
            // get the selected index
            int selectedIndex = itemsListBox.SelectedIndex;

            // check if user clicks on an item and not on an empty space
            if (selectedIndex != -1)
            {
                // get selected item from the listbox
                string selectedItemText = itemsListBox.Items[selectedIndex].ToString()!;
                string itemName = selectedItemText.Split('-')[0].Trim(); // Extract item name

                // get selected item from cart
                Cart selectedItem = cartItems.Find(x => x.ItemName == itemName)!;

                // reduce the quantity
                selectedItem.Quantity--;

                // remove the item from the list if quantity becomes 0
                if (selectedItem.Quantity == 0)
                {
                    cartItems.Remove(selectedItem);
                    itemsListBox.Items.RemoveAt(selectedIndex);
                }

                // update list box
                updateDisplayedItems();
            }
        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsListBox.SelectedIndexChanged -= itemsListBox_SelectedIndexChanged;
            try
            {
                // reduce quantity of selected item by 1
                ReduceQuantity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            itemsListBox.SelectedIndexChanged += itemsListBox_SelectedIndexChanged;
        }
#nullable restore
        // method used to update the items displayed in the listbox
        private void updateDisplayedItems()
        {
            // clear all items
            itemsListBox.Items.Clear();

            // add all items to update listbox
            foreach (Cart cartitem in cartItems)
            {
                itemsListBox.Items.Add(cartitem.ItemName + " - " + cartitem.ItemPrice + " BD - Quantity: " + cartitem.Quantity);
            }

            // calculate and display the total price
            decimal totalPrice = (decimal)cartItems.Sum(x => x.ItemPrice * x.Quantity);
            totalPriceTxt.Text = totalPrice + " BD";
        }

        private void NewOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            landingForm.UpdateTables();
        }
    }
}
