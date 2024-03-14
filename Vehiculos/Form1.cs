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
using System.Windows.Forms.VisualStyles;

namespace Vehiculos
{
    public partial class Form1 : Form
    {

        List<Clientes> clientes = new List<Clientes>();
        List<Alquileres> alquileres = new List<Alquileres>();   
        List<Datos> datos = new List<Datos>();
        List<Informacion> informacions = new List<Informacion>();
        public Form1()
        {
            InitializeComponent();
        }

        public void CargarClientes() {

            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while(reader.Peek() > -1)
            {
                Clientes cliente = new Clientes();
                cliente.Nit = Convert.ToInt16(reader.ReadLine());
                cliente.Nombre= reader.ReadLine();
                cliente.Direccion= reader.ReadLine();

                clientes.Add(cliente);
            }

            reader.Close();
        }

        public void CargarAlquileres() {

            string fileName = "Alquileres.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while(reader.Peek() > -1)
            {
                Alquileres alquiler = new Alquileres();
                alquiler.Nit = Convert.ToInt32(reader.ReadLine());
                alquiler.Placa = reader.ReadLine();
                alquiler.FechaDev = reader.ReadLine();
                alquiler.FechAlq = reader.ReadLine();
                alquiler.KilRecorridos=Convert.ToInt16(reader.ReadLine());

                alquileres.Add(alquiler);
            }

        }

        public void CargarDatos() {

            string fileName = "Datos.txt";
            FileStream stram = new FileStream(fileName,  FileMode.Open, FileAccess.Read);
            StreamReader reader= new StreamReader(stram);
            while (reader.Peek() >-1) { 

                Datos dato = new Datos();
                dato.Placa = reader.ReadLine();
                dato.Marca = reader.ReadLine();
                dato.Modelo = reader.ReadLine() ;
                dato.Color = reader.ReadLine();
                dato.PrecioKilo = Convert.ToInt16(reader.ReadLine());

                datos.Add(dato);
            }  
            reader.Close();
        
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            
            CargarDatos();
            CargarClientes();
            CargarAlquileres();
            mostrarClientes();
            mostrarVehiculos();
            datos.Clear();
            clientes.Clear();

        }

        private void Guardar(string fileName)
        {

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var dato in datos)
            {

                writer.WriteLine(dato.Placa);
                writer.WriteLine(dato.Modelo);
                writer.WriteLine(dato.Color);
                writer.WriteLine(dato.Marca);
                writer.WriteLine(dato.PrecioKilo);
            }
            writer.Close();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Datos nuevo = new Datos();
            nuevo.Placa = textPlaca.Text;
            nuevo.Modelo= textModelo.Text;
            nuevo.Color = textColor.Text;
            nuevo.Marca = textMarca.Text;
            nuevo.PrecioKilo = Convert.ToDecimal(textRecorrido.Text);
            datos.Add(nuevo);
            Guardar("Datos.txt");
            mostrarVehiculos();
        }

        public void mostrarVehiculos() {

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = datos;
            dataGridView2.Refresh();
        
        }

        public void mostrarClientes()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }

        public void mostrarInfo() {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = informacions;
            dataGridView3.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)

        {
           
            CargarClientes();
            CargarDatos();
            CargarAlquileres();
            if (informacions.Count == 0)
            {
                foreach (Alquileres alquiler in alquileres)
                {

                    Clientes cliente = clientes.FirstOrDefault(C => C.Nit == alquiler.Nit);
                    if (cliente != null)
                    {
                        Datos dato = datos.FirstOrDefault(V => V.Placa == alquiler.Placa);
                        if (dato != null)
                        {
                            Informacion informaciones = new Informacion();
                            informaciones.Nombre = cliente.Nombre;
                            informaciones.Placa = dato.Placa;
                            informaciones.Marca = dato.Marca;
                            informaciones.Modelo = dato.Modelo;
                            informaciones.Color = dato.Color;
                            informaciones.PrecioKilo = dato.PrecioKilo;
                            informaciones.FechaDev = alquiler.FechaDev;
                            informaciones.Total = (dato.PrecioKilo * alquiler.KilRecorridos);

                            informacions.Add(informaciones);
                        }
                    }
                }
                mostrarInfo();
            }
        }
    }
}
