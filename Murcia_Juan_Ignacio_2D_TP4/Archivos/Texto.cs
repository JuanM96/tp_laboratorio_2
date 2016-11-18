using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter archivoTxT = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"//"+this._archivo))
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

        public bool leer(out List<string> datos)
        {
            bool flag = false;
            List<string> outaux = new List<string>();
            try
            {
                using (StreamReader archivoTxT = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"//"+ this._archivo))
                {
                    while (!archivoTxT.EndOfStream)
                    {
                        outaux.Add(archivoTxT.ReadLine());
                    }
                    datos = outaux;
                }
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
        }
    }
}
