using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto :IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter archivoTxT = new StreamWriter(archivo))
                {

                    archivoTxT.WriteLine(datos);
                }
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool flag = false;
            try
            {
                using (StreamReader archivoTxT = new StreamReader(archivo))
                {
                    datos = archivoTxT.ReadToEnd();
                }
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
        }
        //public bool Guardar(string archivo, string datos)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Leer(string archivo, out string datos)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
