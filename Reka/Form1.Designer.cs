namespace Reka
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHead = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.txtArrayIndexNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHead
            // 
            this.dgvHead.AllowUserToAddRows = false;
            this.dgvHead.AllowUserToDeleteRows = false;
            this.dgvHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHead.Location = new System.Drawing.Point(12, 12);
            this.dgvHead.Name = "dgvHead";
            this.dgvHead.Size = new System.Drawing.Size(863, 75);
            this.dgvHead.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(174, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 105);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(863, 405);
            this.dgvData.TabIndex = 2;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(12, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtArrayIndexNumber
            // 
            this.txtArrayIndexNumber.Location = new System.Drawing.Point(93, 529);
            this.txtArrayIndexNumber.Name = "txtArrayIndexNumber";
            this.txtArrayIndexNumber.Size = new System.Drawing.Size(75, 20);
            this.txtArrayIndexNumber.TabIndex = 4;
            this.txtArrayIndexNumber.Text = "0";
            this.txtArrayIndexNumber.TextChanged += new System.EventHandler(this.txtArrayIndexNumber_TextChanged);
            this.txtArrayIndexNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArrayIndexNumber_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 562);
            this.Controls.Add(this.txtArrayIndexNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvHead);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reka Daten";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHead;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox txtArrayIndexNumber;
    }
}

