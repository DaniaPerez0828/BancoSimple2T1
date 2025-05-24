namespace BancoSimple2T1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvClientes = new DataGridView();
            btnAgregarCliente = new Button();
            dgvCuentas = new DataGridView();
            btnAgregarCuenta = new Button();
            label1 = new Label();
            label2 = new Label();
            btnTransferencia = new Button();
            btnBuscarCleinte = new Button();
            txtBuscarCliente = new TextBox();
            btnVerTrans = new Button();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(72, 160);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(469, 287);
            dgvClientes.TabIndex = 0;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Location = new Point(72, 470);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(143, 57);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "AgregarCliente";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // dgvCuentas
            // 
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentas.Location = new Point(594, 160);
            dgvCuentas.Name = "dgvCuentas";
            dgvCuentas.RowHeadersWidth = 51;
            dgvCuentas.Size = new Size(469, 287);
            dgvCuentas.TabIndex = 2;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.Location = new Point(594, 470);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(143, 57);
            btnAgregarCuenta.TabIndex = 3;
            btnAgregarCuenta.Text = "AgregarCuenta";
            btnAgregarCuenta.UseVisualStyleBackColor = true;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 118);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(594, 118);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 5;
            label2.Text = "Cuenta";
            // 
            // btnTransferencia
            // 
            btnTransferencia.Location = new Point(761, 470);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(143, 57);
            btnTransferencia.TabIndex = 6;
            btnTransferencia.Text = "Transferencia";
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnBuscarCleinte
            // 
            btnBuscarCleinte.Location = new Point(29, 74);
            btnBuscarCleinte.Name = "btnBuscarCleinte";
            btnBuscarCleinte.Size = new Size(145, 34);
            btnBuscarCleinte.TabIndex = 7;
            btnBuscarCleinte.Text = "Buscar Cliente";
            btnBuscarCleinte.UseVisualStyleBackColor = true;
            btnBuscarCleinte.Click += btnBuscarCleinte_Click;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(234, 74);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(216, 27);
            txtBuscarCliente.TabIndex = 8;
            // 
            // btnVerTrans
            // 
            btnVerTrans.Location = new Point(920, 470);
            btnVerTrans.Name = "btnVerTrans";
            btnVerTrans.Size = new Size(143, 57);
            btnVerTrans.TabIndex = 9;
            btnVerTrans.Text = "Ver Transferencia";
            btnVerTrans.UseVisualStyleBackColor = true;
            btnVerTrans.Click += btnVerTrans_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(594, 533);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(143, 57);
            btnDesactivar.TabIndex = 10;
            btnDesactivar.Text = "Desactivar Cuenta";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 591);
            Controls.Add(btnDesactivar);
            Controls.Add(btnVerTrans);
            Controls.Add(txtBuscarCliente);
            Controls.Add(btnBuscarCleinte);
            Controls.Add(btnTransferencia);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAgregarCuenta);
            Controls.Add(dgvCuentas);
            Controls.Add(btnAgregarCliente);
            Controls.Add(dgvClientes);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnAgregarCliente;
        private DataGridView dgvCuentas;
        private Button btnAgregarCuenta;
        private Label label1;
        private Label label2;
        private Button btnTransferencia;
        private Button btnBuscarCleinte;
        private TextBox txtBuscarCliente;
        private Button btnVerTrans;
        private Button btnDesactivar;
    }
}
