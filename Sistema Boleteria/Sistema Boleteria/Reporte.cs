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
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnVentasBoletos_Click(object sender, EventArgs e)
        {
            ReporteVentaBoletos reporte = new ReporteVentaBoletos();
            reporte.RequestParameters = false;
            /*   string pdfExportFile =
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                  @"\Downloads\" +
                  report.Name +
                  ".pdf";*/
            reporte.ExportToPdf("C:\\Reportes\\ReporteVentasBoletos.pdf");
        }
            

        private void btnVentaUsuarios_Click(object sender, EventArgs e)
        {
            ReporteVentasUsuarios reporte = new ReporteVentasUsuarios();
            reporte.RequestParameters = false;
            reporte.ExportToPdf("C:\\Reportes\\Reporte Ventas Usuarios.pdf");
        }

        private void btnReporteDestino_Click(object sender, EventArgs e)
        {
            ReporteDestinos reporte = new ReporteDestinos();
            reporte.RequestParameters = false;
            reporte.ExportToPdf("C:\\Reportes\\Reporte Ventas Destinos.pdf");
        }
    }
}
