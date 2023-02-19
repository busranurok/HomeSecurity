namespace GuvenlikDesktop
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnTrain = new DevExpress.XtraEditors.SimpleButton();
            this.btnCamera = new DevExpress.XtraEditors.SimpleButton();
            this.btnCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.btnUser = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Image = ((System.Drawing.Image)(resources.GetObject("btnTrain.Image")));
            this.btnTrain.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnTrain.Location = new System.Drawing.Point(6, 16);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(98, 83);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "Model Eğitimi";
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Image = ((System.Drawing.Image)(resources.GetObject("btnCamera.Image")));
            this.btnCamera.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCamera.Location = new System.Drawing.Point(12, 16);
            this.btnCamera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(98, 83);
            this.btnCamera.TabIndex = 0;
            this.btnCamera.Text = "Kamera";
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCustomer.Location = new System.Drawing.Point(11, 16);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(98, 83);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Müşteri";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTrain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(2, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(115, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCamera);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(117, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(124, 107);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.btnCustomer);
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpCustomer.Location = new System.Drawing.Point(383, 15);
            this.grpCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCustomer.Size = new System.Drawing.Size(128, 107);
            this.grpCustomer.TabIndex = 3;
            this.grpCustomer.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpUser);
            this.groupBox3.Controls.Add(this.grpCustomer);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(513, 124);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.btnUser);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpUser.Location = new System.Drawing.Point(255, 15);
            this.grpUser.Margin = new System.Windows.Forms.Padding(2);
            this.grpUser.Name = "grpUser";
            this.grpUser.Padding = new System.Windows.Forms.Padding(2);
            this.grpUser.Size = new System.Drawing.Size(128, 107);
            this.grpUser.TabIndex = 4;
            this.grpUser.TabStop = false;
            // 
            // btnUser
            // 
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUser.Location = new System.Drawing.Point(11, 16);
            this.btnUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(98, 83);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Kullanıcı";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 124);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpCustomer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTrain;
        private DevExpress.XtraEditors.SimpleButton btnCamera;
        private DevExpress.XtraEditors.SimpleButton btnCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpUser;
        private DevExpress.XtraEditors.SimpleButton btnUser;
    }
}