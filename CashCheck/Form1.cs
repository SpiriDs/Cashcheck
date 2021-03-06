﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashCheck
{
    public partial class Form1 : Form

    //test Comment for check how git is working in visual Studio
    {
        // Fields in the Form
        Guy joe;
        Guy bob;
        int bank = 100;

        // Update the Form after a Transaction
        public void UpdateForm()
        {
            joesCashLabel.Text = joe.Name + " has $ " + joe.Cash;
            bobsCashLabel.Text = bob.Name + " has $ " + bob.Cash;
            bankCashLabel.Text = "The Bank has $ " + bank;
        }
        public Form1()
        {
            InitializeComponent();
            joe = new Guy() { Cash = 50, Name = "Joe" }; //Other Method to initalize an object
            //joe.Name = "Joe";
            //joe.Cash = 50;

            bob = new Guy();
            bob.Name = "Bob";
            bob.Cash = 100;

            UpdateForm();

            //UpdateForm is enough to initialize the Form on the first time, not have to repeate the code
            //joesCashLabel.Text = joe.Name + " has $" + joe.Cash;
            //bobsCashLabel.Text = bob.Name + " has $" + bob.Cash;
            //bankCashLabel.Text = "The Bank has $ " + bank;

            button1.Text = "Give $10 to Joe";
            button2.Text = "Receive $5 from Bob";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bank >= 10)
            {
                bank -= joe.ReceiveCash(10);
                UpdateForm();
            }
            else
            {
                MessageBox.Show("The bank is out of money.", "Bank says...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bank += bob.GiveCash(5);
            UpdateForm();
        }

        private void joeGivesToBob_Click(object sender, EventArgs e)
        {
            //joe.Cash -= joe.GiveCash(10);
            //bob.Cash += bob.ReceiveCash(10);

            //other better way to asign the action
            //bob.ReceiveCash(10);
            //joe.GiveCash(10);

            //More short, ...less lines
            bob.ReceiveCash(joe.GiveCash(10));
            UpdateForm();
        }

        private void bobGivesToJoe_Click(object sender, EventArgs e)
        {
            //joe.Cash += joe.ReceiveCash(5);
            //bob.Cash -= bob.GiveCash(5);

            //other better way to asign the action
            //joe.ReceiveCash(5);
            //joe.GiveCash(5);

            //More short, ...less lines
            joe.ReceiveCash(bob.GiveCash(5));

            UpdateForm();
        }
    }
}
