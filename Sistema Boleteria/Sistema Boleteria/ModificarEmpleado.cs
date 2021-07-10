using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Boleteria
{
    public partial class ModificarEmpleado : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        long idEmpleado = 0;
        bool editar = false;
        public ModificarEmpleado()
        {
            InitializeComponent();
        }

        private void ModificarEmpleado_Load(object sender, EventArgs e)
        {
            var tEmpleados = from em in entity.Usuarios
                             select new
                             {
                                 em.idUsuario,
                                 em.primerNombre,
                                 em.primerApellido
                             };
            DataTable dtEmpleados = tEmpleados.CopyAnonymusToDataTable();
            dgEmpleados.DataSource = dtEmpleados;
            dgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            Empleados registro = new Empleados();
            registro.Show();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text.Equals("") || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtGenero.Text.Equals("") || txtTelefono.Text.Equals("") || txtIdentidad.Text.Equals("") || txtDireccion.Text.Equals("") || txtUsuario.Text.Equals("") || txtContrasenia.Text.Equals(""))
            {
                MessageBox.Show("Tiene campos sin ingresar");
                return;
            }

            if (editar)
            {
                var tEmpleado = entity.Usuarios.FirstOrDefault(x => x.idUsuario == idEmpleado);
                tEmpleado.primerNombre = txtPrimerNombre.Text;
                tEmpleado.segundoNombre = txtSegundoNombre.Text;
                tEmpleado.primerApellido = txtPrimerApellido.Text;
                tEmpleado.segundoApellido = txtSegundoApellido.Text;
                tEmpleado.genero = txtGenero.Text;
                tEmpleado.telefono = txtTelefono.Text;
                tEmpleado.direccion = txtDireccion.Text;
                tEmpleado.identidad = txtIdentidad.Text;
                tEmpleado.usuario = txtUsuario.Text;
                tEmpleado.password = txtContrasenia.Text ;

                entity.SaveChanges();
                MessageBox.Show("¡Modificación exitosa!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtGenero.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtIdentidad.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            idEmpleado = 0;
            editar = false;
        }

        private void dgEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if( dgEmpleados.RowCount > 0)
            {
                try
                {
                    idEmpleado = Convert.ToInt64(dgEmpleados.SelectedCells[0].Value);
                    var tEmpleado = entity.Usuarios.FirstOrDefault(x => x.idUsuario == idEmpleado);
                    txtPrimerNombre.Text = tEmpleado.primerNombre;
                    txtSegundoNombre.Text = tEmpleado.segundoNombre;
                    txtPrimerApellido.Text = tEmpleado.primerApellido;
                    txtSegundoApellido.Text = tEmpleado.segundoApellido;
                    txtGenero.Text = tEmpleado.genero;
                    txtTelefono.Text = tEmpleado.telefono;
                    txtDireccion.Text = tEmpleado.direccion;
                    txtIdentidad.Text = tEmpleado.identidad;
                    txtUsuario.Text = tEmpleado.usuario;
                    txtContrasenia.Text = tEmpleado.password;
                    editar = true;
                }
                catch (Exception)
                {

                    
                }
                
            }
        }
    }
}
