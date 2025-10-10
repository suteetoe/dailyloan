using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InactiveStockCleaner
{
    public class ProductGrid : SMLControl._myGrid
    {
        public ProductGrid()
        {
            this.ShowTotal = false;
            this._displayRowNumber = true;
            
            // เพิ่ม 6 คอลั่ม: รหัสสินค้า, ชื่อสินค้า, หน่วยนับ, มีเคลื่อนไหว, สต็อกคงเหลือ, สถานะ
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "product_code", ColumnName = "รหัสสินค้า", WidthPercent = 15, IsEdit = false });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "product_name", ColumnName = "ชื่อสินค้า", WidthPercent = 30, IsEdit = true });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "unit_cost", ColumnName = "หน่วยนับ", WidthPercent = 12, IsEdit = true });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "has_movement", ColumnName = "มีเคลื่อนไหว", WidthPercent = 12, IsEdit = true });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "balance_amount", ColumnName = "สต็อกคงเหลือ", WidthPercent = 13, Format = "{0:N2}", IsEdit = true });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "status", ColumnName = "สถานะ", WidthPercent = 18, IsEdit = false });
            
            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }
}