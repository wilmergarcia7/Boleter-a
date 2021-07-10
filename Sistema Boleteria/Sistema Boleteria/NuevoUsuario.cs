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
    public partial class NuevoUsuario : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtPrimerNombre.Text.Equals("") || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtGenero.Text.Equals("") || txtTelefono.Text.Equals("") || txtIdentidad.Text.Equals("") || txtDireccion.Text.Equals("") || txtUsuario.Text.Equals("") || txtContrasenia.Text.Equals(""))
            {
                MessageBox.Show("Tiene campos sin ingresar");
                return;
            }
            else
            {
                Usuarios tbempleados = new Usuarios();
                tbempleados.primerNombre = txtPrimerNombre.Text;
                tbempleados.segundoNombre = txtSegundoNombre.Text;
                tbempleados.primerApellido = txtPrimerApellido.Text;
                tbempleados.segundoApellido = txtSegundoApellido.Text;
                tbempleados.genero = txtGenero.Text;
                tbempleados.telefono = txtTelefono.Text;
                tbempleados.direccion = txtDireccion.Text;
                tbempleados.identidad = txtIdentidad.Text;
                tbempleados.usuario = txtUsuario.Text;
                tbempleados.password = txtContrasenia.Text;
                entity.Usuarios.Add(tbempleados);
                entity.SaveChanges();
            }
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

            MessageBox.Show("¡Información ingresada correctamente!");
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            Empleados registro = new Empleados();
            registro.Show();
            
        }
    }
}
