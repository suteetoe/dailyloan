using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InactiveStockCleaner
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public string UnitCost { get; set; }
        public string HasMovement { get; set; }
    }

    public partial class ProcessControl : UserControl
    {
        private ProductGrid productGrid;

        public ProcessControl()
        {
            InitializeComponent();
        }

        private void ProcessControl_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            
            // ตรวจสอบให้แน่ใจว่าปุ่มลบ visible
            if (deleteButton != null)
            {
                deleteButton.Visible = true;
                deleteButton.BringToFront();
            }
        }

        private void InitializeGrid()
        {
            // สร้าง ProductGrid
            productGrid = new ProductGrid();
            productGrid.Dock = DockStyle.Fill;
            
            // เพิ่ม grid ไปใน gridPanel โดยไม่ต้องใส่ padding เพราะ gridPanel มี padding อยู่แล้ว
            gridPanel.Controls.Add(productGrid);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "เลือกไฟล์ Text สำหรับ Upload";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadTextFile(openFileDialog.FileName);
                    statusLabel.Text = $"อ่านไฟล์สำเร็จ: {Path.GetFileName(openFileDialog.FileName)}";
                    statusLabel.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    statusLabel.Text = $"เกิดข้อผิดพลาดในการอ่านไฟล์: {ex.Message}";
                    statusLabel.ForeColor = Color.Red;
                }
            }
        }

        private void LoadTextFile(string filePath)
        {
            // เคลียร์ข้อมูลเดิมใน grid
            productGrid._clear();

            // อ่านไฟล์ทีละบรรทัด
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            
            statusLabel.Text = $"กำลังโหลดข้อมูล {lines.Length} รายการ...";
            statusLabel.ForeColor = Color.Blue;
            Application.DoEvents();

            // เก็บรหัสสินค้าทั้งหมดไว้เพื่อดึงข้อมูลจาก database ครั้งเดียว
            List<string> productCodes = new List<string>();
            List<string[]> allLines = new List<string[]>();

            // ตัดบรรทัดแรกออก (เป็นชื่อคอลัมน์) และเตรียมข้อมูล
            for (int i = 1; i < lines.Length; i++) // เริ่มจาก index 1 เพื่อข้ามบรรทัดแรก
            {
                string line = lines[i];
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // แยกข้อมูลด้วย tab หรือ comma
                    string[] columns = line.Split(new char[] { '\t', ',' }, StringSplitOptions.None);
                    
                    if (columns.Length > 0)
                    {
                        string productCode = columns[0].Trim();
                        if (!string.IsNullOrEmpty(productCode))
                        {
                            productCodes.Add(productCode);
                            allLines.Add(columns);
                        }
                    }
                }
            }

            // ดึงข้อมูลสินค้าจาก database ครั้งเดียว
            Dictionary<string, ProductInfo> productInfo = GetProductInfo(productCodes);

            statusLabel.Text = $"กำลังโหลดข้อมูลลงใน grid...";
            Application.DoEvents();

            // เพิ่มข้อมูลลงใน grid
            foreach (string[] columns in allLines)
            {
                string productCode = columns[0].Trim();
                
                // เพิ่มแถวใหม่ใน grid
                int newRow = productGrid._addRow();
                
                // ใส่รหัสสินค้า
                productGrid._cellUpdate(newRow, "product_code", productCode, false);
                
                // ใส่ข้อมูลจาก database
                if (productInfo.ContainsKey(productCode))
                {
                    var info = productInfo[productCode];
                    productGrid._cellUpdate(newRow, "product_name", info.Name, false);
                    productGrid._cellUpdate(newRow, "unit_cost", info.UnitCost, false);
                    productGrid._cellUpdate(newRow, "has_movement", info.HasMovement, false);
                }
                else
                {
                    productGrid._cellUpdate(newRow, "product_name", "", false);
                    productGrid._cellUpdate(newRow, "unit_cost", "", false);
                    productGrid._cellUpdate(newRow, "has_movement", "", false);
                }
            }

            // รีเฟรช grid
            productGrid.Invalidate();
            
            statusLabel.Text = $"โหลดข้อมูลเสร็จสิ้น: {productGrid._rowData.Count} รายการ";
            statusLabel.ForeColor = Color.Green;
        }

        private Dictionary<string, ProductInfo> GetProductInfo(List<string> productCodes)
        {
            Dictionary<string, ProductInfo> result = new Dictionary<string, ProductInfo>();
            
            if (productCodes.Count == 0)
                return result;

            try
            {
                // ใช้ DBConnection ที่ login เข้ามาแล้ว
                if (InactiveStockCleaner.App.DBConnection != null)
                {
                    // สร้าง WHERE IN clause
                    string inClause = string.Join(",", productCodes.Select(code => $"'{code.Replace("'", "''")}'"));
                    string query = $@"
                        SELECT 
                            i.code, 
                            i.name_1,
                            i.unit_cost,
                            CASE 
                                WHEN (SELECT COUNT(*) FROM ic_trans_detail t WHERE t.item_code = i.code) > 0 
                                THEN 'มีเคลื่อนไหว' 
                                ELSE 'ไม่เคลื่อนไหว' 
                            END as has_movement
                        FROM ic_inventory i 
                        WHERE i.code IN ({inClause})";
                    
                    var dataSet = InactiveStockCleaner.App.DBConnection.QueryData(query);
                    
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow row in dataSet.Tables[0].Rows)
                        {
                            string code = row["code"]?.ToString() ?? "";
                            string name = row["name_1"]?.ToString() ?? "";
                            string unitCost = row["unit_cost"]?.ToString() ?? "";
                            string hasMovement = row["has_movement"]?.ToString() ?? "";
                            
                            if (!string.IsNullOrEmpty(code))
                            {
                                result[code] = new ProductInfo
                                {
                                    Name = name,
                                    UnitCost = unitCost,
                                    HasMovement = hasMovement
                                };
                            }
                        }
                    }
                }
                else
                {
                    statusLabel.Text = "ไม่มีการเชื่อมต่อ database กรุณาทดสอบการเชื่อมต่อก่อน";
                    statusLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"เกิดข้อผิดพลาดในการดึงข้อมูลจาก database: {ex.Message}";
                statusLabel.ForeColor = Color.Red;
            }

            return result;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน grid หรือไม่
            if (productGrid == null || productGrid._rowData.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลให้ลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // แสดง dialog ให้ใส่รหัสผ่าน
            string password = PromptForPassword();
            
            if (password == "123")
            {
                // รหัสผ่านถูกต้อง - ลบข้อมูล
                DialogResult result = MessageBox.Show(
                    $"ต้องการลบข้อมูลทั้งหมด {productGrid._rowData.Count} รายการใช่หรือไม่?",
                    "ยืนยันการลบข้อมูล",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    productGrid._clear();
                    statusLabel.Text = "ลบข้อมูลทั้งหมดเรียบร้อยแล้ว";
                    statusLabel.ForeColor = Color.Green;
                }
            }
            else if (!string.IsNullOrEmpty(password))
            {
                // รหัสผ่านผิด
                MessageBox.Show("รหัสผ่านไม่ถูกต้อง ไม่สามารถลบข้อมูลได้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // ถ้า password เป็น null หรือ empty แปลว่า user กด Cancel
        }

        private string PromptForPassword()
        {
            using (Form passwordForm = new Form())
            {
                passwordForm.Text = "ยืนยันการลบข้อมูล";
                passwordForm.Size = new Size(350, 200);
                passwordForm.StartPosition = FormStartPosition.CenterParent;
                passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordForm.MaximizeBox = false;
                passwordForm.MinimizeBox = false;

                Label messageLabel = new Label()
                {
                    Text = "กรุณาใส่รหัสผ่านเพื่อยืนยันการลบข้อมูล:",
                    Location = new Point(20, 20),
                    Size = new Size(300, 40),
                    Font = new Font("Microsoft Sans Serif", 10F)
                };

                TextBox passwordTextBox = new TextBox()
                {
                    Location = new Point(20, 70),
                    Size = new Size(200, 25),
                    UseSystemPasswordChar = true,
                    Font = new Font("Microsoft Sans Serif", 12F)
                };

                Button okButton = new Button()
                {
                    Text = "ตกลง",
                    Location = new Point(230, 68),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.OK
                };

                Button cancelButton = new Button()
                {
                    Text = "ยกเลิก",
                    Location = new Point(230, 105),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.Cancel
                };

                passwordForm.Controls.AddRange(new Control[] { messageLabel, passwordTextBox, okButton, cancelButton });
                passwordForm.AcceptButton = okButton;
                passwordForm.CancelButton = cancelButton;

                // Focus ที่ textbox เมื่อเปิด form
                passwordForm.Shown += (s, e) => passwordTextBox.Focus();

                return passwordForm.ShowDialog() == DialogResult.OK ? passwordTextBox.Text : null;
            }
        }
    }
}