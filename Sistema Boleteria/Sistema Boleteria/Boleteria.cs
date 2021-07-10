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
    public partial class Boleteria : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        long idDestinos = 0;
        public Boleteria()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Boleteria_Load(object sender, EventArgs e)
        {
            var tDestino = from de in entity.Destinos
                           select new
                           {
                               de.idDestino,
                               de.destino
                           };
            DataTable dtDestino = tDestino.CopyAnonymusToDataTable();
            cmbDestino.DataSource = dtDestino;
            cmbDestino.DisplayMember = dtDestino.Columns[1].ColumnName;
            cmbDestino.ValueMember = dtDestino.Columns[0].ColumnName;
           

            var tTipoBoleto = from b in entity.TiposdeBoletos
                           select new
                           {
                               b.idTIpo,
                               b.tipodeBoleto
                           };
            DataTable dtTipoBoleto = tTipoBoleto.CopyAnonymusToDataTable();
            cmbTipoBoleto.DataSource = dtTipoBoleto;
            cmbTipoBoleto.DisplayMember = dtTipoBoleto.Columns[1].ColumnName;
            cmbTipoBoleto.ValueMember = dtTipoBoleto.Columns[0].ColumnName;

            txtEfectivo.Enabled = false;
            lblCambio.Enabled = false;
            btnPagar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDestino.SelectedIndex >= 0)
            {
                try
                {
                    // Al dar clic en el id que se muestra en la tabla los datos de los demás campos se llenaran
                    idDestinos = Convert.ToInt64(cmbDestino.SelectedIndex);
                    var tDestino = entity.Destinos.FirstOrDefault(x => x.idDestino == idDestinos);
                    lblPrecio.Text = tDestino.precio.ToString();
                  

                }
                catch (Exception)
                {

                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            lblCantidad.Text = txtCantidad.Text;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal total;
            decimal descuento;

            if(Convert.ToInt32(lblCantidad.Text) <= 0 || Convert.ToDecimal(lblPrecio.Text) <= 0)
            {
                MessageBox.Show("¡Cantidad inválida!");
                return;
            }
            else
            {
                total = Convert.ToInt32(lblCantidad.Text) * Convert.ToDecimal(lblPrecio.Text);
                if (Convert.ToInt32(lblCantidad.Text) >= 10)
                {
                    descuento = Convert.ToInt32(lblCantidad.Text) * 10;
                    total = total - descuento;
                }
                lblTotal.Text = Convert.ToString(total);
                txtEfectivo.Enabled = true;
                lblCambio.Enabled = true;
                btnPagar.Enabled = true;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(txtEfectivo.Text) < Convert.ToDecimal(lblTotal.Text))
            {
                MessageBox.Show("¡Cantidad pagada es inferior al total!");
                return;
            }
            else if (txtEfectivo.Text.Equals(""))
            {
                MessageBox.Show("¡Ingrese la cantidad de pago!");
                return;
            }
            else if (txtEfectivo.Text.Equals("0"))
            {
                MessageBox.Show("¡El efectivo no puede ser 0!");
                return;
            }
            else
            {
                lblCambio.Text = Convert.ToString(Convert.ToDecimal(txtEfectivo.Text) - Convert.ToDecimal(lblTotal.Text));
                btnImprimir.Enabled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImpresionBoleto boleto = new ImpresionBoleto();
            boleto.Show();

        }
    }
}
