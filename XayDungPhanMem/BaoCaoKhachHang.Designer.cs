namespace XayDungPhanMem
{
    partial class BaoCaoKhachHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_totaldiatra = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_totalkhnop = new System.Windows.Forms.TextBox();
            this.cb_listkh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_dskh = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_totaldia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idkh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_phino = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.txt_cmnd = new System.Windows.Forms.TextBox();
            this.txt_tenkh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_nghethan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_tieude = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv_dsdiathue = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dskh)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdiathue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_totaldiatra);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_totalkhnop);
            this.groupBox1.Controls.Add(this.cb_listkh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dgv_dskh);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách khách hàng";
            // 
            // txt_totaldiatra
            // 
            this.txt_totaldiatra.Location = new System.Drawing.Point(172, 424);
            this.txt_totaldiatra.Name = "txt_totaldiatra";
            this.txt_totaldiatra.ReadOnly = true;
            this.txt_totaldiatra.Size = new System.Drawing.Size(98, 22);
            this.txt_totaldiatra.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tổng KH chưa trả đĩa:";
            // 
            // txt_totalkhnop
            // 
            this.txt_totalkhnop.Location = new System.Drawing.Point(172, 399);
            this.txt_totalkhnop.Name = "txt_totalkhnop";
            this.txt_totalkhnop.ReadOnly = true;
            this.txt_totalkhnop.Size = new System.Drawing.Size(98, 22);
            this.txt_totalkhnop.TabIndex = 22;
            // 
            // cb_listkh
            // 
            this.cb_listkh.FormattingEnabled = true;
            this.cb_listkh.Location = new System.Drawing.Point(148, 0);
            this.cb_listkh.Name = "cb_listkh";
            this.cb_listkh.Size = new System.Drawing.Size(121, 23);
            this.cb_listkh.TabIndex = 2;
            this.cb_listkh.SelectedIndexChanged += new System.EventHandler(this.cb_listkh_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tổng KH chưa nộp phí trễ hẹn:";
            // 
            // dgv_dskh
            // 
            this.dgv_dskh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dskh.Location = new System.Drawing.Point(6, 28);
            this.dgv_dskh.Name = "dgv_dskh";
            this.dgv_dskh.RowHeadersWidth = 51;
            this.dgv_dskh.Size = new System.Drawing.Size(305, 355);
            this.dgv_dskh.TabIndex = 1;
            this.dgv_dskh.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_dskh_RowStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_totaldia);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_idkh);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_phino);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_sdt);
            this.groupBox2.Controls.Add(this.txt_cmnd);
            this.groupBox2.Controls.Add(this.txt_tenkh);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(335, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 226);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // txt_totaldia
            // 
            this.txt_totaldia.Location = new System.Drawing.Point(123, 189);
            this.txt_totaldia.Name = "txt_totaldia";
            this.txt_totaldia.ReadOnly = true;
            this.txt_totaldia.Size = new System.Drawing.Size(199, 22);
            this.txt_totaldia.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tổng đĩa thuê:";
            // 
            // txt_idkh
            // 
            this.txt_idkh.Location = new System.Drawing.Point(123, 29);
            this.txt_idkh.Name = "txt_idkh";
            this.txt_idkh.ReadOnly = true;
            this.txt_idkh.Size = new System.Drawing.Size(199, 22);
            this.txt_idkh.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "ID KH:";
            // 
            // txt_phino
            // 
            this.txt_phino.Location = new System.Drawing.Point(123, 161);
            this.txt_phino.Name = "txt_phino";
            this.txt_phino.ReadOnly = true;
            this.txt_phino.Size = new System.Drawing.Size(199, 22);
            this.txt_phino.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số Phí Nợ:";
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(123, 128);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.ReadOnly = true;
            this.txt_sdt.Size = new System.Drawing.Size(199, 22);
            this.txt_sdt.TabIndex = 10;
            // 
            // txt_cmnd
            // 
            this.txt_cmnd.Location = new System.Drawing.Point(123, 95);
            this.txt_cmnd.Name = "txt_cmnd";
            this.txt_cmnd.ReadOnly = true;
            this.txt_cmnd.Size = new System.Drawing.Size(199, 22);
            this.txt_cmnd.TabIndex = 9;
            // 
            // txt_tenkh
            // 
            this.txt_tenkh.Location = new System.Drawing.Point(123, 62);
            this.txt_tenkh.Name = "txt_tenkh";
            this.txt_tenkh.ReadOnly = true;
            this.txt_tenkh.Size = new System.Drawing.Size(199, 22);
            this.txt_tenkh.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "SDT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "CMND";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Họ Và Tên:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_nghethan);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_tieude);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dgv_dsdiathue);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(335, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 202);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đĩa đã thuê";
            // 
            // txt_nghethan
            // 
            this.txt_nghethan.Location = new System.Drawing.Point(295, 165);
            this.txt_nghethan.Name = "txt_nghethan";
            this.txt_nghethan.ReadOnly = true;
            this.txt_nghethan.Size = new System.Drawing.Size(84, 22);
            this.txt_nghethan.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(216, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Ngày hết hạn:";
            // 
            // txt_tieude
            // 
            this.txt_tieude.Location = new System.Drawing.Point(86, 165);
            this.txt_tieude.Name = "txt_tieude";
            this.txt_tieude.ReadOnly = true;
            this.txt_tieude.Size = new System.Drawing.Size(92, 22);
            this.txt_tieude.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tên tiêu đề:";
            // 
            // dgv_dsdiathue
            // 
            this.dgv_dsdiathue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsdiathue.Location = new System.Drawing.Point(6, 18);
            this.dgv_dsdiathue.Name = "dgv_dsdiathue";
            this.dgv_dsdiathue.RowHeadersWidth = 51;
            this.dgv_dsdiathue.Size = new System.Drawing.Size(442, 133);
            this.dgv_dsdiathue.TabIndex = 0;
            this.dgv_dsdiathue.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_dsdiathue_RowStateChanged);
            // 
            // BaoCaoKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 491);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaoCaoKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaoCaoKhachHang";
            this.Load += new System.EventHandler(this.BaoCaoKhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dskh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdiathue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dskh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_idkh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_phino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_cmnd;
        private System.Windows.Forms.TextBox txt_tenkh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_listkh;
        private System.Windows.Forms.TextBox txt_totaldia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_dsdiathue;
        private System.Windows.Forms.TextBox txt_totaldiatra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_totalkhnop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tieude;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nghethan;
        private System.Windows.Forms.Label label10;
    }
}