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
    public partial class Empleados : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            var tEmpleados = from em in entity.Usuarios
                             select new
                             {
                                 em.idUsuario,
                                 em.primerNombre,
                                 em.primerApellido,
                                 em.telefono,
                                 em.identidad
                             };
            DataTable dtEmpleados = tEmpleados.CopyAnonymusToDataTable();
            dgEmpleados.DataSource = dtEmpleados;
            dgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
