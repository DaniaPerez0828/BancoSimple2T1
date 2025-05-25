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
    public partial class VerTransferenciaForms : Form
    {
        private BancoSimpleContext con = new BancoSimpleContext();
        public VerTransferenciaForms()
        {
            InitializeComponent();
            CargarTransferencias();
        }

        private void CargarTransferencias()
        {
            dgvTransferencias.DataSource = con.Transacciones.ToList();
        }

        private void btnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscarTransaccion.Text.Trim(), out int cuentaId))
            {
                MessageBox.Show("Por favor ingrese un ID de cuenta válido (número entero).", "Validación");
                return;
            }

            try
            {
                var resultados = con.Transacciones
                    .Where(t => t.CuentaOrigenId == cuentaId || t.CuentaDestinoId == cuentaId)
                    .ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron transacciones para esta cuenta.", "Resultado");
                }

                dgvTransferencias.DataSource = null;
                dgvTransferencias.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar transacciones: {ex.Message}", "Error");
            }
        }
    }
}
