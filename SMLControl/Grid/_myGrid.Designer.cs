using System.Threading;

namespace SMLControl
{
    partial class _myGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._deleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this._insertRow = new System.Windows.Forms.ToolStripMenuItem();
            this._copyAll = new System.Windows.Forms.ToolStripMenuItem();
            this._copyAllIncludeHeader = new System.Windows.Forms.ToolStripMenuItem();
            this._removeAll = new System.Windows.Forms.ToolStripMenuItem();
            this._vScrollBar1 = new SMLControl._myVScrollBar();
            this._hScrollBar1 = new SMLControl._myHScrollBar();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteRow,
            this._insertRow,
            this.toolStripSeparator1,
            this._copyAll,
            this._copyAllIncludeHeader,
            this.toolStripSeparator2,
            this._removeAll});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(211, 126);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // _deleteRow
            // 
            this._deleteRow.Image = global::SMLControl.Properties.Resources.delete;
            this._deleteRow.Name = "_deleteRow";
            this._deleteRow.Size = new System.Drawing.Size(210, 22);
            this._deleteRow.Text = "Delete Row";
            // 
            // _insertRow
            // 
            this._insertRow.Image = global::SMLControl.Properties.Resources.add;
            this._insertRow.Name = "_insertRow";
            this._insertRow.Size = new System.Drawing.Size(210, 22);
            this._insertRow.Text = "Insert Row";
            // 
            // _copyAll
            // 
            this._copyAll.Image = global::SMLControl.Properties.Resources.copy;
            this._copyAll.Name = "_copyAll";
            this._copyAll.Size = new System.Drawing.Size(210, 22);
            this._copyAll.Text = "Copy All";
            // 
            // _copyAllIncludeHeader
            // 
            this._copyAllIncludeHeader.Image = global::SMLControl.Properties.Resources.copy;
            this._copyAllIncludeHeader.Name = "_copyAllIncludeHeader";
            this._copyAllIncludeHeader.Size = new System.Drawing.Size(210, 22);
            this._copyAllIncludeHeader.Text = "Copy All (Include Header)";
            // 
            // _removeAll
            // 
            this._removeAll.Image = global::SMLControl.Properties.Resources.garbage_empty;
            this._removeAll.Name = "_removeAll";
            this._removeAll.Size = new System.Drawing.Size(210, 22);
            this._removeAll.Text = "Remove All";
            // 
            // _vScrollBar1
            // 
            this._vScrollBar1.Location = new System.Drawing.Point(244, 0);
            this._vScrollBar1.Name = "_vScrollBar1";
            this._vScrollBar1.Size = new System.Drawing.Size(17, 142);
            this._vScrollBar1.TabIndex = 1;
            // 
            // _hScrollBar1
            // 
            this._hScrollBar1.Location = new System.Drawing.Point(0, 142);
            this._hScrollBar1.Name = "_hScrollBar1";
            this._hScrollBar1.Size = new System.Drawing.Size(261, 17);
            this._hScrollBar1.TabIndex = 0;
            // 
            // _myGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._vScrollBar1);
            this.Controls.Add(this._hScrollBar1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "_myGrid";
            this.Size = new System.Drawing.Size(261, 159);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private _myHScrollBar _hScrollBar1;
        private _myVScrollBar _vScrollBar1;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _deleteRow;
        private System.Windows.Forms.ToolStripMenuItem _insertRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _copyAll;
        private System.Windows.Forms.ToolStripMenuItem _copyAllIncludeHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _removeAll;
    }
}
