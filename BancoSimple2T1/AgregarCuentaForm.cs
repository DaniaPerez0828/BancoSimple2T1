using BancoSimple2T1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSimple2T1
{
    public partial class AgregarCuentaForm : Form
    {
        public Cuenta NuevaCuenta { get;  private set; }
        private int _clienteId;
        private readonly int clienteId;
        public AgregarCuentaForm(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            this.clienteId = clienteId;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtNumeroCuenta.Text.Trim();
            decimal saldoInicial = numSaldoInicial.Value;

            if (string.IsNullOrWhiteSpace(numeroCuenta))
            {
                MessageBox.Show("El número de cuenta es obligatorio.");
                return;
            }

            if (saldoInicial < 0)
            {
                MessageBox.Show("El saldo inicial no puede ser negativo.");
                return;
            }

            NuevaCuenta = new Cuenta
            {
                NumeroCuenta = txtNumeroCuenta.Text,
                Saldo = numSaldoInicial.Value,
                ClienteId = _clienteId,
                Activo = true
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
