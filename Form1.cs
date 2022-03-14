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
    public partial class Form1 : Form
    {
        List<Auto> autos = new List<Auto>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();
            auto.Placa = placa.Text;
            auto.Marca = marca.Text;
            auto.Modelo = Convert.ToInt16(modelo.Text);
            auto.Color = color.Text;
            auto.Precio = Convert.ToDecimal(preciok.Text);

            int posicion = autos.FindIndex(x => x.Placa == placa.Text);  
            if (posicion == -1)
            {
                autos.Add(auto);
                guardarauto(); 
            }
            else
            {
                MessageBox.Show("El vehiculo Ya Ha sido registrado anteriormente");
            }
            autos.Add(auto);

            DatosAlquiler frm1 = new DatosAlquiler(); 
            frm1.Show();
        }
        private void guardarauto()
        {
            FileStream stream = new FileStream("Autos.txt", FileMode.OpenOrCreate, FileAccess.Write);            
            StreamWriter writer = new StreamWriter(stream);            
            foreach (var auto in autos)
            {
                writer.WriteLine(auto.Placa);
                writer.WriteLine(auto.Marca);
                writer.WriteLine(auto.Modelo);
                writer.WriteLine(auto.Color);
                writer.WriteLine(auto.Precio);
            }                        
            writer.Close();
        }
    }
}
