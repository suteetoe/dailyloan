using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public partial class ReportMenu : UserControl
    {
        public ReportMenu()
        {
            InitializeComponent();
            this.listView1.Items.Clear();

            this.listView1.Items.AddRange(new ListViewItem[] {
                new ListViewItem(report_ar_balance.REPORT_NAME, 0) { Tag = "REPORT_AR_BALANCE" },
                new ListViewItem( report_ar_contract_payment.REPORT_NAME, 0) { Tag = "REPORT_AR_CONTRACT_PAYMENT" },
                new ListViewItem(report_sale_summary.REPORT_NAME, 0) { Tag = "REPORT_SALE_SUMMARY" },
                new ListViewItem(report_contract_npl.REPORT_NAME, 0) { Tag = "REPORT_CONTRACT_NPL" },
                new ListViewItem(report_business_performance.REPORT_NAME, 0) { Tag = "REPORT_BUSINESS_PERFORMANCE" },
                new ListViewItem(report_contract_payment.REPORT_NAME, 0) { Tag = "REPORT_CONTRACT_PAYMENT" }
            });
            // report list

            this.Load += ReportMenu_Load;
            this.SizeChanged += ReportMenu_SizeChanged;
            this.listView1.ClientSizeChanged += ListView1_ClientSizeChanged;

            // this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.ItemActivate += ListView1_ItemActivate;
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            listView1_SelectedIndexChanged(sender, null);
        }

        private void ReportMenu_Load(object sender, EventArgs e)
        {
            resizeListView();
        }

        private void ReportMenu_SizeChanged(object sender, EventArgs e)
        {
            resizeListView();
        }

        private void ListView1_ClientSizeChanged(object sender, EventArgs e)
        {
            resizeListView();
        }

        void resizeListView()
        {
            this.listView1.TileSize = new Size(this.listView1.ClientSize.Width, this.listView1.TileSize.Height);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string report_name = selectedItem.Text;
                string report_tag = selectedItem.Tag.ToString();
                //MessageBox.Show(selectedItem.Tag.ToString());

                // popup report condition
                switch (report_tag)
                {
                    case "REPORT_AR_BALANCE":
                        {
                            report_ar_balance ar_balance_report = new report_ar_balance();
                            ar_balance_report.StartReport();
                        }
                        break;
                    case "REPORT_AR_CONTRACT_PAYMENT":
                        {
                            report_ar_contract_payment report_ar_contract_payment = new report_ar_contract_payment();
                            report_ar_contract_payment.StartReport();
                        }
                        break;
                    case "REPORT_SALE_SUMMARY":
                        {
                            report_sale_summary report_sale_summary = new report_sale_summary();
                            report_sale_summary.StartReport();
                        }
                        break;
                    case "REPORT_CONTRACT_NPL":
                        {
                            report_contract_npl report_contract_npl = new report_contract_npl();
                            report_contract_npl.StartReport();
                        }
                        break;
                    case "REPORT_BUSINESS_PERFORMANCE":
                        {
                            report_business_performance report_business_performance = new report_business_performance();
                            report_business_performance.StartReport();
                        }
                        break;
                    case "REPORT_CONTRACT_PAYMENT":
                        {
                            report_contract_payment report_contract_payment = new report_contract_payment();
                            report_contract_payment.StartReport();
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("ยังไม่สามารถใช้งาน " + report_name + " นี้ได้ในขณะนี้");
                        }
                        break;
                }
            }

        }
    }
}
