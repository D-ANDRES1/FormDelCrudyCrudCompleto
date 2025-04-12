using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDelCrud;

namespace FormDelCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbSeccion.Items.Add("A");
            cmbSeccion.Items.Add("B");

            cmbSeccion.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Crud crud = new Crud();

                string carnet = txtCarnet.Text;
                string estudiante = txtNombre.Text;
                string email = txtEmail.Text;
                char seccion = cmbSeccion.SelectedItem.ToString()[0];

                if (string.IsNullOrWhiteSpace(carnet) ||
                    string.IsNullOrWhiteSpace(estudiante) ||
                    string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Por favor llena todos los campos.");
                    return;
                }

                crud.InsertarTablaAlumnos(carnet, estudiante, email, seccion);

                dgvAlumnos.DataSource = crud.ObtenerAlumnos();

                MessageBox.Show("Alumno insertado correctamente.");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void textBoxCarnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Crud crud = new Crud();

            // Llamar al método ObtenerAlumnos() y asignar el resultado al DataGridView
            dgvAlumnos.DataSource = crud.ObtenerAlumnos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
