using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestReportRender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.test_sml_screen1._textBoxChanged += Test_sml_screen1__textBoxChanged;
        }

        private void Test_sml_screen1__textBoxChanged(object sender, string name)
        {
            string value = this.test_sml_screen1._getDataStr(name);
            Console.WriteLine("TextBox Changed: " + name + ":" + value);
        }

        private void testRenderReportButton_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyDown: " + e.KeyCode.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Your logic here
                e.Handled = true; // Mark the event as handled
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            report_test_render testreport = new report_test_render();
            testreport.StartReport();

        }
    }
}
