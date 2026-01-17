using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Expenses
{
    public class ExpenseControl : Control.ManageDataList
    {
        private ExpenseDetailScreeen expenseDetailScreeen1;

        public ExpenseControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 20, ColumnCode = "doc_date", ColumnName = "วันที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "doc_no", ColumnName = "เลขที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 40, ColumnCode = "remark", ColumnName = "หมายเหตุ" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "amount", ColumnName = "จำนวนเงิน" });
        }

        private void InitializeComponent()
        {
            this.expenseDetailScreeen1 = new DailyLoan.Expenses.ExpenseDetailScreeen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.expenseDetailScreeen1);
            // 
            // expenseDetailScreeen1
            // 
            this.expenseDetailScreeen1._isChange = false;
            this.expenseDetailScreeen1.BackColor = System.Drawing.Color.Transparent;
            this.expenseDetailScreeen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expenseDetailScreeen1.Location = new System.Drawing.Point(0, 0);
            this.expenseDetailScreeen1.Name = "expenseDetailScreeen1";
            this.expenseDetailScreeen1.Size = new System.Drawing.Size(359, 116);
            this.expenseDetailScreeen1.TabIndex = 0;
            this.titlePanel.Title = "ค่าใช้จ่าย";
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
