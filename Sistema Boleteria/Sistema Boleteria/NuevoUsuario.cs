using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Regex claro1 = new Regex("[3]{1}[0-9]{8,8}$");
            Regex claro2 = new Regex("[8]{1}[0-9]{8,8}$");
            Regex tigo = new Regex("[9]{1}[0-9]{8,8}$");
            Regex fijo = new Regex("[2]{1}[0-9]{8,8}$");
            Regex identidad = new Regex("[0-9]{13,13}$");

            long valor = 0;
            if(txtPrimerNombre.Text.Equals("") || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || cmbGenero.Text.Equals("") || txtTelefono.Text.Equals("") || txtIdentidad.Text.Equals("") || txtDireccion.Text.Equals("") || txtUsuario.Text.Equals("") || txtContrasenia.Text.Equals("") || txtEdad.Text.Equals("") || cmbAdmin.Text.Equals(""))
            {
                MessageBox.Show("¡Tiene campos sin ingresar!");
                return;
            }
            else if (!long.TryParse(txtTelefono.Text, out valor) || !long.TryParse(txtIdentidad.Text, out valor) || !long.TryParse(txtEdad.Text, out valor))
            {
                MessageBox.Show("¡Ingrese solo números en los campos telefono, identidad y edad!");
                return;
            }else if (entity.Usuarios.Any(x => x.usuario == txtUsuario.Text))
            {
                MessageBox.Show("¡El usuario que ingreso ya existe!");
                return;
            }
            else if (txtUsuario.Text.Length < 8)
            {
                MessageBox.Show("¡El nombre de usuario debe tener al menos 8 caracteres!");
                return;
            }
            else if (txtContrasenia.Text.Length < 8)
            {
                MessageBox.Show("¡La contraseña debe tener al menos 8 caracteres!");
                return;
            }
            else if (txtTelefono.Text.Length < 8)
            {
                MessageBox.Show("¡El número de teléfono debe tener al menos 8 digitos!");
                return;
            }
        /*    else if (claro1.IsMatch(txtTelefono.Text) || claro2.IsMatch(txtTelefono.Text) || tigo.IsMatch(txtTelefono.Text) || fijo.IsMatch(txtTelefono.Text))
            {
                MessageBox.Show("Formato de teléfono válido");                
            }*/
            else if (txtIdentidad.Text.Length < 13)
            {
                MessageBox.Show("¡La identidad debe tener al menos 13 digitos!");
                return;
            }
            else if (!identidad.IsMatch(txtIdentidad.Text))
            {
                MessageBox.Show("Formato de identidad no válido");
                return;
            }
            else if (Convert.ToInt32(txtEdad.Text) < 18)
            {
                MessageBox.Show("¡La edad del empleado debe ser mayor o igual a 18!");
                return;
            }
            
            /* else if (int.TryParse(txtTelefono.Text, out valor) && int.TryParse(txtIdentidad.Text, out valor))
             {
                 precio = Convert.ToDecimal(txtPrecio.Text);
             }
            */
            else
            {
                Usuarios tbempleados = new Usuarios();
                tbempleados.primerNombre = txtPrimerNombre.Text;
                tbempleados.segundoNombre = txtSegundoNombre.Text;
                tbempleados.primerApellido = txtPrimerApellido.Text;
                tbempleados.segundoApellido = txtSegundoApellido.Text;
                tbempleados.genero = Convert.ToByte(cmbGenero.SelectedIndex+1);
                tbempleados.isAdmin = Convert.ToByte(cmbAdmin.SelectedIndex + 1);
                tbempleados.edad = Convert.ToByte(txtEdad.Text);
                tbempleados.telefono = txtTelefono.Text;
                tbempleados.direccion = txtDireccion.Text;
                tbempleados.identidad = txtIdentidad.Text;
                tbempleados.usuario = txtUsuario.Text;
                tbempleados.password = txtContrasenia.Text;
                tbempleados.estado = ckEstado.Checked;
                entity.Usuarios.Add(tbempleados);
                entity.SaveChanges();
            }
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            cmbGenero.Text = "";
            cmbAdmin.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtIdentidad.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            txtEdad.Text = "";
            ckEstado.Checked = false;

            MessageBox.Show("¡Información ingresada correctamente!");
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleados registro = new Empleados();
            registro.ShowDialog();
            this.Show();                     

        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            var tGenero = from d in entity.Generos                          
                            select new
                            {
                                d.idGenero,
                                d.genero,                        
                            };
            DataTable dGenero = tGenero.CopyAnonymusToDataTable();
            cmbGenero.DataSource = dGenero;
            cmbGenero.DisplayMember = dGenero.Columns[1].ColumnName;
            cmbGenero.ValueMember = dGenero.Columns[0].ColumnName;
            var tAdmin = from d in entity.Administradores
                          select new
                          {
                              d.idAdmin,
                              d.Admin,
                          };
            DataTable dAdmin = tAdmin.CopyAnonymusToDataTable();
            cmbAdmin.DataSource = dAdmin;
            cmbAdmin.DisplayMember = dAdmin.Columns[1].ColumnName;
            cmbAdmin.ValueMember = dAdmin.Columns[0].ColumnName;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarEmpleado modificar = new ModificarEmpleado();
            modificar.ShowDialog();
            this.Show();
        }
    }
}
