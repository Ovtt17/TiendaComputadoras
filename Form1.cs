using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.Modelo;

namespace Tienda
{
    public partial class Form1 : Form
    {
        //creamos una tabla
        DataTable tabla;
        //creacion de instancia de Datos
        Datos dato = new Datos();
        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }
        //evento para guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //guardamos los datos
            Guardar();
            //mostramos en pantalla los datos ingresados
            Consulta();
            //limpiamos los campos que se llenaron de informacion
            Limpiar();
        }
        //evento para ver datos guardados
        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            //limpiamos la tabla
            LimpiarTabla();
            //mostramos en pantalla los datos ingresados
            Consulta();
        }

        //evento para limpiar los datos que se introdujeron en los combobox y textbox
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //evento para limpiar u ocultar datos de la tabla
        private void btnLimpiarTabla_Click(object sender, EventArgs e)
        {
            LimpiarTabla();
        }
        //evento para eliminar los datos de la tabla (lista)
        private void btnEliminarDatosTabla_Click(object sender, EventArgs e)
        {
            dato.Remover();
            LimpiarTabla();
        }
        private void Iniciar ()
        {
            //inicializacion de tabla
            tabla = new DataTable();
            //agregacion de columnas a la tabla
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Memoria RAM");
            tabla.Columns.Add("Procesador");
            tabla.Columns.Add("Estado");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Arquitectura");
            tabla.Columns.Add("Memoria Expandible");
            // se asigna la tabla "tabla" como origen de datos al control gráfico
            grilla.DataSource = tabla;
        }

        private void Guardar()
        {
            //convertimos las opciones seleccionadas a string
            string marcaSeleccionada = cmbMarca.SelectedItem.ToString();
            string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
            string arquitecturaSeleccionada = cmbArquitectura.SelectedItem.ToString();
            string memoriaExpandibleSeleccionada = cmbMemoriaExpandible.SelectedItem.ToString();

            //asignamos valores a la instancia de computador
            Computador computador = new Computador()
            {
                Marca = marcaSeleccionada,
                MemoriaRam = int.Parse(txtRAM.Text),
                Procesador = txtProcesador.Text,
                Estado = estadoSeleccionado,
                Precio = double.Parse(txtPrecio.Text),
                Arquitectura = arquitecturaSeleccionada,
                MemoriaExpandible = memoriaExpandibleSeleccionada
            };
            //mandamos los datos a la lista
            dato.Guardar(computador);
            
        }
        
        private void Limpiar()
        {
            cmbMarca.SelectedIndex = -1;
            txtRAM.Text = "";
            txtProcesador.Text = "";
            cmbEstado.SelectedIndex = -1;
            txtPrecio.Text = "";
            cmbArquitectura.SelectedIndex = -1;
            cmbMemoriaExpandible.SelectedIndex = -1;
        }

        private void Consulta()
        {
            foreach (var computador in dato.Consultar())
            {
                //creamos una nueva fila en la tabla
                DataRow fila = tabla.NewRow();
                fila["Marca"] = computador.Marca;
                fila["Memoria RAM"] = computador.MemoriaRam;
                fila["Procesador"] = computador.Procesador;
                fila["Estado"] = computador.Estado;
                fila["Precio"] = computador.Precio;
                fila["Arquitectura"] = computador.Arquitectura;
                fila["Memoria Expandible"] = computador.MemoriaExpandible;
                //agregamos los datos a la tabla
                tabla.Rows.Add(fila);

                //en caso de utilizar MessageBox
                //MessageBox.Show($"Marca: {computador.Marca}\n" +
                //            $"Memoria RAM: {computador.MemoriaRam}\n" +
                //            $"Procesador: {computador.Procesador}\n" +
                //            $"Estado: {computador.Estado}\n" +
                //            $"Precio: {computador.Precio}\n" +
                //            $"Arquitectura: {computador.Arquitectura}\n" +
                //            $"Memoria Expandible: {computador.MemoriaExpandible}");
            }

        }
        private void LimpiarTabla ()
        {
            tabla.Rows.Clear(); // Elimina todas las filas en el DataGridView

        }
    }
}
