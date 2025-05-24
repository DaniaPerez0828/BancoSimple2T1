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
            try
            {
                dgvClientes.DataSource = _db.Cliente.ToList();

                var cuenta = _db.Cuenta.
                Include(c => c.cliente)
                .Where(c => c.Activo)
                .Select(c => new
                {
                    c.CuentaId,
                    c.NumeroCuenta,
                    c.Saldo,
                    NombreCliente = c.cliente.Nombre,
                    c.Activo,
                    c.ClienteId
                }).ToList();


                dgvCuentas.DataSource = cuenta;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar información: {ex.Message}", "Error");
            }
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var form = new AgregarClienteForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _db.Cliente.Add(form.NuevoCliente);
                    _db.SaveChanges();
                    CargarInfo();
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al agregar cliente: {ex.Message}", "Error");
                }
            }
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {

            if (!ValidarSeleccionUnica(dgvClientes, "ClienteId", out int clienteId)) return;

            var form = new AgregarCuentaForm(clienteId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _db.Cuenta.Add(form.NuevaCuenta);
                    _db.SaveChanges();
                    CargarInfo();
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al agregar cuenta: {ex.Message}", "Error");
                }
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
            if (!ValidarSeleccionDoble(dgvCuentas, "CuentaId", out int origenId, out int destinoId)) return;

            var form = new TransaccionesForms(origenId, destinoId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RealizarTransaccion(origenId, destinoId, form.Monto);
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al realizar transacción: {ex.Message}", "Error");
                }
            }
        }

        private void btnBuscarCleinte_Click(object sender, EventArgs e)
        {
            string patron = txtBuscarCliente.Text.Trim();
            if (string.IsNullOrEmpty(patron))
            {
                MostrarMensaje("Por favor ingrese un nombre o parte del nombre para buscar.", "Validación");
                return;
            }
            try
            {
                //Busqueda de patrones con like
                var resultados = _db.Cliente
                    .Where(c => EF.Functions.Like(c.Nombre, $"%{patron}%"))
                    .ToList();

                dgvClientes.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al buscar clientes: {ex.Message}", "Error");
            }
        }

        private void btnVerTrans_Click(object sender, EventArgs e)
        {
            var form = new VerTransferenciaForms();
            form.ShowDialog();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionUnica(dgvCuentas, "CuentaId", out int cuentaId)) return;

            try
            {
                var cuenta = _db.Cuenta.Find(cuentaId);
                if (cuenta != null)
                {
                    cuenta.Activo = false;
                    _db.SaveChanges();
                    CargarInfo();
                }
                else
                {
                    MostrarMensaje("Cuenta no encontrada.", "Error");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al desactivar cuenta: {ex.Message}", "Error");
            }
        }
        private bool ValidarSeleccionUnica(DataGridView grid, string idColumna, out int id)
        {
            id = 0;
            if (grid.SelectedRows.Count != 1)
            {
                MostrarMensaje("Seleccione exactamente un registro.", "Validación");
                return false;
            }

            id = (int)grid.SelectedRows[0].Cells[idColumna].Value;
            return true;
        }

        private bool ValidarSeleccionDoble(DataGridView grid, string idColumna, out int id1, out int id2)
        {
            id1 = id2 = 0;
            if (grid.SelectedRows.Count != 2)
            {
                MostrarMensaje("Seleccione exactamente dos registros.", "Validación");
                return false;
            }

            id1 = (int)grid.SelectedRows[0].Cells[idColumna].Value;
            id2 = (int)grid.SelectedRows[1].Cells[idColumna].Value;
            return true;
        }

        private void MostrarMensaje(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtBuscarCuenta.Text.Trim();

            if (string.IsNullOrEmpty(numeroCuenta))
            {
                MessageBox.Show("Por favor ingrese un número de cuenta para buscar.", "Validación");
                return;
            }

            try
            {
                var resultados = _db.Cuenta
                    .Include(c => c.cliente)
                    .Where(c => c.NumeroCuenta.Contains(numeroCuenta))
                    .Select(c => new
                    {
                        c.CuentaId,
                        c.NumeroCuenta,
                        c.Saldo,
                        NombreCliente = c.cliente.Nombre,
                        c.Activo,
                        c.ClienteId
                    })
                    .ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron cuentas que coincidan.", "Resultado");
                }

                dgvCuentas.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cuentas: {ex.Message}", "Error");
            }
        }
    }
}
