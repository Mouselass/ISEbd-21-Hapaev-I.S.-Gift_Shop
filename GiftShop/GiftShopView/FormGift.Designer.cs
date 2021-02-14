
namespace GiftShopView
{
    partial class FormGift
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
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.groupBoxComponents = new System.Windows.Forms.GroupBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.DataGridViewTextBoxKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridBoxTextBoxColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBoxComponents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(13, 13);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(60, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Название:";
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(13, 54);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(36, 13);
			this.labelPrice.TabIndex = 1;
			this.labelPrice.Text = "Цена:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(81, 13);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(173, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(81, 51);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrice.TabIndex = 3;
			// 
			// groupBoxComponents
			// 
			this.groupBoxComponents.Controls.Add(this.dataGridView);
			this.groupBoxComponents.Controls.Add(this.buttonRef);
			this.groupBoxComponents.Controls.Add(this.buttonDel);
			this.groupBoxComponents.Controls.Add(this.buttonUpd);
			this.groupBoxComponents.Controls.Add(this.buttonAdd);
			this.groupBoxComponents.Location = new System.Drawing.Point(16, 107);
			this.groupBoxComponents.Name = "groupBoxComponents";
			this.groupBoxComponents.Size = new System.Drawing.Size(476, 261);
			this.groupBoxComponents.TabIndex = 4;
			this.groupBoxComponents.TabStop = false;
			this.groupBoxComponents.Text = "Компоненты";
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxKey,
            this.DataGridBoxTextBoxColumnComponent,
            this.DataGridViewTextBoxColumnCount});
			this.dataGridView.Location = new System.Drawing.Point(7, 22);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(373, 233);
			this.dataGridView.TabIndex = 4;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(386, 163);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(75, 23);
			this.buttonRef.TabIndex = 3;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(386, 118);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 2;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(386, 74);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(75, 23);
			this.buttonUpd.TabIndex = 1;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(386, 31);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(310, 384);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(402, 384);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// DataGridViewTextBoxKey
			// 
			this.DataGridViewTextBoxKey.HeaderText = "";
			this.DataGridViewTextBoxKey.Name = "DataGridViewTextBoxKey";
			this.DataGridViewTextBoxKey.Visible = false;
			// 
			// DataGridBoxTextBoxColumnComponent
			// 
			this.DataGridBoxTextBoxColumnComponent.HeaderText = "Компонент";
			this.DataGridBoxTextBoxColumnComponent.Name = "DataGridBoxTextBoxColumnComponent";
			this.DataGridBoxTextBoxColumnComponent.Width = 222;
			// 
			// DataGridViewTextBoxColumnCount
			// 
			this.DataGridViewTextBoxColumnCount.HeaderText = "Количество";
			this.DataGridViewTextBoxColumnCount.Name = "DataGridViewTextBoxColumnCount";
			this.DataGridViewTextBoxColumnCount.Width = 111;
			// 
			// FormGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(507, 422);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxComponents);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelName);
			this.Name = "FormGift";
			this.Text = "Изделие";
			this.Load += new System.EventHandler(this.FormGift_Load);
			this.groupBoxComponents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxKey;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGridBoxTextBoxColumnComponent;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnCount;
	}
}