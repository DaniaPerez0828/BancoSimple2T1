using BancoSimple2T1.Data;
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
    }
}
