namespace AracKiralamaForm
{
    partial class Form1
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
            this.dataGridRezerve = new System.Windows.Forms.DataGridView();
            this.btnKabul = new System.Windows.Forms.Button();
            this.dataGridKabul = new System.Windows.Forms.DataGridView();
            this.btnİade = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezerve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKabul)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRezerve
            // 
            this.dataGridRezerve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRezerve.Location = new System.Drawing.Point(3, 12);
            this.dataGridRezerve.Name = "dataGridRezerve";
            this.dataGridRezerve.Size = new System.Drawing.Size(767, 136);
            this.dataGridRezerve.TabIndex = 0;
            this.dataGridRezerve.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRezerve_RowEnter);
            // 
            // btnKabul
            // 
            this.btnKabul.Location = new System.Drawing.Point(12, 154);
            this.btnKabul.Name = "btnKabul";
            this.btnKabul.Size = new System.Drawing.Size(157, 23);
            this.btnKabul.TabIndex = 2;
            this.btnKabul.Text = "Kabul";
            this.btnKabul.UseVisualStyleBackColor = true;
            this.btnKabul.Click += new System.EventHandler(this.btnKabul_Click);
            // 
            // dataGridKabul
            // 
            this.dataGridKabul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridKabul.Location = new System.Drawing.Point(12, 195);
            this.dataGridKabul.Name = "dataGridKabul";
            this.dataGridKabul.Size = new System.Drawing.Size(767, 136);
            this.dataGridKabul.TabIndex = 3;
            // 
            // btnİade
            // 
            this.btnİade.Location = new System.Drawing.Point(12, 355);
            this.btnİade.Name = "btnİade";
            this.btnİade.Size = new System.Drawing.Size(157, 23);
            this.btnİade.TabIndex = 4;
            this.btnİade.Text = "İade";
            this.btnİade.UseVisualStyleBackColor = true;
            this.btnİade.Click += new System.EventHandler(this.btnİade_Click);
            // 
            // btnRed
            // 
            this.btnRed.Location = new System.Drawing.Point(186, 154);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(157, 23);
            this.btnRed.TabIndex = 5;
            this.btnRed.Text = "Red";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnİade);
            this.Controls.Add(this.dataGridKabul);
            this.Controls.Add(this.btnKabul);
            this.Controls.Add(this.dataGridRezerve);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRezerve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKabul)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRezerve;
        private System.Windows.Forms.Button btnKabul;
        private System.Windows.Forms.DataGridView dataGridKabul;
        private System.Windows.Forms.Button btnİade;
        private System.Windows.Forms.Button btnRed;
    }
}

