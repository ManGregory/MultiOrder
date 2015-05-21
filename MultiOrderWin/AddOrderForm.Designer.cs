namespace MultiOrderWin
{
    partial class AddOrderForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpOrderInfo = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpEquipments = new System.Windows.Forms.GroupBox();
            this.gridEquipments = new System.Windows.Forms.DataGridView();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFromClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPeriods = new System.Windows.Forms.ComboBox();
            this.cmbWeeks = new System.Windows.Forms.ComboBox();
            this.cmbClassrooms = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numToPair = new System.Windows.Forms.NumericUpDown();
            this.numFromPair = new System.Windows.Forms.NumericUpDown();
            this.edDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpOrderInfo.SuspendLayout();
            this.grpEquipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromPair)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(121, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpOrderInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 335);
            this.panel2.TabIndex = 1;
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.btnRemove);
            this.grpOrderInfo.Controls.Add(this.btnEdit);
            this.grpOrderInfo.Controls.Add(this.btnAdd);
            this.grpOrderInfo.Controls.Add(this.grpEquipments);
            this.grpOrderInfo.Controls.Add(this.cmbPeriods);
            this.grpOrderInfo.Controls.Add(this.cmbWeeks);
            this.grpOrderInfo.Controls.Add(this.cmbClassrooms);
            this.grpOrderInfo.Controls.Add(this.label7);
            this.grpOrderInfo.Controls.Add(this.label6);
            this.grpOrderInfo.Controls.Add(this.numToPair);
            this.grpOrderInfo.Controls.Add(this.numFromPair);
            this.grpOrderInfo.Controls.Add(this.edDate);
            this.grpOrderInfo.Controls.Add(this.label4);
            this.grpOrderInfo.Controls.Add(this.label3);
            this.grpOrderInfo.Controls.Add(this.label2);
            this.grpOrderInfo.Controls.Add(this.label1);
            this.grpOrderInfo.Location = new System.Drawing.Point(13, 3);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(314, 326);
            this.grpOrderInfo.TabIndex = 0;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Информация о заявке";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(223, 295);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(108, 295);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 23);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 295);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpEquipments
            // 
            this.grpEquipments.Controls.Add(this.gridEquipments);
            this.grpEquipments.Location = new System.Drawing.Point(10, 167);
            this.grpEquipments.Name = "grpEquipments";
            this.grpEquipments.Size = new System.Drawing.Size(291, 122);
            this.grpEquipments.TabIndex = 14;
            this.grpEquipments.TabStop = false;
            this.grpEquipments.Text = "Требуемое оборудование";
            // 
            // gridEquipments
            // 
            this.gridEquipments.AllowUserToAddRows = false;
            this.gridEquipments.AllowUserToDeleteRows = false;
            this.gridEquipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEquipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EquipmentName,
            this.Amount,
            this.OrderId,
            this.EquipmentId,
            this.IsFromClassroom});
            this.gridEquipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEquipments.Location = new System.Drawing.Point(3, 18);
            this.gridEquipments.Name = "gridEquipments";
            this.gridEquipments.ReadOnly = true;
            this.gridEquipments.Size = new System.Drawing.Size(285, 101);
            this.gridEquipments.TabIndex = 0;
            this.gridEquipments.SelectionChanged += new System.EventHandler(this.gridEquipments_SelectionChanged);
            // 
            // EquipmentName
            // 
            this.EquipmentName.HeaderText = "Оборудование";
            this.EquipmentName.Name = "EquipmentName";
            this.EquipmentName.ReadOnly = true;
            this.EquipmentName.Width = 140;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "Column1";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            this.OrderId.Visible = false;
            // 
            // EquipmentId
            // 
            this.EquipmentId.HeaderText = "Column1";
            this.EquipmentId.Name = "EquipmentId";
            this.EquipmentId.ReadOnly = true;
            this.EquipmentId.Visible = false;
            // 
            // IsFromClassroom
            // 
            this.IsFromClassroom.HeaderText = "Column1";
            this.IsFromClassroom.Name = "IsFromClassroom";
            this.IsFromClassroom.ReadOnly = true;
            this.IsFromClassroom.Visible = false;
            // 
            // cmbPeriods
            // 
            this.cmbPeriods.FormattingEnabled = true;
            this.cmbPeriods.Location = new System.Drawing.Point(113, 139);
            this.cmbPeriods.Name = "cmbPeriods";
            this.cmbPeriods.Size = new System.Drawing.Size(188, 22);
            this.cmbPeriods.TabIndex = 13;
            this.cmbPeriods.SelectedIndexChanged += new System.EventHandler(this.cmbPeriods_SelectedIndexChanged);
            // 
            // cmbWeeks
            // 
            this.cmbWeeks.FormattingEnabled = true;
            this.cmbWeeks.Location = new System.Drawing.Point(113, 109);
            this.cmbWeeks.Name = "cmbWeeks";
            this.cmbWeeks.Size = new System.Drawing.Size(188, 22);
            this.cmbWeeks.TabIndex = 12;
            // 
            // cmbClassrooms
            // 
            this.cmbClassrooms.FormattingEnabled = true;
            this.cmbClassrooms.Location = new System.Drawing.Point(91, 78);
            this.cmbClassrooms.Name = "cmbClassrooms";
            this.cmbClassrooms.Size = new System.Drawing.Size(210, 22);
            this.cmbClassrooms.TabIndex = 10;
            this.cmbClassrooms.SelectedIndexChanged += new System.EventHandler(this.cmbClassrooms_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Период";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Учебная неделя";
            // 
            // numToPair
            // 
            this.numToPair.Location = new System.Drawing.Point(251, 45);
            this.numToPair.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numToPair.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numToPair.Name = "numToPair";
            this.numToPair.Size = new System.Drawing.Size(50, 22);
            this.numToPair.TabIndex = 7;
            this.numToPair.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numFromPair
            // 
            this.numFromPair.Location = new System.Drawing.Point(91, 45);
            this.numFromPair.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFromPair.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFromPair.Name = "numFromPair";
            this.numFromPair.Size = new System.Drawing.Size(51, 22);
            this.numFromPair.TabIndex = 6;
            this.numFromPair.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // edDate
            // 
            this.edDate.Location = new System.Drawing.Point(91, 16);
            this.edDate.Name = "edDate";
            this.edDate.Size = new System.Drawing.Size(154, 22);
            this.edDate.TabIndex = 5;
            this.edDate.ValueChanged += new System.EventHandler(this.edDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Аудитория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "По какую пару";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "С какой пары";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата подачи";
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 391);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AddOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOrderForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            this.grpEquipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEquipments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToPair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromPair)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numToPair;
        private System.Windows.Forms.NumericUpDown numFromPair;
        private System.Windows.Forms.DateTimePicker edDate;
        private System.Windows.Forms.ComboBox cmbPeriods;
        private System.Windows.Forms.ComboBox cmbWeeks;
        private System.Windows.Forms.ComboBox cmbClassrooms;
        private System.Windows.Forms.GroupBox grpEquipments;
        private System.Windows.Forms.DataGridView gridEquipments;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFromClassroom;
    }
}