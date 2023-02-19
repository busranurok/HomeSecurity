namespace WindowsFormsApp56
{
    partial class frmCustomerDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerDetail));
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerDescription = new System.Windows.Forms.RichTextBox();
            this.txtCustomerAddress = new System.Windows.Forms.RichTextBox();
            this.txtModelDirectory = new DevExpress.XtraEditors.TextEdit();
            this.txtModelXmlName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtModelFolderName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelXmlName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelFolderName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(98, 44);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(168, 20);
            this.txtCustomerName.TabIndex = 0;
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Location = new System.Drawing.Point(98, 77);
            this.txtCustomerDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(170, 78);
            this.txtCustomerDescription.TabIndex = 1;
            this.txtCustomerDescription.Text = "";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(98, 169);
            this.txtCustomerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(170, 84);
            this.txtCustomerAddress.TabIndex = 2;
            this.txtCustomerAddress.Text = "";
            // 
            // txtModelDirectory
            // 
            this.txtModelDirectory.Location = new System.Drawing.Point(98, 272);
            this.txtModelDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtModelDirectory.Name = "txtModelDirectory";
            this.txtModelDirectory.Size = new System.Drawing.Size(168, 20);
            this.txtModelDirectory.TabIndex = 0;
            // 
            // txtModelXmlName
            // 
            this.txtModelXmlName.Location = new System.Drawing.Point(98, 342);
            this.txtModelXmlName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtModelXmlName.Name = "txtModelXmlName";
            this.txtModelXmlName.Size = new System.Drawing.Size(168, 20);
            this.txtModelXmlName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 46);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Müşteri Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 78);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Açıklama";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 170);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Adres";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 274);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Model Dizin";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 343);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "XML Dosya Adı";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(6, 392);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(259, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtModelFolderName
            // 
            this.txtModelFolderName.Location = new System.Drawing.Point(98, 306);
            this.txtModelFolderName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtModelFolderName.Name = "txtModelFolderName";
            this.txtModelFolderName.Size = new System.Drawing.Size(168, 20);
            this.txtModelFolderName.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 308);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Model Klasör Adı";
            // 
            // frmCustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 435);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.txtCustomerDescription);
            this.Controls.Add(this.txtModelFolderName);
            this.Controls.Add(this.txtModelXmlName);
            this.Controls.Add(this.txtModelDirectory);
            this.Controls.Add(this.txtCustomerName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCustomerDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Detayı";
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelXmlName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelFolderName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private System.Windows.Forms.RichTextBox txtCustomerDescription;
        private System.Windows.Forms.RichTextBox txtCustomerAddress;
        private DevExpress.XtraEditors.TextEdit txtModelDirectory;
        private DevExpress.XtraEditors.TextEdit txtModelXmlName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtModelFolderName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}