namespace XayDungPhanMem
{
    partial class QuanLyTieuDe
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnhuy = new System.Windows.Forms.Button();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Gia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgv_tieude = new System.Windows.Forms.DataGridView();
            this.cbb_tl = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tieude)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbb_tl);
            this.groupBox2.Controls.Add(this.btnhuy);
            this.groupBox2.Controls.Add(this.btn_Xoa);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.txt_id);
            this.groupBox2.Controls.Add(this.txt);
            this.groupBox2.Controls.Add(this.txt_ten);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(334, 199);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(467, 288);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tiêu đề";
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(136, 249);
            this.btnhuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(100, 28);
            this.btnhuy.TabIndex = 23;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(170, 435);
            this.txt_time.Margin = new System.Windows.Forms.Padding(4);
            this.txt_time.Name = "txt_time";
            this.txt_time.ReadOnly = true;
            this.txt_time.Size = new System.Drawing.Size(136, 26);
            this.txt_time.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 437);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "Thời gian thuê tối đa:";
            // 
            // txt_Gia
            // 
            this.txt_Gia.Location = new System.Drawing.Point(170, 386);
            this.txt_Gia.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Gia.Name = "txt_Gia";
            this.txt_Gia.ReadOnly = true;
            this.txt_Gia.Size = new System.Drawing.Size(136, 26);
            this.txt_Gia.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 388);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Giá thuê:";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(356, 249);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 28);
            this.btn_Xoa.TabIndex = 17;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(12, 249);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(100, 28);
            this.btn_them.TabIndex = 16;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(192, 42);
            this.txt_id.Margin = new System.Windows.Forms.Padding(4);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(264, 26);
            this.txt_id.TabIndex = 14;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(8, 45);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(82, 19);
            this.txt.TabIndex = 13;
            this.txt.Text = "ID tiêu đề:";
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(192, 91);
            this.txt_ten.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.ReadOnly = true;
            this.txt_ten.Size = new System.Drawing.Size(264, 26);
            this.txt_ten.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thể Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên tiêu đề:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.txt_time);
            this.groupBox1.Controls.Add(this.txt_Gia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(313, 474);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thể loại";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(299, 356);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(333, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 179);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách tiêu đề";
            // 
            // dgv_tieude
            // 
            this.dgv_tieude.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tieude.Location = new System.Drawing.Point(339, 39);
            this.dgv_tieude.Name = "dgv_tieude";
            this.dgv_tieude.RowHeadersWidth = 51;
            this.dgv_tieude.RowTemplate.Height = 24;
            this.dgv_tieude.Size = new System.Drawing.Size(451, 147);
            this.dgv_tieude.TabIndex = 2;
            this.dgv_tieude.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_tieude_RowStateChanged);
            // 
            // cbb_tl
            // 
            this.cbb_tl.FormattingEnabled = true;
            this.cbb_tl.Location = new System.Drawing.Point(192, 135);
            this.cbb_tl.Name = "cbb_tl";
            this.cbb_tl.Size = new System.Drawing.Size(264, 27);
            this.cbb_tl.TabIndex = 24;
            this.cbb_tl.SelectedIndexChanged += new System.EventHandler(this.cbb_tl_SelectedIndexChanged);
            // 
            // QuanLyTieuDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 501);
            this.Controls.Add(this.dgv_tieude);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QuanLyTieuDe";
            this.Text = "QuanLyTieuDe";
            this.Load += new System.EventHandler(this.QuanLyTieuDe_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tieude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Gia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgv_tieude;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.ComboBox cbb_tl;
    }
}