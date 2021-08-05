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
    public partial class ImpresionBoleto : Form
    {
        BDBoleteriaEntities entity = new BDBoleteriaEntities();
        public ImpresionBoleto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ImpresionBoleto_Load(object sender, EventArgs e)
        {
            lblIdBoleto.Text = Boleteria.idBoleto.ToString();
            byte idBoleto = Convert.ToByte(Boleteria.idBoleto);

             var tFact = entity.Boletos.FirstOrDefault(x => x.idBoleto == idBoleto);
             lblDestino.Text = tFact.Destinos.destino;
            lblCantidad.Text = tFact.cantidad.ToString();
            lblTotalpagado.Text = tFact.efectivoTotal.ToString();
            lblFechaEmisión.Text = tFact.fechaEmision.ToString();
        }
    }
}
