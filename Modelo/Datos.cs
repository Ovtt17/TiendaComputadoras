using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda.Modelo
{
    internal class Datos
    {
        //creamos la lista de tipo Computador
        List<Computador> lista = new List<Computador>();
        //creamos un metodo para guardar los datos en la lista
        //pasando de parametro un objeto de tipo Computador
        public void Guardar(Computador computador)
        {
            //agregacion de objeto a la lista
            lista.Add(computador);
            MessageBox.Show("DATOS GUARDADOS CON EXITO");
        }

        //metodo de retorno de la lista
        public List<Computador> Consultar()
        {
            return lista;
        }
        public void Remover()
        {
            //limpia o elimina los datos de la lista
            lista.Clear();
            MessageBox.Show("SE HAN BORRADO TODOS LOS DATOS GUARDADOS");
        }
    }
}
