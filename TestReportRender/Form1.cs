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
        }

        private void testRenderReportButton_Click(object sender, EventArgs e)
        {
            report_test_render testreport = new report_test_render();
            testreport.StartReport();
        }
    }
}
