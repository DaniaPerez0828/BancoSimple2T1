namespace BancoSimple2T1
{
    partial class VerTransferenciaForms
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
            dgvTransferencias = new DataGridView();
            txtBuscarTransaccion = new TextBox();
            btnBuscarTransaccion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).BeginInit();
            SuspendLayout();
            // 
            // dgvTransferencias
            // 
            dgvTransferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransferencias.Location = new Point(60, 62);
            dgvTransferencias.Name = "dgvTransferencias";
            dgvTransferencias.RowHeadersWidth = 51;
            dgvTransferencias.Size = new Size(698, 376);
            dgvTransferencias.TabIndex = 0;
            // 
            // txtBuscarTransaccion
            // 
            txtBuscarTransaccion.Location = new Point(314, 12);
            txtBuscarTransaccion.Name = "txtBuscarTransaccion";
            txtBuscarTransaccion.Size = new Size(174, 27);
            txtBuscarTransaccion.TabIndex = 2;
            // 
            // btnBuscarTransaccion
            // 
            btnBuscarTransaccion.Location = new Point(108, 12);
            btnBuscarTransaccion.Name = "btnBuscarTransaccion";
            btnBuscarTransaccion.Size = new Size(170, 29);
            btnBuscarTransaccion.TabIndex = 4;
            btnBuscarTransaccion.Text = "Buscar Transaccion";
            btnBuscarTransaccion.UseVisualStyleBackColor = true;
            btnBuscarTransaccion.Click += btnBuscarTransaccion_Click;
            // 
            // VerTransferenciaForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscarTransaccion);
            Controls.Add(txtBuscarTransaccion);
            Controls.Add(dgvTransferencias);
            Name = "VerTransferenciaForms";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTransferencias;
        private TextBox txtBuscarTransaccion;
        private Button btnBuscarTransaccion;
    }
}