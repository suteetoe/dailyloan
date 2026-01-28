using DailyLoan.Control;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.ContractPayment
{
    public class ContractPaymentControl : DailyLoan.Control.ManageDataList
    {
        private _contractPaymentDetailScreen _contractPaymentDetailScreen1;
        ContractPayRepository contractPayRepository = new ContractPayRepository();
        Domain.ContractProcess contractProcess = new Domain.ContractProcess();

        public ContractPaymentControl()
        {
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 15, ColumnCode = "doc_date", ColumnName = "วันที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "doc_no", ColumnName = "เลขที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "contract_no", ColumnName = "สัญญา", IsQuery = false });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 40, ColumnCode = "customer", ColumnName = "ลูกค้า", IsQuery = false });
            this._dataListGrid.AddGridColumn(new SMLControl.GridDecimalColumn() { WidthPercent = 15, ColumnCode = "total_amount", ColumnName = "จำนวนเงิน", Format = numberFormat });

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสลูกค้า", ColumnCode = "cp.contract_no", WidthPercent = 0, IsHide = true });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสลูกค้า", ColumnCode = "mst_customer.code", WidthPercent = 0, IsHide = true });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อลูกค้า", ColumnCode = "mst_customer.name_1", WidthPercent = 0, IsHide = true });

            this._dataListGrid._calcPersentWidthToScatter();
            this._dataListGrid.Invalidate();

            this._saveButton.Visible = false;
            this._cancelButton.Visible = false;
            this._addButton.Visible = false;

            bool visibleDeletebutton = false;
            if ((int)App.LoggedUser.Role > 0)
            {
                visibleDeletebutton = true;
            }

            this._deleteButton.Visible = visibleDeletebutton;
        }

        protected override string LoadDataListQuery()
        {
            string filter = this.GetFilterCommand();

            string query =
                @"SELECT cp.doc_date, cp.doc_no, cp.contract_no, cp.total_amount, (cc.customer_code || '~' || mst_customer.name_1 ) as customer 
                , mst_customer.code
                , mst_customer.name_1
                FROM txn_payment AS cp 
                JOIN txn_contract AS cc on cc.contract_no = cp.contract_no 
                JOIN mst_customer on mst_customer.code = cc.customer_code 
                " + (filter.Length > 0 ? " WHERE " + filter : "");
            return query;
        }

        protected override string SortField()
        {
            return "order by doc_date  ";
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            try
            {
                string docNo = selectedRow["doc_no"].ToString();
                var contractPay = contractPayRepository.GetContractPaymentByDocNo(docNo);

                if (contractPay != null)
                {
                    this._contractPaymentDetailScreen1.LoadContractPayData(contractPay);

                    return true;
                }
                return false;

            }
            catch
            {

            }
            return false;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string doc_no = rowSelected["doc_no"];
                var payment = contractPayRepository.GetContractPaymentByDocNo(doc_no);
                if (payment == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการลบ", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                contractPayRepository.DeletePayment(payment.doc_no);

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                contractProcess.StartProcessPayment(payment.contract_no);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้\n" + ex.Message, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        private void InitializeComponent()
        {
            this._contractPaymentDetailScreen1 = new DailyLoan.Screen.ContractPayment._contractPaymentDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.EnableEditMode = false;
            // 
            // titlePanel
            // 
            this.titlePanel.Title = "การชำระเงิน";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._contractPaymentDetailScreen1);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // _contractPaymentDetailScreen1
            // 
            this._contractPaymentDetailScreen1._isChange = false;
            this._contractPaymentDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this._contractPaymentDetailScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contractPaymentDetailScreen1.Location = new System.Drawing.Point(0, 0);
            this._contractPaymentDetailScreen1.Name = "_contractPaymentDetailScreen1";
            this._contractPaymentDetailScreen1.ReadOnly = false;
            this._contractPaymentDetailScreen1.Size = new System.Drawing.Size(359, 529);
            this._contractPaymentDetailScreen1.TabIndex = 8;
            // 
            // ContractPaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "ContractPaymentControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
