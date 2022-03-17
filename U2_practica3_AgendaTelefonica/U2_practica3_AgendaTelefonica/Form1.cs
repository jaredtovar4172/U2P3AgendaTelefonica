using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace U2_practica3_AgendaTelefonica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            txtApellido.Visible = true;
            txtCorreo.Visible = true;
            txtDireccion.Visible = true;
            txtNombre.Visible = true;
            txtNumero.Visible = true;
            btnGuardar.Visible = true;
            btnFoto.Visible = true;
            btnLimpiar.Visible = true;
            pictureBox1.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            txtApellido.Visible = false;
            txtCorreo.Visible = false;
            txtDireccion.Visible = false;
            txtNombre.Visible = false;
            txtNumero.Visible = false;
            btnGuardar.Visible = false;
            btnFoto.Visible = false;
            btnLimpiar.Visible = false;
            pictureBox1.Visible = false;
            txtBuscador.AutoCompleteCustomSource = CargarDatos();
            txtBuscador.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscador.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private AutoCompleteStringCollection CargarDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            datos.Add("Jared Israel Tovar Covarrubias");
            datos.Add("Juan Fernando Barba Barrientos");
            return datos;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open("C:\\Users\\jared\\OneDrive\\Escritorio\\Agenda.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            Excel.Range userRange = x.UsedRange;
            int countRecords = userRange.Rows.Count;
            int add = countRecords + 1;
            x.Cells[1, 2] = txtNombre.Text;
            x.Cells[2, 2] = txtApellido.Text;
            x.Cells[3, 2] = txtDireccion.Text;
            x.Cells[4, 2] = txtNumero.Text;
            x.Cells[5, 2] = txtCorreo.Text;
            x.Cells[6, 2] = pictureBox1.ImageLocation;
            sheet.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
            MessageBox.Show("Datos guardados correctamente");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            txtNumero.Clear();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.InitialDirectory = "C:\\Users\\jared\\Escritorio";
            foto.Title = "Sin titulo";
            foto.Filter = "Archivo de imagen|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
            if (foto.ShowDialog() == DialogResult.OK)
            {
                string ruta = foto.FileName;
                string[] a = ruta.Split('.');
                int b = a.Length;
                string tipo = a[b - 1];
                if (tipo == "jpg" || tipo == "png" || tipo == "png" || tipo == "gif" || tipo == "jpeg" || tipo == "bmp")
                {
                    pictureBox1.ImageLocation = foto.FileName;
                }
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "Jared Israel Tovar Covarrubias")
            {
                Datos frm = new Datos();
                frm.Show();
            }
        }
    }
}
