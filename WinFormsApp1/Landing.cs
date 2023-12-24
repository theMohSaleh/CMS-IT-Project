using Microsoft.EntityFrameworkCore;
using POS;
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
    public partial class Landing : Form
    {
        // properties
        private ProjectDBContext dbContext;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form currentForm;
        private Color tempColor;
        private List<Panel> tablePanels;

        public Landing()
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
            random = new Random();
            btnCloseForm.Visible = false; // hide button that closes forms displayed over landing form as there are none being displayed upon starting the application
            // get all tables panels in list
            tablePanels = new List<Panel>
        {
            tableNo1Pnl,
            tableNo2Pnl,
            tableNo3Pnl,
            tableNo4Pnl,
            tableNo5Pnl,
            tableNo6Pnl,
            tableNo7Pnl,
            tableNo8Pnl,
            tableNo9Pnl,
            tableNo10Pnl,
            tableNo11Pnl,
            tableNo12Pnl
        };
            // assign the order create button for all tables
            tableNo1Pnl.Tag = btnNewOrder;
            tableNo2Pnl.Tag = btnNewOrder;
            tableNo3Pnl.Tag = btnNewOrder;
            tableNo4Pnl.Tag = btnNewOrder;
            tableNo5Pnl.Tag = btnNewOrder;
            tableNo6Pnl.Tag = btnNewOrder;
            tableNo7Pnl.Tag = btnNewOrder;
            tableNo8Pnl.Tag = btnNewOrder;
            tableNo9Pnl.Tag = btnNewOrder;
            tableNo10Pnl.Tag = btnNewOrder;
            tableNo11Pnl.Tag = btnNewOrder;
            tableNo12Pnl.Tag = btnNewOrder;
        }

        // method to select a random color
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            // check if color is selected and select a new one
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color); // return color palette
        }

        // method to highlight selected button
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                // check if user clicks on a different button
                if (currentButton != (Button)btnSender)
                {
                    // disable previous button
                    DisableButton();
                    Color color = SelectThemeColor(); // get a random color from the list
                    currentButton = (Button)btnSender; // get the currently selected button
                    // check style of current button
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                    // adjust panel color to match currently selected color
                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    // save current colors
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseForm.Visible = true;
                }
            }
        }

        // method to unhighlight selected button
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 52);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }

        // method to open respective forms in the container
        private void OpenForm(Form form, object btnSender)
        {
            // check if there is a form being displayed
            if (currentForm != null)
            {
                // close the current form
                currentForm.Close();
            }

            // highlight button
            ActivateButton(btnSender);

            // set new form
            currentForm = form;
            // style elements
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(form);
            this.panelDesktopPanel.Tag = form;
            // bring form to front and show over landing page
            form.BringToFront();
            form.Show();
            lblTitle.Text = form.Text;
        }

        // display new orders form event
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            OpenForm(new NewOrder(), sender);
        }

        // display current unpaid orders form event
        private void btnCurrentOrders_Click(object sender, EventArgs e)
        {
            OpenForm(new CurrentOrdersFrm(), sender);
        }

        // display menu form event
        private void btnMenu_Click(object sender, EventArgs e)
        {
            OpenForm(new MenuItemsFrm(), sender);
        }

        // method to close a form
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            // check if there is a form being displayed
            if (currentForm != null)
            {
                // close the form and call reset method
                currentForm.Close();
                Reset();
                UpdateTables();
            }
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            UpdateTables();
        }

        private void Reset()
        {
            // call method to disable button click highlight
            DisableButton();
            // reset form elements to original state
            lblTitle.Text = "Select a Table";
            panelTitle.BackColor = Color.FromArgb(90, 119, 121);
            panelLogo.BackColor = Color.FromArgb(38, 38, 52);
            currentButton = null;
            // hide close button
            btnCloseForm.Visible = false;

            UpdateTables();
        }

        // method to set colors for tables in landing page
        public void UpdateTables()
        {
            // get all current table orders info
            var tableOrders = dbContext.Orders.Where(x => x.TableNumber > 0 || x.IsPaid == 0).ToList();

            // check if any tables were found
            if (tableOrders.Count > 0)
            {
                // go though all orders found
                foreach (Order order in tableOrders)
                {
                    // loop through all panels
                    foreach (Panel panel in tablePanels)
                    {
                        // get panel number
                        int panelTableNumber = TableNumber(panel);

                        // check if panel's table number matches the specified tableNumber
                        if (panelTableNumber == order.TableNumber)
                        {
                            // change color panel to occupied color
                            panel.BackColor = Color.DarkOrange;
                        }
                        // if table order has been paid for, reset table color 
                        else if (panelTableNumber == order.TableNumber && order.IsPaid == 1)
                        {
                            // reset the color of the panel
                            panel.BackColor = Color.SkyBlue;
                        }
                        // Replace YourEntity and yourCondition with actual entity and condition
                        bool doesNotExist = !dbContext.Orders.Any(x => x.TableNumber == panelTableNumber && x.IsPaid == 0);

                        if (doesNotExist)
                        {
                            panel.BackColor = Color.SkyBlue;
                        }
                    }
                }
            }
            else
            {
                // if no table was found reset all panels to default color
                foreach (Panel panel in tablePanels)
                {
                    panel.BackColor = Color.SkyBlue;
                }
            }
        }

        // method to create or display order of table clicked on
        private void TableClicked(int tableNo, object sender)
        {
            // variables
            bool tableHasOrder = false;

            // get all current table orders info
            var tableOrders = dbContext.Orders.Where(x => x.TableNumber > 0 || x.IsPaid == 0).ToList();
            // go through all current table orders
            foreach (Order order in tableOrders)
            {
                // if the clicked on table currently has an order change bool value
                if (order.TableNumber == tableNo)
                {
                    tableHasOrder = true;
                }
            }

            // if table has no current order open new order menu
            if (!tableHasOrder)
            {
                NewOrder newOrderFrm = new NewOrder(tableNo.ToString(), this);
                OpenForm(newOrderFrm, sender);
            }
            else
            {
                PayForOrderFrm payForm = new PayForOrderFrm(tableNo);
                DialogResult payDialog = payForm.ShowDialog();
                if (payDialog == DialogResult.OK)
                {
                    UpdateTables();
                }
            }
        }

        // method to get table number from panel design name
        private int TableNumber(Panel panel)
        {
            // variables
            string panelName = panel.Name;
            string prefix = "tableNo";  //prefix of panel name before number
            string suffix = "Pnl";      //suffix of panel name before number

            // extract number of table 
            string tableNumberString = panelName.Substring(prefix.Length, panelName.Length - prefix.Length - suffix.Length);

            // convert string to int 
            int tableNumber = int.Parse(tableNumberString);
            return tableNumber;
        }

        // decrease panel color when highlighting the panel
        private void decreasePanelBrightness(object sender, EventArgs e)
        {
            if (sender is Panel tablePanel)
            {
                tempColor = tablePanel.BackColor;
                // Modify the properties of the parent panel
                tablePanel.BackColor = ThemeColor.ChangeColorBrightness(tablePanel.BackColor, -0.1);
            }
            // Cast the sender to the Label type
            if (sender is Label label)
            {
                // Access the parent control (assumed to be a Panel)
                if (label.Parent is Panel currentTablePanel)
                {
                    tempColor = currentTablePanel.BackColor;
                    // Modify the properties of the parent panel
                    currentTablePanel.BackColor = ThemeColor.ChangeColorBrightness(currentTablePanel.BackColor, -0.1);
                }
            }
            if (sender is PictureBox tableImage)
            {
                // Access the parent control (assumed to be a Panel)
                if (tableImage.Parent is Panel currentTablePanel)
                {
                    tempColor = currentTablePanel.BackColor;
                    // Modify the properties of the parent panel
                    currentTablePanel.BackColor = ThemeColor.ChangeColorBrightness(currentTablePanel.BackColor, -0.1);
                }
            }
        }

        // restore panel color to original state when not hovering anymore
        private void restorePanelBrightness(object sender, EventArgs e)
        {
            if (sender is Panel tablePanel)
            {
                tablePanel.BackColor = tempColor;
            }
            // Cast the sender to the Label type
            if (sender is Label label)
            {
                // Access the parent control 
                if (label.Parent is Panel currentTablePanel)
                {
                    currentTablePanel.BackColor = tempColor;
                }
            }
            if (sender is PictureBox tableImage)
            {
                // Access the parent control 
                if (tableImage.Parent is Panel currentTablePanel)
                {
                    currentTablePanel.BackColor = tempColor;
                }
            }
        }

        // test event for adding pictures
        private void img_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string title = imgTxtBox.Text;
                byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                SaveImage(title, imageData);

                MessageBox.Show("Added " + title + " successfully.");
            }
        }

        public void SaveImage(string title, byte[] imageData)
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

        // call the tableclicked method and pass in the table numeber respective to the table clicked
        private void tablePanelClicked(object sender, EventArgs e)
        {
            int tableClickedNumber;
            if (sender is Panel tablePanel)
            {
                if (tablePanel != null && tablePanel.Tag is Button associatedButton)
                {
                    tableClickedNumber = TableNumber(tablePanel);
                    TableClicked(tableClickedNumber, associatedButton);
                }
            }
            if (sender is Label tableLabel)
            {
                // Access the parent control 
                if (tableLabel.Parent is Panel currentTablePanel)
                {
                    if (currentTablePanel != null && currentTablePanel.Tag is Button associatedButton)
                    {
                        tableClickedNumber = TableNumber(currentTablePanel);
                        TableClicked(tableClickedNumber, associatedButton);
                    }
                }

            }
            if (sender is PictureBox tablePicture)
            {
                // Access the parent control 
                if (tablePicture.Parent is Panel currentTablePanel)
                {
                    if (currentTablePanel != null && currentTablePanel.Tag is Button associatedButton)
                    {
                        tableClickedNumber = TableNumber(currentTablePanel);
                        TableClicked(tableClickedNumber, associatedButton);
                    }
                }
            }
        }
    }
}
