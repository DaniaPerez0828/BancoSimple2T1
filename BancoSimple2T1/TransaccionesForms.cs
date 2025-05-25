using BancoSimple2T1.Data;
using Microsoft.EntityFrameworkCore;
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
    public partial class TransaccionesForms : Form
    {
        // Una alternativa es hacer los campos de cuenta origen,destino y la base de datos como readonly para evitar errores por modificación accidental.
        public decimal Monto { get; private set; }
        private int _cuentaOrigenId;
        private int _cuentaDestinoId;
        private BancoSimpleContext db;

        public TransaccionesForms(int cuentaOrigenId, int cuentaDestinoId)
        {
            InitializeComponent();
            _cuentaOrigenId = cuentaOrigenId;
            _cuentaDestinoId = cuentaDestinoId;
           
            db = new BancoSimpleContext();
            CargarInfoCuenta();

        }

        // Carga y muestra la información de las cuentas de origen y destino

        private void CargarInfoCuenta()
        {
            try
            {
                var cuentaOrigen = db.Cuenta.
                Include(c => c.cliente).
                First(c => c.CuentaId == _cuentaOrigenId);

                var cuentaDestino = db.Cuenta.
                   Include(c => c.cliente).
                   First(c => c.CuentaId == _cuentaDestinoId);

                lblOrigen.Text = $"Nombre: {cuentaOrigen.cliente.Nombre} cuenta {cuentaOrigen.NumeroCuenta}";
                lblDestino.Text = $"Nombre: {cuentaDestino.cliente.Nombre} cuenta {cuentaDestino.NumeroCuenta}";
                lblDisponible.Text = $"Saldo Disponible : {cuentaOrigen.Saldo:c}";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información de la cuenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldo.Text, out decimal monto) && monto > 0)
            {
                Monto = monto;
                DialogResult = DialogResult.OK;
                Close();
            }
            else {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
