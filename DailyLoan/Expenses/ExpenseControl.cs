using DailyLoan.Control;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Expenses
{
    public class ExpenseControl : Control.ManageDataList
    {
        private ExpenseDetailScreeen expenseDetailScreeen1;
        ExpenseRepository expenseRepository = new ExpenseRepository();

        public ExpenseControl()
        {
            InitializeComponent();
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);

            this._dataListGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 20, ColumnCode = "doc_date", ColumnName = "วันที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "doc_no", ColumnName = "เลขที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 40, ColumnCode = "remark", ColumnName = "หมายเหตุ" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "total_amount", ColumnName = "จำนวนเงิน", Format = numberFormat });

            this.expenseDetailScreeen1.ReadOnly = true;
        }

        protected override void ChangeFormMode(bool isEdit)
        {
            this.expenseDetailScreeen1.ReadOnly = !isEdit;
        }

        protected override string SortField()
        {
            return " order by doc_date ";
        }

        protected override string LoadDataListQuery()
        {
            string filter = this.GetFilterCommand();
            string query = "SELECT doc_date, doc_no, remark, total_amount from txn_expense " + (filter.Length > 0 ? " WHERE " + filter : "");
            return query;
        }

        protected override void ClearScreen()
        {
            this.expenseDetailScreeen1._clear();
            this.expenseDetailScreeen1._enabedControl("doc_date", true);
            this.expenseDetailScreeen1._enabedControl("doc_no", true);
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            try
            {
                string docNo = selectedRow["doc_no"].ToString();
                var doc = expenseRepository.GetExpenseByDocNo(docNo);

                if (doc != null)
                {
                    this.expenseDetailScreeen1.SetExpenseData(doc);
                    this.ChangeFormMode(isEdit);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        protected override bool OnSaveData()
        {
            string requireText = this.expenseDetailScreeen1._checkEmtryField();

            if (requireText != "")
            {
                MessageBox.Show(requireText, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DailyLoan.Data.Models.Expense expense = this.expenseDetailScreeen1.GetExpenseData();
            if (this.formMode == FormMode.EDIT)
            {
                expenseRepository.UpdateExpense(expense);
            }
            else
            {
                expenseRepository.CreateExpense(expense);
            }
            return true;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                expenseRepository.DeleteExpense(rowSelected["code"]);

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
            this.expenseDetailScreeen1 = new DailyLoan.Expenses.ExpenseDetailScreeen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Title = "ค่าใช้จ่าย";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.expenseDetailScreeen1);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // expenseDetailScreeen1
            // 
            this.expenseDetailScreeen1._isChange = false;
            this.expenseDetailScreeen1.BackColor = System.Drawing.Color.Transparent;
            this.expenseDetailScreeen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenseDetailScreeen1.Location = new System.Drawing.Point(0, 0);
            this.expenseDetailScreeen1.Name = "expenseDetailScreeen1";
            this.expenseDetailScreeen1.ReadOnly = false;
            this.expenseDetailScreeen1.Size = new System.Drawing.Size(359, 529);
            this.expenseDetailScreeen1.TabIndex = 0;
            // 
            // ExpenseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "ExpenseControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
