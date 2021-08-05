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
    public partial class TipoBoleto : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        long idTipoBoleto = 0;
        bool editar = false;
        public TipoBoleto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgDestinos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTipoBoleto.RowCount > 0)
            {
                try
                {
                    // Al dar clic en el id que se muestra en la tabla los datos de los demás campos se llenaran
                    idTipoBoleto = Convert.ToInt64(dgTipoBoleto.SelectedCells[0].Value);
                    var tTipoBoleto = entity.TiposdeBoletos.FirstOrDefault(x => x.idTIpo == idTipoBoleto);
                    txtTipoBoleto.Text = tTipoBoleto.tipodeBoleto;
                    editar = true;

                }
                catch (Exception)
                {

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtTipoBoleto.Text = "";
            idTipoBoleto = 0;
            editar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtTipoBoleto.Text.Equals("") )
            {
                MessageBox.Show("¡Ingrese información en todos los campos!");
                return;
            }else if (entity.TiposdeBoletos.Any(x => x.tipodeBoleto == txtTipoBoleto.Text))
            {
                MessageBox.Show("¡Este tipo de boleto ya existe!");
                return;
            }
            if (editar)
            {
                var tTipoBoleto = entity.TiposdeBoletos.FirstOrDefault(x => x.idTIpo == idTipoBoleto);
                tTipoBoleto.tipodeBoleto = txtTipoBoleto.Text;
                
                entity.SaveChanges();
            }
            else
            {
                TiposdeBoletos tbTipoBoleto = new TiposdeBoletos();
                tbTipoBoleto.tipodeBoleto = txtTipoBoleto.Text;

                entity.TiposdeBoletos.Add(tbTipoBoleto);

                entity.SaveChanges();//se confirma la insercion
            }

            txtTipoBoleto.Text = "";
            
            idTipoBoleto = 0;
            editar = false;

            var taTipoBoleto = from d in entity.TiposdeBoletos
                            select new
                            {
                                d.idTIpo,
                                d.tipodeBoleto
                            };
            dgTipoBoleto.DataSource = taTipoBoleto.CopyAnonymusToDataTable();

            MessageBox.Show("¡Informacion guardada!");
        }

        private void TipoBoleto_Load(object sender, EventArgs e)
        {
            var tTipoBoleto = from d in entity.TiposdeBoletos
                              select new
                              {
                                  d.idTIpo,
                                  d.tipodeBoleto
                                
                           };
            DataTable dtTipoBoleto = tTipoBoleto.CopyAnonymusToDataTable();
            dgTipoBoleto.DataSource = dtTipoBoleto;
            dgTipoBoleto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
