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
    public partial class AgregarClienteForm : Form
    {
        public Cliente NuevoCliente { get; private set; }
        public AgregarClienteForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!CamposSonValidos(out string mensajeError))
            {
                MessageBox.Show("Todos los campos son necesarios");
                return;
            }
            NuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Identificacion = txtIdentificacion.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private bool CamposSonValidos(out string mensajeError)
        {
            mensajeError = string.Empty;
            string nombre = txtNombre.Text.Trim();
            string identificacion = txtIdentificacion.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                mensajeError = "El campo Nombre es obligatorio.";
                return false;
            }

            if (string.IsNullOrEmpty(identificacion))
            {
                mensajeError = "El campo Identificación es obligatorio.";
                return false;
            }

            if (identificacion.Length < 5)
            {
                mensajeError = "La Identificación debe tener al menos 5 caracteres.";
                return false;
            }

            return true;
        }
    }
}
