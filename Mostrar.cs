using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_6
{
    public partial class Mostrar : Form
    {
        List<Auto> autos = new List<Auto>();
        List<Cliente> clientes = new List<Cliente>();
        public Mostrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarautos();
            grid();
            cargarclientes();
            grid();
        }
        private void cargarclientes()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.Nit = reader.ReadLine();
                cliente.Nombre = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();
                cliente.Placa = reader.ReadLine();
                cliente.FechaAlquiler = reader.ReadLine();
                cliente.FechaDevolucion = reader.ReadLine();
                cliente.KilometrosRecorridos = Convert.ToDecimal(reader.ReadLine());

                clientes.Add(cliente);
            }
        }


        private void grid()
        {
            dataGridView1.DataSource = autos;
            dataGridView1.Refresh();
            dataGridView2.DataSource = clientes;
            dataGridView2.Refresh(); 
        }
        private void cargarautos()
        {
            FileStream stream = new FileStream("Autos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)           
            {
                Auto auto = new Auto();
                auto.Placa = reader.ReadLine();
                auto.Marca = reader.ReadLine();
                auto.Modelo = Convert.ToInt16 (reader.ReadLine());
                auto.Color = reader.ReadLine();
                auto.Precio = Convert.ToDecimal(reader.ReadLine());

                autos.Add(auto); 
            }
        }
    }
}
