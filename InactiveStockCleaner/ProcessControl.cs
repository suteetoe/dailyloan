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
        public string BalanceAmount { get; set; }
        
        public string GetStatus()
        {
            // แปลง HasMovement เป็น boolean
            bool hasMovement = HasMovement == "มีเคลื่อนไหว";
            
            // แปลง BalanceAmount เป็น decimal
            decimal balance = SMLControl.Utils._numberUtils._decimalPhase(BalanceAmount);
            
            // Debug: ดูค่าที่ได้
            // MessageBox.Show($"HasMovement: '{HasMovement}', hasMovement: {hasMovement}, Balance: {balance}");
            
            // ตรวจสอบเงื่อนไข
            if (!hasMovement) // ไม่เคลื่อนไหว
            {
                return "ลบ";
            }
            else if (hasMovement && balance != 0) // มีเคลื่อนไหว และ สต็อกไม่เป็น 0
            {
                return "หยุดซื้อ";
            }
            else // มีเคลื่อนไหว และ สต็อก = 0
            {
                return "หยุดซื้อ, หยุดขาย";
            }
        }
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
                    productGrid._cellUpdate(newRow, "balance_amount", SMLControl.Utils._numberUtils._decimalPhase(info.BalanceAmount), false);
                    productGrid._cellUpdate(newRow, "status", info.GetStatus(), false);
                }
                else
                {
                    productGrid._cellUpdate(newRow, "product_name", "", false);
                    productGrid._cellUpdate(newRow, "unit_cost", "", false);
                    productGrid._cellUpdate(newRow, "has_movement", "", false);
                    productGrid._cellUpdate(newRow, "balance_amount", SMLControl.Utils._numberUtils._decimalPhase("0"), false);
                    productGrid._cellUpdate(newRow, "status", "", false);
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
                            END as has_movement,
                            COALESCE(
                                (SELECT SUM(
                                    (
                                        calc_flag * (
                                            CASE
                                                WHEN (
                                                    (
                                                        trans_flag IN (70, 54, 60, 58, 310, 12)
                                                        OR (
                                                            trans_flag = 66
                                                            AND (
                                                                qty > 0
                                                                OR sum_of_cost > 0
                                                            )
                                                        )
                                                        OR (trans_flag = 14)
                                                        OR (
                                                            trans_flag = 48
                                                            AND inquiry_type < 2
                                                        )
                                                    )
                                                    OR (
                                                        trans_flag IN (56, 68, 72, 44)
                                                        OR (
                                                            trans_flag = 66
                                                            AND (
                                                                qty < 0
                                                                OR sum_of_cost < 0
                                                            )
                                                        )
                                                        OR (trans_flag = 46)
                                                        OR (trans_flag = 16)
                                                        OR (trans_flag = 311)
                                                    )
                                                    AND NOT (
                                                        ic_trans_detail.doc_ref <> ''
                                                        AND ic_trans_detail.is_pos = 1
                                                    )
                                                ) THEN(
                                                    CASE
                                                        WHEN trans_flag = 66
                                                        AND qty < 0 THEN(-1 * sum_of_cost) + COALESCE(profit_lost_cost_amount, 0)
                                                        ELSE (sum_of_cost + COALESCE(profit_lost_cost_amount, 0))
                                                    END
                                                )
                                                ELSE 0
                                            END
                                        )
                                    )
                                ) FROM ic_trans_detail WHERE item_code = i.code),
                                0
                            ) AS balance_amount
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
                            string balanceAmount = row["balance_amount"]?.ToString() ?? "0";
                            
                            if (!string.IsNullOrEmpty(code))
                            {
                                result[code] = new ProductInfo
                                {
                                    Name = name,
                                    UnitCost = unitCost,
                                    HasMovement = hasMovement,
                                    BalanceAmount = balanceAmount
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
                MessageBox.Show("ไม่มีข้อมูลให้ดำเนินการ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // แสดง dialog ให้ใส่รหัสผ่าน
            string password = PromptForPassword();
            
            if (password == "123")
            {
                // รหัสผ่านถูกต้อง - ดำเนินการ Process
                DialogResult result = MessageBox.Show(
                    $"ต้องการดำเนินการ Process ข้อมูลทั้งหมด {productGrid._rowData.Count} รายการใช่หรือไม่?\n\n" +
                    "การดำเนินการจะแก้ไขข้อมูลในฐานข้อมูลตามสถานะของแต่ละรายการ",
                    "ยืนยันการ Process ข้อมูล",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    ProcessData();
                }
            }
            else if (!string.IsNullOrEmpty(password))
            {
                // รหัสผ่านผิด
                MessageBox.Show("รหัสผ่านไม่ถูกต้อง ไม่สามารถดำเนินการได้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // ถ้า password เป็น null หรือ empty แปลว่า user กด Cancel
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน grid หรือไม่
            if (productGrid == null || productGrid._rowData.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลให้ Export", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // สร้าง SaveFileDialog
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|Text files (*.txt)|*.txt";
                    saveDialog.FilterIndex = 1; // Default เป็น CSV
                    saveDialog.DefaultExt = "csv";
                    saveDialog.FileName = $"InactiveStock_Export_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportGridData(saveDialog.FileName);
                        
                        statusLabel.Text = $"Export สำเร็จ: {productGrid._rowData.Count} รายการ → {Path.GetFileName(saveDialog.FileName)}";
                        statusLabel.ForeColor = Color.Green;
                        
                        MessageBox.Show($"Export ข้อมูลสำเร็จ!\n\nไฟล์: {saveDialog.FileName}\nจำนวน: {productGrid._rowData.Count} รายการ", 
                            "Export สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Export ล้มเหลว: " + ex.Message;
                statusLabel.ForeColor = Color.Red;
                MessageBox.Show("เกิดข้อผิดพลาดในการ Export ข้อมูล:\n" + ex.Message, 
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportGridData(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            
            switch (extension)
            {
                case ".csv":
                case ".txt":
                    ExportToCsv(fileName);
                    break;
                case ".xlsx":
                    ExportToExcel(fileName);
                    break;
                default:
                    ExportToCsv(fileName); // Default เป็น CSV
                    break;
            }
        }

        private void ExportToCsv(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                // เขียน Header
                writer.WriteLine("รหัสสินค้า,ชื่อสินค้า,หน่วยนับ,มีเคลื่อนไหว,สต็อกคงเหลือ,สถานะ");
                
                // เขียนข้อมูลแต่ละแถว
                for (int row = 0; row < productGrid._rowData.Count; row++)
                {
                    List<string> values = new List<string>();
                    
                    for (int col = 0; col < 6; col++) // 6 คอลัมน์
                    {
                        object cellValue = productGrid._cellGet(row, col);
                        string value = cellValue?.ToString() ?? "";
                        
                        // Escape comma และ quotes สำหรับ CSV
                        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                        {
                            value = "\"" + value.Replace("\"", "\"\"") + "\"";
                        }
                        
                        values.Add(value);
                    }
                    
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }

        private void ExportToExcel(string fileName)
        {
            // สำหรับ Excel export แบบง่าย (ไม่ใช้ library พิเศษ)
            // จะใช้ CSV format แต่บันทึกเป็น .xlsx
            // ในการใช้งานจริงควรใช้ library เช่น EPPlus หรือ ClosedXML
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                // BOM สำหรับ UTF-8
                writer.Write('\uFEFF');
                
                // เขียน Header
                writer.WriteLine("รหัสสินค้า\tชื่อสินค้า\tหน่วยนับ\tมีเคลื่อนไหว\tสต็อกคงเหลือ\tสถานะ");
                
                // เขียนข้อมูลแต่ละแถว (ใช้ Tab เป็น delimiter)
                for (int row = 0; row < productGrid._rowData.Count; row++)
                {
                    List<string> values = new List<string>();
                    
                    for (int col = 0; col < 6; col++)
                    {
                        object cellValue = productGrid._cellGet(row, col);
                        string value = cellValue?.ToString() ?? "";
                        values.Add(value);
                    }
                    
                    writer.WriteLine(string.Join("\t", values));
                }
            }
        }

        private void ProcessData()
        {
            try
            {
                int deleteCount = 0;
                int holdPurchaseCount = 0;
                int holdSaleCount = 0;
                int errorCount = 0;

                statusLabel.Text = "กำลังดำเนินการ...";
                statusLabel.ForeColor = Color.Blue;

                // ดึงข้อมูลทั้งหมดจาก grid
                for (int row = 0; row < productGrid._rowData.Count; row++)
                {
                    try
                    {
                        // ใช้ column index แทน column name เพื่อหลีกเลี่ยง StackOverflow
                        // Column 0: product_code, Column 5: status
                        string productCode = productGrid._cellGet(row, 0).ToString();
                        string status = productGrid._cellGet(row, 5).ToString();

                        if (string.IsNullOrEmpty(productCode) || string.IsNullOrEmpty(status))
                            continue;

                        // ดำเนินการตามสถานะ
                        switch (status)
                        {
                            case "ลบ":
                                if (DeleteProduct(productCode))
                                    deleteCount++;
                                else
                                    errorCount++;
                                break;

                            case "หยุดซื้อ":
                                if (UpdateHoldPurchase(productCode))
                                    holdPurchaseCount++;
                                else
                                    errorCount++;
                                break;

                            case "หยุดซื้อ, หยุดขาย":
                                if (UpdateHoldSale(productCode))
                                    holdSaleCount++;
                                else
                                    errorCount++;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        System.Diagnostics.Debug.WriteLine($"Error processing row {row}: {ex.Message}");
                    }
                }

                // แสดงผลลัพธ์
                string resultMessage = $"ดำเนินการเสร็จสิ้น:\n" +
                                     $"ลบสินค้า: {deleteCount} รายการ\n" +
                                     $"หยุดซื้อ: {holdPurchaseCount} รายการ\n" +
                                     $"หยุดซื้อ+ขาย: {holdSaleCount} รายการ";

                if (errorCount > 0)
                    resultMessage += $"\nข้อผิดพลาด: {errorCount} รายการ";

                statusLabel.Text = resultMessage.Replace("\n", " | ");
                statusLabel.ForeColor = errorCount > 0 ? Color.Orange : Color.Green;

                MessageBox.Show(resultMessage, "ผลการดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                statusLabel.Text = "เกิดข้อผิดพลาด: " + ex.Message;
                statusLabel.ForeColor = Color.Red;
                MessageBox.Show("เกิดข้อผิดพลาดในการดำเนินการ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DeleteProduct(string productCode)
        {
            try
            {
                // ใช้ connection ที่ login เข้ามาแล้ว
                if (InactiveStockCleaner.App.DBConnection == null || !InactiveStockCleaner.App.DBConnection.Connected)
                {
                    throw new Exception("Database not connected");
                }

                // Escape single quotes in product code
                string escapedProductCode = productCode.Replace("'", "''");
                
                string query = $@"
                    DELETE FROM ic_inventory_detail WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_inventory_barcode WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_inventory_level WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_inventory_price WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_inventory_price_formula WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_unit_use WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_wh_shelf WHERE ic_code = '{escapedProductCode}';
                    DELETE FROM ic_inventory WHERE code = '{escapedProductCode}';
                    DELETE FROM ic_inventory_purchase_price WHERE code = '{escapedProductCode}'; ";


                InactiveStockCleaner.App.DBConnection.ExecuteCommand(query);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting product {productCode}: {ex.Message}");
                return false;
            }
        }

        private bool UpdateHoldPurchase(string productCode)
        {
            try
            {
                // ใช้ connection ที่ login เข้ามาแล้ว
                if (InactiveStockCleaner.App.DBConnection == null || !InactiveStockCleaner.App.DBConnection.Connected)
                {
                    throw new Exception("Database not connected");
                }

                // Escape single quotes in product code
                string escapedProductCode = productCode.Replace("'", "''");
                
                string query = $@"
                    UPDATE ic_inventory_detail 
                    SET is_hold_purchase = 1 
                    WHERE ic_code = '{escapedProductCode}'";
                
                InactiveStockCleaner.App.DBConnection.ExecuteCommand(query);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating hold purchase for {productCode}: {ex.Message}");
                return false;
            }
        }

        private bool UpdateHoldSale(string productCode)
        {
            try
            {
                // ใช้ connection ที่ login เข้ามาแล้ว
                if (InactiveStockCleaner.App.DBConnection == null || !InactiveStockCleaner.App.DBConnection.Connected)
                {
                    throw new Exception("Database not connected");
                }

                // Escape single quotes in product code
                string escapedProductCode = productCode.Replace("'", "''");
                
                string query = $@"
                    UPDATE ic_inventory_detail 
                    SET is_hold_sale = 1 ,is_hold_purchase = 1 
                    WHERE ic_code = '{escapedProductCode}'";
                
                InactiveStockCleaner.App.DBConnection.ExecuteCommand(query);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating hold sale for {productCode}: {ex.Message}");
                return false;
            }
        }

        private string PromptForPassword()
        {
            using (Form passwordForm = new Form())
            {
                passwordForm.Text = "ยืนยันการดำเนินการ";
                passwordForm.Size = new Size(350, 200);
                passwordForm.StartPosition = FormStartPosition.CenterParent;
                passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordForm.MaximizeBox = false;
                passwordForm.MinimizeBox = false;

                Label messageLabel = new Label()
                {
                    Text = "กรุณาใส่รหัสผ่านเพื่อยืนยันการดำเนินการ:",
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