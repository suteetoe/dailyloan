using DailyLoan.Control;
using DailyLoan.Data.Repository;
using SMLControl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Users
{
    public class UsersControl : DailyLoan.Control.ManageDataList
    {
        private UserDetailScreen userDetailScreen1;
        UserRepository userRepository = new UserRepository();

        private int userId = -1;

        public UsersControl()
        {
            InitializeComponent();

            // hide
            this._dataListGrid.AddGridColumn(new SMLControl.GridIntegerColumn() { WidthPercent = 20, ColumnCode = "id", ColumnName = "Id", IsHide = false });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "user_code", ColumnName = "Username" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 60, ColumnCode = "name_1", ColumnName = "ชื่อ" });


            this._dataListGrid.Invalidate();

        }

        protected override void ClearScreen()
        {
            userId = -1;
            this.userDetailScreen1._clear();
            this.userDetailScreen1._enabedControl("user_code", true);

        }

        protected override string LoadDataListQuery()
        {
            string filter = this.GetFilterCommand();

            string query = "SELECT id, user_code, name_1, user_password from " + Data.Models.User.TABLE_NAME + " " + (filter.Length > 0 ? " WHERE " + filter: "") ;
            return query;
        }

        protected override string SortField()
        {
            return " order by user_code";
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            string userId = selectedRow["id"].ToString();
            int uid = _numberUtils._intPhase(userId);

            Data.Models.User user = this.userRepository.FindById(uid);

            if (user != null)
            {
                this.userId = uid;
                this.userDetailScreen1.LoadUserData(user);

                return true;
            }

            return false;
        }

        protected override bool OnSaveData()
        {
            string requiredField = this.userDetailScreen1._checkEmtryField();

            if (requiredField != "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูล " + requiredField);
                return false;
            }

            Data.Models.User user = this.userDetailScreen1.getUser();
            if (this.formMode == FormMode.EDIT)
            {
                user.Id = this.userId;
                this.userRepository.UpdateUser(user);
            }
            else
            {
                this.userRepository.CreateUser(user);
            }

            return true;

        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string userId = rowSelected["id"].ToString();
                int uid = _numberUtils._intPhase(userId);
                Data.Models.User findUser = this.userRepository.FindById(uid);

                if (findUser == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการลบ", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                userRepository.DeleteUser(findUser);

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
            this.userDetailScreen1 = new DailyLoan.Screen.Users.UserDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userDetailScreen1);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // userDetailScreen1
            // 
            this.userDetailScreen1._isChange = false;
            this.userDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this.userDetailScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDetailScreen1.Location = new System.Drawing.Point(0, 0);
            this.userDetailScreen1.Name = "userDetailScreen1";
            this.userDetailScreen1.ReadOnly = false;
            this.userDetailScreen1.Size = new System.Drawing.Size(359, 529);
            this.userDetailScreen1.TabIndex = 8;
            this.titlePanel.Title = "ผู้ใช้งานระบบ";
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "UsersControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
