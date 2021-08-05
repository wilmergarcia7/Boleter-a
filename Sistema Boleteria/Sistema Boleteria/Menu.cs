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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = Form1.Admin.ToString();
            lblIdUser.Text = Form1.idUsuario.ToString();
            lblUsuario.Text = Form1.Usuario.ToString();

            if (lblAdmin.Text=="2")
            {
                btnDestinos.Visible = false;
                btnEmpleados.Visible = false;
                btnTiposBoleto.Visible = false;
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            NuevoUsuario Usuario = new NuevoUsuario();
            Usuario.ShowDialog();
            this.Show();
        }

        private void btnDestinos_Click(object sender, EventArgs e)
        {
            this.Hide();
            NuevoDestino nuevoDestino = new NuevoDestino();
            nuevoDestino.ShowDialog();
            this.Show();
        }

        private void btnBoleteria_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boleteria boleteria = new Boleteria();
            boleteria.ShowDialog();
            this.Show();
        }

        private void btnTiposBoleto_Click(object sender, EventArgs e)
        {
            this.Hide();
            TipoBoleto tBoleto = new TipoBoleto();
            tBoleto.ShowDialog();
            this.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
            this.Show();
        }
    }
}
