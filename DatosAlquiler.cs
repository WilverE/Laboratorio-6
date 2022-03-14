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
    public partial class DatosAlquiler : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public DatosAlquiler()
        {
            InitializeComponent();
        }
        private void ingreso()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nit = nit.Text;
            cliente.Nombre = nombre.Text;
            cliente.Direccion = direccion.Text;
            cliente.Placa = placa.Text;
            DateTime hoy = DateTime.Now;
            cliente.FechaAlquiler = hoy.ToString();
            DateTime regreso = DateTime.Now;
            cliente.FechaDevolucion = regreso.ToString();
            cliente.KilometrosRecorridos = Convert.ToDecimal(KR.Text);

            int posicion = clientes.FindIndex(x => x.Nombre == nombre.Text);

            if (posicion == -1)
            {
                clientes.Add(cliente);
                guardarcliente();
                MessageBox.Show("La Persona Fue Registrada Existoamente");
            }
            else
            {
                MessageBox.Show("La persona ya fue reguistrada anteriormente");
            }
            clientes.Add(cliente);

            Mostrar frm2 = new Mostrar();
            frm2.Show();
            this.Close();//sirve para cerrar la ventana
        }
        
        private void guardarcliente()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var auto in clientes)
            {
                writer.WriteLine(auto.Nit);
                writer.WriteLine(auto.Nombre);
                writer.WriteLine(auto.Direccion);
                writer.WriteLine(auto.Placa);
                writer.WriteLine(auto.FechaAlquiler);
                writer.WriteLine(auto.FechaDevolucion);
                writer.WriteLine(auto.KilometrosRecorridos);
            }
            writer.Close();
        }
    }
}
