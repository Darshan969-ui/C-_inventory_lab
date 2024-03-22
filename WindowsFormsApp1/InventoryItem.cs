using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InventoryItem : Form
    {
        private Form1 mainForm;
        public List<Inventory> inventoryItems = InventoryDB.GetItems();


        public InventoryItem(Form1 form)
        {
            InitializeComponent();

            mainForm = form;

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // I have addded IOException over here. 
            try
            {
                if (!int.TryParse(textBoxItemno.Text, out int itemno) || itemno <= 0)
                {
                    MessageBox.Show("Please enter a valid item number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Description = textBoxDesc.Text;
                if (string.IsNullOrWhiteSpace(Description))
                {
                    MessageBox.Show("Please enter a description for the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price for the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (price == 0)
                {
                    MessageBox.Show("Price cannot be zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Inventory newItem = new Inventory(itemno, Description, price);
                inventoryItems.Add(newItem);
                InventoryDB.SaveItems(inventoryItems);
                mainForm.getinventory();
                MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(IOException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
