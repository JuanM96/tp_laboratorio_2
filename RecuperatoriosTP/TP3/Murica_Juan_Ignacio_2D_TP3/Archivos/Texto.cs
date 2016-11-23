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
            if (File.Exists(archivo))
            {
                try
                {
                    using (StreamWriter sArchivo = new StreamWriter(archivo, true))
                    {
                        sArchivo.WriteLine(datos.ToString());
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sArchivo = new StreamWriter(archivo))
                    {
                        sArchivo.WriteLine(datos.ToString());
                    }
                    return true;

                }
                catch (Exception e)
                {

                    throw e;
                }
            }
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
                throw e;
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
