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
        internal static int idUsuario;
        internal static string Usuario;
        internal static int Admin;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public bool verificarUsuario(string usuario)
        {

            return entity.Usuarios.Any(x => x.usuario == usuario);

        }

        public bool verificarPass(string pass)
        {

            return entity.Usuarios.Any(x => x.password == pass);

        }
      
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese un usuario");
                return;
            }
            else if (txtContrasenia.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar contraseña");
                return;
            } else if (verificarUsuario(txtUsuario.Text) && verificarPass(txtContrasenia.Text))
            {
                var tUsuarios = from d in entity.Usuarios
                                where d.estado == true
                                select new
                                {
                                    d.idUsuario,
                                    d.usuario,
                                    d.isAdmin,
                                    d.estado,
                                };
                DataTable dUsuarios = tUsuarios.CopyAnonymusToDataTable();
                dgUsuarios.DataSource = dUsuarios;
                dgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (dgUsuarios.RowCount > 0)
                {
                    try
                    {
                        // Al dar clic en el id que se muestra en la tabla los datos de los demás campos se llenaran

                        var taUsuario = entity.Usuarios.FirstOrDefault(x => x.usuario == txtUsuario.Text);
                        lblAdmin.Text = taUsuario.isAdmin.ToString();
                        lblIdUser.Text = taUsuario.idUsuario.ToString();
                        lblUsuario.Text = taUsuario.usuario.ToString();
                    }
                    catch (Exception)
                    {

                    }
                }

               
                
                if (lblAdmin.Text == "1")
                {
                    MessageBox.Show("¡Bienvenido " + txtUsuario.Text + "!");
                    idUsuario = Convert.ToInt32(lblIdUser.Text);
                    Usuario = lblUsuario.Text;
                    Admin = Convert.ToInt32(lblAdmin.Text);
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("¡Bienvenido " + txtUsuario.Text + "!");
                    idUsuario = Convert.ToInt32(lblIdUser.Text);
                    Usuario = lblUsuario.Text;
                    Admin = Convert.ToInt32(lblAdmin.Text);
                    this.Hide();
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("¡Datos incorrectos!");
             
            }
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
