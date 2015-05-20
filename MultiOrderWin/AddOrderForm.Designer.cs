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
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPeriods = new System.Windows.Forms.ComboBox();
            this.cmbWeeks = new System.Windows.Forms.ComboBox();
            this.cmbEquipments = new System.Windows.Forms.ComboBox();
            this.cmbClassrooms = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numToPair = new System.Windows.Forms.NumericUpDown();
            this.numFromPair = new System.Windows.Forms.NumericUpDown();
            this.edDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromPair)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(407, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(294, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 40);
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
            this.panel2.Size = new System.Drawing.Size(518, 207);
            this.panel2.TabIndex = 1;
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.numAmount);
            this.grpOrderInfo.Controls.Add(this.label8);
            this.grpOrderInfo.Controls.Add(this.cmbPeriods);
            this.grpOrderInfo.Controls.Add(this.cmbWeeks);
            this.grpOrderInfo.Controls.Add(this.cmbEquipments);
            this.grpOrderInfo.Controls.Add(this.cmbClassrooms);
            this.grpOrderInfo.Controls.Add(this.label7);
            this.grpOrderInfo.Controls.Add(this.label6);
            this.grpOrderInfo.Controls.Add(this.numToPair);
            this.grpOrderInfo.Controls.Add(this.numFromPair);
            this.grpOrderInfo.Controls.Add(this.edDate);
            this.grpOrderInfo.Controls.Add(this.label5);
            this.grpOrderInfo.Controls.Add(this.label4);
            this.grpOrderInfo.Controls.Add(this.label3);
            this.grpOrderInfo.Controls.Add(this.label2);
            this.grpOrderInfo.Controls.Add(this.label1);
            this.grpOrderInfo.Location = new System.Drawing.Point(13, 3);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(491, 198);
            this.grpOrderInfo.TabIndex = 0;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Информация о заявке";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(346, 78);
            this.numAmount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(139, 22);
            this.numAmount.TabIndex = 15;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Количество";
            // 
            // cmbPeriods
            // 
            this.cmbPeriods.FormattingEnabled = true;
            this.cmbPeriods.Location = new System.Drawing.Point(169, 164);
            this.cmbPeriods.Name = "cmbPeriods";
            this.cmbPeriods.Size = new System.Drawing.Size(316, 22);
            this.cmbPeriods.TabIndex = 13;
            // 
            // cmbWeeks
            // 
            this.cmbWeeks.FormattingEnabled = true;
            this.cmbWeeks.Location = new System.Drawing.Point(169, 137);
            this.cmbWeeks.Name = "cmbWeeks";
            this.cmbWeeks.Size = new System.Drawing.Size(316, 22);
            this.cmbWeeks.TabIndex = 12;
            // 
            // cmbEquipments
            // 
            this.cmbEquipments.FormattingEnabled = true;
            this.cmbEquipments.Location = new System.Drawing.Point(169, 109);
            this.cmbEquipments.Name = "cmbEquipments";
            this.cmbEquipments.Size = new System.Drawing.Size(316, 22);
            this.cmbEquipments.TabIndex = 11;
            // 
            // cmbClassrooms
            // 
            this.cmbClassrooms.FormattingEnabled = true;
            this.cmbClassrooms.Location = new System.Drawing.Point(91, 78);
            this.cmbClassrooms.Name = "cmbClassrooms";
            this.cmbClassrooms.Size = new System.Drawing.Size(154, 22);
            this.cmbClassrooms.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Период";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Учебная неделя";
            // 
            // numToPair
            // 
            this.numToPair.Location = new System.Drawing.Point(346, 45);
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
            this.numToPair.Size = new System.Drawing.Size(139, 22);
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
            this.numFromPair.Size = new System.Drawing.Size(154, 22);
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
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Требуемое оборудование";
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
            this.label3.Location = new System.Drawing.Point(251, 48);
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
            this.ClientSize = new System.Drawing.Size(518, 263);
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
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
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
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.ComboBox cmbEquipments;
        private System.Windows.Forms.ComboBox cmbClassrooms;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label8;
    }
}