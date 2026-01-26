using DailyLoan.Data.Repository;
using DailyLoan.Screen.Route;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Loan
{
    public partial class ChangeContractRouteForm : Form
    {
        DailyLoan.Data.Models.Contract contract;

        public ChangeContractRouteForm(DailyLoan.Data.Models.Contract contract)
        {
            this.contract = contract;
            InitializeComponent();
        }

        private void _processButton_Click(object sender, EventArgs e)
        {
            string confirmChangeRouteMessage = "คุณต้องการเปลี่ยนสายงานให้สัญญาเลขที่ " + this.contract.contract_no + " ใช่หรือไม่?";
            if (MessageBox.Show(confirmChangeRouteMessage, "ยืนยันการเปลี่ยนสายงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string routeCode = this._changeContractRouteScreenTop1._getDataStr("route_code");
                RouteRepository routeRepository = new RouteRepository();
                var route = routeRepository.GetRouteByCode(routeCode);
                if (route != null)
                {
                    DailyLoan.Data.Repository.ContractRepository contractRepository = new DailyLoan.Data.Repository.ContractRepository();
                    this.contract.route_code = route.code;
                    contractRepository.UpdateContractRoute(this.contract);

                    MessageBox.Show("เปลี่ยนสายงานสำเร็จ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลสายงานที่ระบุ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


}
