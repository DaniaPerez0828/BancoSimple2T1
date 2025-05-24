namespace BancoSimple2T1
{
    partial class AgregarCuentaForm
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
            label1 = new Label();
            label2 = new Label();
            txtNumeroCuenta = new TextBox();
            numSaldoInicial = new NumericUpDown();
            btnAceptar = new Button();
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 0;
            label1.Text = "Numero de cuenta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 74);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 1;
            label2.Text = "Saldo Inicial";
            // 
            // txtNumeroCuenta
            // 
            txtNumeroCuenta.Location = new Point(249, 26);
            txtNumeroCuenta.Name = "txtNumeroCuenta";
            txtNumeroCuenta.Size = new Size(140, 27);
            txtNumeroCuenta.TabIndex = 2;
            // 
            // numSaldoInicial
            // 
            numSaldoInicial.Location = new Point(250, 83);
            numSaldoInicial.Name = "numSaldoInicial";
            numSaldoInicial.Size = new Size(139, 27);
            numSaldoInicial.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(125, 138);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(111, 36);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // AgregarCuentaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 185);
            Controls.Add(btnAceptar);
            Controls.Add(numSaldoInicial);
            Controls.Add(txtNumeroCuenta);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarCuentaForm";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNumeroCuenta;
        private NumericUpDown numSaldoInicial;
        private Button btnAceptar;
    }
}