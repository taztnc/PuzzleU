using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ServicesClient
{
    public partial class FormUserName : Form
    {
        public FormUserName()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            var proxy = new PuzzleUService.PuzzleUServiceClient();
            int id = -1;
            string errorString = string.Empty;
            if (proxy.CreateUser(out id, out errorString, textBoxCreateUserName.Text))
                 this.textBoxCreateUserID.Text = id.ToString();
            else
                this.textBoxCreateUserID.Text = errorString;

            UpdateUI();
        }

        private void buttonGetUserName_Click(object sender, EventArgs e)
        {
            var proxy = new PuzzleUService.PuzzleUServiceClient();
            int id = -1;
            string errorString = string.Empty;
            if (proxy.GetUserID(out id, out errorString, textBoxGetUserName.Text))
                 this.textBoxGetUserID.Text = id.ToString();
            else
                this.textBoxGetUserID.Text = errorString;

            UpdateUI();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            string idStr = textBoxDeleteUserID.Text;
            int id = -1;
            if (int.TryParse(idStr, out id))
            {
                var proxy = new PuzzleUService.PuzzleUServiceClient();
                string errorString = string.Empty;


                if (proxy.DeleteUser(out errorString, id))
                    textBoxDeleteResult.Text = "User deleted";
                else
                    textBoxDeleteResult.Text = errorString;
            }
            else
                textBoxDeleteResult.Text = "Illegal User ID";


            UpdateUI();
            
        }

        private void UpdateUI()
        {
            listBoxUsers.Items.Clear();


            var proxy = new PuzzleUService.PuzzleUServiceClient();
            
            PuzzleUService.UserData[] usersData = null;
            string errorString = string.Empty;

            if (proxy.GetUsersData(out usersData, out errorString))
            {
                foreach (PuzzleUService.UserData userData in usersData)
                {
                    string listItem = string.Format("Username: {0}     , UserId: {1}", userData.Name, userData.ID.ToString());
                    listBoxUsers.Items.Add(listItem);
                }
            }
            else
                listBoxUsers.Items.Add(errorString);            
        }
    }
}
