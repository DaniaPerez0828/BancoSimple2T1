namespace BancoSimple2T1
{
    partial class TransaccionesForms
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
            lblOrigen = new Label();
            btnAceptar = new Button();
            lblMonto = new Label();
            lblDestino = new Label();
            btnCancelar = new Button();
            lblDisponible = new Label();
            txtSaldo = new TextBox();
            SuspendLayout();
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(44, 48);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(50, 20);
            lblOrigen.TabIndex = 0;
            lblOrigen.Text = "label1";
            lblOrigen.Click += label1_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(44, 228);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(141, 55);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(44, 98);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(53, 20);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto";
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(44, 148);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(50, 20);
            lblDestino.TabIndex = 4;
            lblDestino.Text = "label3";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(281, 228);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 55);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.Location = new Point(295, 103);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(53, 20);
            lblDisponible.TabIndex = 6;
            lblDisponible.Text = "Monto";
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(121, 96);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(105, 27);
            txtSaldo.TabIndex = 7;
            // 
            // TransaccionesForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 317);
            Controls.Add(txtSaldo);
            Controls.Add(lblDisponible);
            Controls.Add(btnCancelar);
            Controls.Add(lblDestino);
            Controls.Add(lblMonto);
            Controls.Add(btnAceptar);
            Controls.Add(lblOrigen);
            Name = "TransaccionesForms";
            Text = "TransaccionesForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrigen;
        private Button btnAceptar;
        private Label lblMonto;
        private Label lblDestino;
        private Button btnCancelar;
        private Label lblDisponible;
        private TextBox txtSaldo;
    }
}