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
            
            // เพิ่ม 4 คอลั่ม: รหัสสินค้า, ชื่อสินค้า, หน่วยนับ, มีเคลื่อนไหว
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "product_code", ColumnName = "รหัสสินค้า", WidthPercent = 25 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "product_name", ColumnName = "ชื่อสินค้า", WidthPercent = 45 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "unit_cost", ColumnName = "หน่วยนับ", WidthPercent = 15 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "has_movement", ColumnName = "มีเคลื่อนไหว", WidthPercent = 15 });
            
            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }
}