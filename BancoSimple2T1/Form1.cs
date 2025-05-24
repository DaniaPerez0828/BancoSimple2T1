using BancoSimple2T1.Data;
using BancoSimple2T1.Models;
using Microsoft.EntityFrameworkCore;
namespace BancoSimple2T1
    
{
    public partial class Form1 : Form
    {
        private BancoSimpleContext _db = new BancoSimpleContext();
        public Form1()
        {
            InitializeComponent();
            CargarInfo();
        }

        private void CargarInfo()
        {
            var cuenta = _db.Cuenta.
                Include(c => c.cliente).Where(c => c.Activo).
                Select(c => new
                {
                    c.CuentaId,
                    c.NumeroCuenta,
                    c.Saldo,
                    NombreCliente = c.cliente.Nombre,
                    c.Activo,
                    c.ClienteId
                }).ToList();

            dgvClientes.DataSource = _db.Cliente.ToList();
            dgvCuentas.DataSource = cuenta;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var form = new AgregarClienteForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _db.Cliente.Add(form.NuevoCliente);
                _db.SaveChanges();
                CargarInfo();

            }
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente primero");
                return;
            }
            var clienteId = (int)dgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
            var form = new AgregarCuentaForm(clienteId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _db.Cuenta.Add(form.NuevaCuenta);
                _db.SaveChanges();
                CargarInfo();
            }
        }
        //Transacciones
        private void RealizarTransaccion(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            //implementacion
            //Nivel de aislamiento
            using var transferencia = _db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                //Filtro y ordenacion
                var cuentaOrigen = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaOrigenId);
                var cuentaDestino = _db.Cuenta.FirstOrDefault(c => c.CuentaId == cuentaDestinoId);

                if (cuentaOrigen == null || cuentaDestino == null)
                    throw new Exception("Una o ambas cuentas no existen");

                if (!cuentaOrigen.Activo || !cuentaDestino.Activo)
                    throw new Exception("Una o ambas cuentas están inactivas");
                if (cuentaOrigen.Saldo < monto)
                    throw new Exception("Saldo Insuficiente en la cuenta Origen");

                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;

                //Registrar la transaccion
                _db.Transacciones.Add(new Transaccion
                {
                    Monto = monto,
                    Fecha = DateTime.Now,
                    Descripcion = "Transferencia entre cuentas",
                    CuentaOrigenId = cuentaOrigenId,
                    CuentaDestinoId = cuentaDestinoId
                });
                _db.SaveChanges();
                //Transaccion completada
                transferencia.Commit();
                MessageBox.Show("Transferencia realizada");
                CargarInfo();


            }
            catch (Exception ex)
            {
                transferencia.Rollback();

                var inner = ex.InnerException?.Message ?? "No hay InnerException";
                MessageBox.Show($"Error al guardar:\n{ex.Message}\n\nDetalle:\n{inner}");
            }

        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 2)
            {
                MessageBox.Show("Seleccione exactamente 2 cuentas");
                return;
            }
            var cuentaOrigenId = (int)dgvCuentas.SelectedRows[1].Cells["CuentaId"].Value;
            var cuentaDestinoId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;

            var form = new TransaccionesForms(cuentaOrigenId, cuentaDestinoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RealizarTransaccion(cuentaOrigenId, cuentaDestinoId, form.Monto);
            }

        }

        private void btnBuscarCleinte_Click(object sender, EventArgs e)
        {
            //Busqueda de patrones con like
            var patron = txtBuscarCliente.Text;
            var cliente = _db.Cliente.Where(c => EF.Functions.Like(c.Nombre, $"%{patron}%")).ToList();

            dgvClientes.DataSource = cliente;
        }

        private void btnVerTrans_Click(object sender, EventArgs e)
        {
            var form = new VerTransferenciaForms();
            form.ShowDialog();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciones solo una cuenta exactamente");
                return;
            }
            else
            {
                var cuentaId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;
                var cuenta = _db.Cuenta.Find(cuentaId);
                cuenta.Activo = false;
                _db.SaveChanges();
                CargarInfo();
            }
        }
    }
}
