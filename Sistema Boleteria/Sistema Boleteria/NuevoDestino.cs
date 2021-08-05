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
    public partial class NuevoDestino : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        long idDestinos = 0;
        bool editar = false;
        public NuevoDestino()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NuevoDestino_Load(object sender, EventArgs e)
        {
            var tDestino = from d in entity.Destinos
                           select new
                           {
                               d.idDestino,
                               d.destino,
                               d.precio
                           };
            DataTable dDestino = tDestino.CopyAnonymusToDataTable();
            dgDestinos.DataSource = dDestino;
            dgDestinos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            int valor = 0;
            if (txtDestino.Text.Equals("") || txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("¡Ingrese información en todos los campos!");
                return;
            }
            else if (!int.TryParse(txtPrecio.Text, out valor))
            {
                MessageBox.Show("¡Ingrese solo números en el precio!");
                return;
            }
            else if (int.TryParse(txtPrecio.Text, out valor))
            {
                precio = Convert.ToDecimal(txtPrecio.Text);
            }
            if (entity.Destinos.Any(x => x.destino == txtDestino.Text && x.precio == precio))
            {
                MessageBox.Show("¡El destino y precio ingresado ya existe!");
                return;
            }
            if (editar)
            {
                var tDestino = entity.Destinos.FirstOrDefault(x => x.idDestino == idDestinos);
                tDestino.destino = txtDestino.Text;
                tDestino.precio = Convert.ToDecimal(txtPrecio.Text);
                entity.SaveChanges();
            }
            else
            {
                Destinos tbDestino = new Destinos();
                tbDestino.destino = txtDestino.Text;
                tbDestino.precio = Convert.ToDecimal(txtPrecio.Text);
                entity.Destinos.Add(tbDestino);

                entity.SaveChanges();//se confirma la insercion
            }

            txtDestino.Text = "";
            txtPrecio.Text = "";
            idDestinos = 0;
            editar = false;

            var taDestino = from d in entity.Destinos
                           select new
                           {
                               d.idDestino,
                               d.destino,
                               d.precio
                           };
            dgDestinos.DataSource = taDestino.CopyAnonymusToDataTable();

            MessageBox.Show("Informacion guardada!");

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDestino.Text = "";
            txtPrecio.Text = "";
            idDestinos = 0;
            editar = false;
        }

        private void dgDestinos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDestinos.RowCount > 0)
            {
                try
                {
                    // Al dar clic en el id que se muestra en la tabla los datos de los demás campos se llenaran
                    idDestinos = Convert.ToInt64(dgDestinos.SelectedCells[0].Value);
                    var tDestino = entity.Destinos.FirstOrDefault(x => x.idDestino == idDestinos);
                    txtDestino.Text = tDestino.destino;
                    txtPrecio.Text = tDestino.precio.ToString();
                    editar = true;

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
