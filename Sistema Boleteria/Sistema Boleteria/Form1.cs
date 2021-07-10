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
    public partial class Form1 : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            if (cmbUsuarios.Text.Equals(""))
            {
                MessageBox.Show("Por favor seleccionar usuario");
                return;
            }
            else if (txtContrasenia.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar contraseña");
                return;
            }

            /*
            if ()
            {
                MessageBox.Show("usuario correcto");
                return;
            }
            else
            {
                MessageBox.Show("usuario incorrecto");
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var tUsuario = from u in entity.Usuarios
                           select new
                           {
                               u.usuario,
                               u.password
                           };
            dgUsuarios.DataSource = tUsuario.CopyAnonymusToDataTable();
            dgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var tUsuarios = from u in entity.Usuarios
                           select new
                           {
                               u.idUsuario,
                               u.usuario,
                               u.password
                           };
            DataTable dtUsuarios = tUsuarios.CopyAnonymusToDataTable();
            cmbUsuarios.DataSource = dtUsuarios;
            cmbUsuarios.DisplayMember = dtUsuarios.Columns[1].ColumnName;
            cmbUsuarios.ValueMember = dtUsuarios.Columns[0].ColumnName;

            cmbUsuarios.Text = default;
        }
    }
}
