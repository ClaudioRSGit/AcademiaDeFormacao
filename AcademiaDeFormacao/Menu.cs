﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //Colocar border no Form
using AcademiaDeFormacao.UserControls;
using System.Threading;

namespace TryProject
{
    public partial class Menu : Form
    {
        #region Colocar border form
        //Isto serve para colocar border no form 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
                    int nLeftRect,
                    int nTopRect,
                    int nRightRect,
                    int nBottomRect,
                    int nWidthEllipse,
                    int nHeightEllipse
            );
        #endregion



        public Menu(string userName, string userRole)
        {
            InitializeComponent();
            addEmployee1.Hide();
            calculateSalary1.Hide();
            contracts1.Hide();
            this.AuthenticatedUser = userName;
            this.UserRole = userRole;
            lbl_DisplayUserName.Text = userName;
            UserRole = userRole;
            //Colocar border no Form
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,25,25));
            //MessageBox.Show(UserRole.ToString());
        }

        public string AuthenticatedUser { get; set; }
        public string UserRole { get; set; } 


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addEmployee1.Show();
            welcomePage1.Hide();
            calculateSalary1.Hide();
            contracts1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            welcomePage1.Hide();
            addEmployee1.Hide();
            calculateSalary1.Hide();
            contracts1.Show();
        }

        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            welcomePage1.Hide();
            addEmployee1.Hide();
            calculateSalary1.Show();
            contracts1.Hide();
            //exportData1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            welcomePage1.Show();
            addEmployee1.Hide();
            calculateSalary1.Hide();
            contracts1.Hide();
            //exportData1.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            welcomePage1.Hide();
            addEmployee1.Hide();
            calculateSalary1.Hide();
            contracts1.Show();
            //exportData1.Hide();
        }

        private void lbl_usernameTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //exportData1.Show();
            welcomePage1.Hide();
            calculateSalary1.Hide();
            contracts1.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //exportData1.Hide();
            welcomePage1.Hide();
            calculateSalary1.Hide();
            contracts1.Hide();
            editProfile1 = new EditProfile(AuthenticatedUser);
            editProfile1.Show();
        }
    }
}
