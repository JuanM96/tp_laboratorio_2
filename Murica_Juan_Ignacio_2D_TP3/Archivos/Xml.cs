using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> :IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextWriter archivoXml = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(archivoXml, datos);
                }
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextReader archivoXml = new XmlTextReader(archivo))
                {
                    XmlSerializer deserializador = new XmlSerializer(typeof(T));
                    datos = (T)deserializador.Deserialize(archivoXml);
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
