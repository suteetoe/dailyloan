using DailyLoan.Data;
using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using SMLControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Control
{
    public partial class ManageDataList : UserControl
    {
        protected Boolean isEditMode = false;
        protected int totalRecord = 0;
        protected int totalPage = 1;
        protected int page = 1;
        protected int pageSize = 10;
        protected FormMode formMode = FormMode.VIEW;

        private Boolean _enableEditMode = true;

        public Boolean EnableEditMode
        {
            get
            {
                return this._enableEditMode;
            }

            set
            {
                this._enableEditMode = value;
            }
        }

        public Boolean EditMode
        {
            get { return isEditMode; }
            set { isEditMode = value; }
        }

        public ManageDataList()
        {
            InitializeComponent();

            this.SizeChanged += ManageDataList_SizeChanged;
            this.Load += ManageDataList_Load;
            this._dataListGrid._mouseClick += _dataListGrid__mouseClick;
            this._dataListGrid._mouseDoubleClick += _dataListGrid__mouseDoubleClick;
            this.ParentChanged += ManageDataList_ParentChanged;
            this.EnableActionButtons(this.isEditMode);
            OnLoadDataList();
        }


        private void ManageDataList_ParentChanged(object sender, EventArgs e)
        {
            _dataLoadingTimer.Start();
        }

        private void ManageDataList_SizeChanged(object sender, EventArgs e)
        {
            _dataLoadingTimer.Start();
        }

        private void ManageDataList_Load(object sender, EventArgs e)
        {
            _dataLoadingTimer.Start();
        }


        private void _dataListGrid__mouseClick(object sender, SMLControl.GridCellEventArgs e)
        {
            if (this.isEditMode)
            {
                bool cancelResult = CancelEditData();
                if (cancelResult == false)
                {
                    return;
                }
            }

            RowDataSelect selectedRow = new RowDataSelect();
            foreach (var col in this._dataListGrid._columnList)
            {
                SMLControl._columnType gridColumn = (SMLControl._columnType)col;
                string columnCode = gridColumn._originalName;

                string cellValue = "";
                if (gridColumn._type == 4)
                {
                    object dataDate = this._dataListGrid._cellGet(e._row, columnCode);
                    if (dataDate != null)
                    {
                        cellValue = Convert.ToDateTime(dataDate).ToString("yyyy-MM-dd", App.SystemCulture);
                    }
                }
                else 
                {
                    cellValue = this._dataListGrid._cellGet(e._row, columnCode).ToString();
                }

                selectedRow[columnCode] = cellValue;
            }

            formMode = FormMode.VIEW;
            bool canLoadData = this.LoadDataToScreen(selectedRow);
            if (canLoadData)
            {
                this._deleteButton.Enabled = true;
            }
        }

        private void _dataListGrid__mouseDoubleClick(object sender, SMLControl.GridCellEventArgs e)
        {
            if (this._enableEditMode == false)
                return;

            if (this.isEditMode)
            {
                bool cancelResult = CancelEditData();
                if (cancelResult == false)
                {
                    return;
                }
            }

            if (e._row >= 0 && e._row < this._dataListGrid._rowData.Count)
            {
                DialogResult editConfirmResult = MessageBox.Show("ต้องการแก้ไขข้อมูลใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (editConfirmResult == DialogResult.Yes)
                {
                    RowDataSelect selectedRow = new RowDataSelect();
                    foreach (var col in this._dataListGrid._columnList)
                    {
                        SMLControl._columnType gridColumn = (SMLControl._columnType)col;
                        string columnCode = gridColumn._originalName; string cellValue = "";

                        if (gridColumn._type == 4)
                        {
                            object dataDate = this._dataListGrid._cellGet(e._row, columnCode);
                            if (dataDate != null)
                            {
                                cellValue = Convert.ToDateTime(dataDate).ToString("yyyy-MM-dd", App.SystemCulture);
                            }
                        }
                        else
                        {
                            cellValue = this._dataListGrid._cellGet(e._row, columnCode).ToString();
                        }

                        selectedRow[columnCode] = cellValue;
                    }


                    formMode = FormMode.EDIT;
                    this.ChangeEditMode(true);
                    LoadDataToScreen(selectedRow, true);
                }
            }
        }

        void EnableActionButtons(bool editMode)
        {
            this._addButton.Enabled = !editMode;
            this._deleteButton.Enabled = false;
            this._saveButton.Enabled = editMode;
            this._cancelButton.Enabled = editMode;
        }

        void OnLoadDataList()
        {
            if (this._dataListGrid._rowPerPage != 0)
            {
                this.pageSize = this._dataListGrid._rowPerPage;
                this.LoadDataList();
            }
        }

        protected virtual void LoadDataList()
        {
            string loadDataQuery = this.LoadDataListQuery();
            if (loadDataQuery.Length > 0)
            {
                try
                {
                    string countRecordQuery = "SELECT COUNT(*) AS total_record FROM (" + loadDataQuery + ") AS temp_table";
                    DataSet ds = App.DBConnection.QueryData(countRecordQuery);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        var row = ds.Tables[0].Rows[0];
                        int totalRecord = Convert.ToInt32(row["total_record"]);
                        int totalPage = (int)Math.Ceiling((double)totalRecord / this.pageSize);
                        this.totalRecord = totalRecord;
                        this.totalPage = totalPage;
                        ds.Dispose();
                    }

                    Paginator paginator = new Paginator(this.page, this.pageSize);

                    string paginatedQuery = loadDataQuery + " " + paginator.GetPaginationQuery();
                    var dataSet = App.DBConnection.QueryData(paginatedQuery);
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        this._dataListGrid._loadFromDataTable(dataSet.Tables[0], dataSet.Tables[0].Select());
                    }
                    else
                    {
                        this._dataListGrid._clear();
                    }
                    dataSet.Dispose();
                    updateRecordCountLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถโหลดข้อมูลได้ \r\n" + ex.Message, "โหลดข้อมูลไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        void ChangeEditMode(bool isEdit)
        {
            this.isEditMode = isEdit;
            EnableActionButtons(this.isEditMode);
            if (this.OnChangeEditMode != null)
            {
                this.OnChangeEditMode(isEdit);
            }
            ChangeFormMode(isEdit);
        }

        protected virtual void ChangeFormMode(bool isEdit)
        {

        }

        protected virtual string LoadDataListQuery()
        {
            return "";
        }

        protected virtual bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            return true;
        }

        protected virtual bool OnSaveData()
        {
            return false;
        }

        protected virtual bool OnDeleteData(RowDataSelect rowSelected)
        {
            return false;
        }

        protected virtual void ClearScreen()
        {

        }

        void updateRecordCountLabel()
        {
            string recordCountText = string.Format("{0} ({1}/{2})", this.totalRecord, this.page, this.totalPage);
            this._recordCountLabel.Text = recordCountText;
        }

        private void _buttonSearch_Click(object sender, EventArgs e)
        {
            this.OnLoadDataList();
        }

        private void _goFirstPageButton_Click(object sender, EventArgs e)
        {
            if (this.page != 1)
            {
                this.page = 1;
                this.OnLoadDataList();
            }
        }

        private void _prevPageButton_Click(object sender, EventArgs e)
        {
            if (this.page > 1)
            {
                this.page--;
                this.OnLoadDataList();
            }
        }

        private void _nextPageButton_Click(object sender, EventArgs e)
        {
            if (this.page < this.totalPage)
            {
                this.page++;
                this.OnLoadDataList();
            }
        }

        private void _goLastPageButton_Click(object sender, EventArgs e)
        {
            if (this.page != this.totalPage && this.page <= this.totalPage)
            {
                this.page = this.totalPage;
                this.OnLoadDataList();
            }
        }



        private void _dataLoadingTimer_Tick(object sender, EventArgs e)
        {
            this._dataLoadingTimer.Stop();
            this.OnLoadDataList();
        }

        private void _addButton_Click(object sender, EventArgs e)
        {
            this.ClearScreen();
            formMode = FormMode.ADD;
            this.ChangeEditMode(true);

        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            string saveConfirmMessage = "ต้องการบันทึกข้อมูลใช่หรือไม่?";

            DialogResult saveConfirmResult = MessageBox.Show(saveConfirmMessage, "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (saveConfirmResult == DialogResult.Yes)
            {
                try
                {
                    bool canSaveData = this.OnSaveData();
                    if (canSaveData)
                    {
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AfterInsertOrUpdate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้ \r\n" + ex.Message, "บันทึกข้อมูลไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            CancelEditData();
        }

        protected void AfterInsertOrUpdate()
        {
            this.ChangeEditMode(false);
            this.ClearScreen();
            this.LoadDataList();
        }

        bool CancelEditData()
        {
            string cancelConfirmMessage = "ต้องการยกเลิกการแก้ไขข้อมูลใช่หรือไม่?";

            DialogResult cancelConfirmResult = MessageBox.Show(cancelConfirmMessage, "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelConfirmResult == DialogResult.Yes)
            {

                this.ClearScreen();
                this.ChangeEditMode(false);
                return true;
            }
            return false;
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (this._dataListGrid._selectRow < this._dataListGrid._rowData.Count)
            {
                string deleteConfirmMessage = "ต้องการลบข้อมูลใช่หรือไม่?";
                DialogResult deleteConfirmResult = MessageBox.Show(deleteConfirmMessage, "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteConfirmResult == DialogResult.Yes)
                {
                    RowDataSelect selectedRow = new RowDataSelect();
                    foreach (var col in this._dataListGrid._columnList)
                    {
                        SMLControl._columnType gridColumn = (SMLControl._columnType)col;
                        string columnCode = gridColumn._originalName; string cellValue = "";

                        if (gridColumn._type == 4)
                        {
                            object dataDate = this._dataListGrid._cellGet(this._dataListGrid._selectRow, columnCode);
                            if (dataDate != null)
                            {
                                cellValue = Convert.ToDateTime(dataDate).ToString("yyyy-MM-dd", App.SystemCulture);
                            }
                        }
                        else
                        {
                            cellValue = this._dataListGrid._cellGet(this._dataListGrid._selectRow, columnCode).ToString();
                        }

                        selectedRow[columnCode] = cellValue;

                    }

                    bool canDelete = OnDeleteData(selectedRow);
                    if (canDelete)
                    {
                        this.ClearScreen();
                        this.LoadDataList();
                    }
                }
            }
        }

        public event OnChangeEditModeDelegate OnChangeEditMode;
    }

    public delegate void OnChangeEditModeDelegate(bool isEditMode);

    public enum FormMode
    {
        VIEW,
        ADD,
        EDIT
    }

    public class RowDataSelect : Dictionary<string, string>
    {
    }
}
