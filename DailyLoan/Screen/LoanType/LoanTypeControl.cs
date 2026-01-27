using DailyLoan.Control;
using DailyLoan.Data.Repository;
using DailyLoan.Screen.LoanType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.LoanType
{
    public class LoanTypeControl : DailyLoan.Control.ManageDataList
    {
        private LoanTypeDetailScreen loanTypeDetailScreen1;
        LoanTypeRepository loanTypeRepository = new LoanTypeRepository();

        public LoanTypeControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 30, ColumnCode = "code", ColumnName = "รหัส" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 70, ColumnCode = "name_1", ColumnName = "ชื่อ" });
            this._dataListGrid.Invalidate();

            this.loanTypeDetailScreen1.ReadOnly = true;
        }

        protected override void ChangeFormMode(bool isEdit)
        {
            this.loanTypeDetailScreen1.ReadOnly = !isEdit;
        }


        protected override string LoadDataListQuery()
        {
            return "select * from mst_loan_type ";
        }

        protected override void ClearScreen()
        {
            this.loanTypeDetailScreen1._clear();
            this.loanTypeDetailScreen1._enabedControl("code", true);
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            this.ClearScreen();
            string code = selectedRow["code"].ToString();

            this.loanTypeDetailScreen1._enabedControl("code", false);

            DailyLoan.Data.Models.LoanType loantype = loanTypeRepository.GetLoanTypeByCode(code);
            this.loanTypeDetailScreen1.LoadData(loantype);

            return base.LoadDataToScreen(selectedRow, isEdit);
        }

        protected override bool OnSaveData()
        {
            var loanType = this.loanTypeDetailScreen1.GetLoanTypeData();
            if (this.formMode == FormMode.EDIT)
            {
                this.loanTypeRepository.UploadLoanType(loanType);
            }
            else
            {
                this.loanTypeRepository.CreateLoanType(loanType);
            }
            return true;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string code = rowSelected["code"].ToString();
                var loanType = loanTypeRepository.GetLoanTypeByCode(code);
                loanTypeRepository.DeleleteLoanType(code);

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.loanTypeDetailScreen1 = new DailyLoan.Screen.LoanType.LoanTypeDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.titlePanel.Title = "ประเภทเงินกู้";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loanTypeDetailScreen1);
            // 
            // loanTypeDetailScreen1
            // 
            this.loanTypeDetailScreen1._isChange = false;
            this.loanTypeDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this.loanTypeDetailScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loanTypeDetailScreen1.Location = new System.Drawing.Point(0, 0);
            this.loanTypeDetailScreen1.Name = "loanTypeDetailScreen1";
            this.loanTypeDetailScreen1.Size = new System.Drawing.Size(365, 535);
            this.loanTypeDetailScreen1.TabIndex = 0;
            // 
            // LoanTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "LoanTypeControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }



    }
}
