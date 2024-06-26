﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public  List<Inventory> inventorylist = new List<Inventory>();

        public Form1()
        {
            InitializeComponent();
        }

        public void getinventory()
        {
            inventorylist = InventoryDB.GetItems();
            updateListbox();

        }
        public void updateListbox()
        {
            listBox1.Items.Clear();
            foreach (Inventory item in inventorylist)
            {
                listBox1.Items.Add(item);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getinventory();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Enabled)
                {
                    InventoryItem inventory = new InventoryItem(this);

                    inventory.Show();

                }
            }catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = listBox1.SelectedIndex;

                        if (selectedIndex >= 0 && selectedIndex < inventorylist.Count)
                        {
                            inventorylist.RemoveAt(selectedIndex);
                            InventoryDB.SaveItems(inventorylist);
                            updateListbox();
                            MessageBox.Show($"Item at index {selectedIndex} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Selected index is out of range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
