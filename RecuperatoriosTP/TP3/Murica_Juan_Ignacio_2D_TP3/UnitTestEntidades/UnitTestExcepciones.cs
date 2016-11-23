using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
namespace UnitTestEntidades
{
    [TestClass]
    public class UnitTestExcepciones
    {
        [TestMethod]
        public void ComprobarExcepciones()
        {
            Alumno a1;

            try
            {
                a1 = new Alumno(1, "Juan", "Murcia", "1234qw", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));

            }


            try
            {
                Alumno a2 = new Alumno(2, "pepo", "alvarez", "123", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Pilates);

            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            
            
        }
    }
}
