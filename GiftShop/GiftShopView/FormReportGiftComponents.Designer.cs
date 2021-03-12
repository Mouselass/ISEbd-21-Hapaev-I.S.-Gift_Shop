
namespace GiftShopView
{
    partial class FormReportGiftComponents
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ComponentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentColumn,
            this.GiftColumn,
            this.CountColumn});
            this.dataGridView.Location = new System.Drawing.Point(2, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(555, 394);
            this.dataGridView.TabIndex = 0;
            // 
            // ComponentColumn
            // 
            this.ComponentColumn.HeaderText = "Компонент";
            this.ComponentColumn.Name = "ComponentColumn";
            this.ComponentColumn.Width = 200;
            // 
            // GiftColumn
            // 
            this.GiftColumn.HeaderText = "Изделие";
            this.GiftColumn.Name = "GiftColumn";
            this.GiftColumn.Width = 200;
            // 
            // CountColumn
            // 
            this.CountColumn.HeaderText = "Количество";
            this.CountColumn.Name = "CountColumn";
            this.CountColumn.Width = 110;
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(12, 12);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(159, 21);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // FormReportGiftComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportGiftComponents";
            this.Text = "Компоненты по изделиям";
            this.Load += new System.EventHandler(this.FormReportProductComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.Button buttonSaveToExcel;
    }
}