using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Move(object sender, EventArgs e)
        {
            Console.WriteLine("Move");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load");
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            Console.WriteLine("VisibleChanged");
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Activated");
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("Shown");
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Paint");
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            Console.WriteLine("Deactivate");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("FormClosing");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("FormClosed");
        }
    }
}
