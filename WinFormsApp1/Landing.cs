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

        public Landing()
        {
            InitializeComponent();
            dbContext = new ProjectDBContext();
            random = new Random();
            btnCloseForm.Visible = false; // hide button that closes forms displayed over landing form as there are none being displayed upon starting the application
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
            OpenForm(new New_Order(), sender);
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
            }
        }

        private void Landing_Load(object sender, EventArgs e)
        {

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
        }

        // method to set colors for tables in landing page
        private void TableColors()
        {

        }


        // method to display order of table clicked on
        private void TableClicked(int tableNo)
        {

        }

        // following events are only for changing color of controls
        private void tableNo1Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo1Pnl.BackColor;
            tableNo1Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo1Pnl.BackColor, -0.1);
        }

        private void tableNo1Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo1Pnl.BackColor = tempColor;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo1Pnl.BackColor;
            tableNo1Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo1Pnl.BackColor, -0.1);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            tableNo1Pnl.BackColor = tempColor;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo1Pnl.BackColor;
            tableNo1Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo1Pnl.BackColor, -0.1);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            tableNo1Pnl.BackColor = tempColor;
        }

        private void tableNo2Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo2Pnl.BackColor;
            tableNo2Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo2Pnl.BackColor, -0.1);
        }

        private void tableNo2Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo2Pnl.BackColor = tempColor;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo2Pnl.BackColor;
            tableNo2Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo2Pnl.BackColor, -0.1);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            tableNo2Pnl.BackColor = tempColor;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo2Pnl.BackColor;
            tableNo2Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo2Pnl.BackColor, -0.1);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            tableNo2Pnl.BackColor = tempColor;
        }

        private void tableNo3Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo3Pnl.BackColor;
            tableNo3Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo3Pnl.BackColor, -0.1);
        }

        private void tableNo3Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo3Pnl.BackColor = tempColor;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo3Pnl.BackColor;
            tableNo3Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo3Pnl.BackColor, -0.1);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            tableNo3Pnl.BackColor = tempColor;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo3Pnl.BackColor;
            tableNo3Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo3Pnl.BackColor, -0.1);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            tableNo3Pnl.BackColor = tempColor;
        }

        private void tableNo4Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo4Pnl.BackColor;
            tableNo4Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo4Pnl.BackColor, -0.1);
        }

        private void tableNo4Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo4Pnl.BackColor = tempColor;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo4Pnl.BackColor;
            tableNo4Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo4Pnl.BackColor, -0.1);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            tableNo4Pnl.BackColor = tempColor;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo4Pnl.BackColor;
            tableNo4Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo4Pnl.BackColor, -0.1);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            tableNo4Pnl.BackColor = tempColor;
        }

        private void tableNo5Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo5Pnl.BackColor;
            tableNo5Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo5Pnl.BackColor, -0.1);
        }

        private void tableNo5Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo5Pnl.BackColor = tempColor;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo5Pnl.BackColor;
            tableNo5Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo5Pnl.BackColor, -0.1);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            tableNo5Pnl.BackColor = tempColor;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo5Pnl.BackColor;
            tableNo5Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo5Pnl.BackColor, -0.1);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            tableNo5Pnl.BackColor = tempColor;
        }

        private void tableNo6Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo6Pnl.BackColor;
            tableNo6Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo6Pnl.BackColor, -0.1);
        }

        private void tableNo6Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo6Pnl.BackColor = tempColor;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo6Pnl.BackColor;
            tableNo6Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo6Pnl.BackColor, -0.1);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            tableNo6Pnl.BackColor = tempColor;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo6Pnl.BackColor;
            tableNo6Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo6Pnl.BackColor, -0.1);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            tableNo6Pnl.BackColor = tempColor;
        }

        private void tableNo7Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo7Pnl.BackColor;
            tableNo7Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo7Pnl.BackColor, -0.1);
        }

        private void tableNo7Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo7Pnl.BackColor = tempColor;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo7Pnl.BackColor;
            tableNo7Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo7Pnl.BackColor, -0.1);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            tableNo7Pnl.BackColor = tempColor;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo7Pnl.BackColor;
            tableNo7Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo7Pnl.BackColor, -0.1);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            tableNo7Pnl.BackColor = tempColor;
        }

        private void tableNo8Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo8Pnl.BackColor;
            tableNo8Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo8Pnl.BackColor, -0.1);
        }

        private void tableNo8Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo8Pnl.BackColor = tempColor;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo8Pnl.BackColor;
            tableNo8Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo8Pnl.BackColor, -0.1);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            tableNo8Pnl.BackColor = tempColor;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo8Pnl.BackColor;
            tableNo8Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo8Pnl.BackColor, -0.1);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            tableNo8Pnl.BackColor = tempColor;
        }

        private void tableNo9Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo9Pnl.BackColor;
            tableNo9Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo9Pnl.BackColor, -0.1);
        }

        private void tableNo9Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo9Pnl.BackColor = tempColor;
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo9Pnl.BackColor;
            tableNo9Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo9Pnl.BackColor, -0.1);
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            tableNo9Pnl.BackColor = tempColor;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo9Pnl.BackColor;
            tableNo9Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo9Pnl.BackColor, -0.1);
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            tableNo9Pnl.BackColor = tempColor;
        }

        private void tableNo10Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo10Pnl.BackColor;
            tableNo10Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo10Pnl.BackColor, -0.1);
        }

        private void tableNo10Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo10Pnl.BackColor = tempColor;
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo10Pnl.BackColor;
            tableNo10Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo10Pnl.BackColor, -0.1);
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            tableNo10Pnl.BackColor = tempColor;
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo10Pnl.BackColor;
            tableNo10Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo10Pnl.BackColor, -0.1);
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            tableNo10Pnl.BackColor = tempColor;
        }

        private void tableNo11Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo11Pnl.BackColor;
            tableNo11Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo11Pnl.BackColor, -0.1);
        }

        private void tableNo11Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo11Pnl.BackColor = tempColor;
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo11Pnl.BackColor;
            tableNo11Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo11Pnl.BackColor, -0.1);
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            tableNo11Pnl.BackColor = tempColor;
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo11Pnl.BackColor;
            tableNo11Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo11Pnl.BackColor, -0.1);
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            tableNo11Pnl.BackColor = tempColor;
        }

        private void tableNo12Pnl_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo12Pnl.BackColor;
            tableNo12Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo12Pnl.BackColor, -0.1);
        }

        private void tableNo12Pnl_MouseLeave(object sender, EventArgs e)
        {
            tableNo12Pnl.BackColor = tempColor;
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo12Pnl.BackColor;
            tableNo12Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo12Pnl.BackColor, -0.1);
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            tableNo12Pnl.BackColor = tempColor;
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            tempColor = tableNo12Pnl.BackColor;
            tableNo12Pnl.BackColor = ThemeColor.ChangeColorBrightness(tableNo12Pnl.BackColor, -0.1);
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            tableNo12Pnl.BackColor = tempColor;
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

        private void tableNo1Pnl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("lol");
        }
    }
}
