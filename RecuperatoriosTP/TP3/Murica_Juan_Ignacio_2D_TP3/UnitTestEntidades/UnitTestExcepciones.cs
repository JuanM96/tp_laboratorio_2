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
        public void DNI_Invalido()
        {
            //Caso 1 Dni Mayor a 99999999 y string
            string dniTest = "100000000";
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Murcia", dniTest, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                Assert.Fail("Sin excepción para DNI inválido: " + dniTest);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
            
            
            //Caso 2 Dni Menor a 1 y string
            string dniTest2 = "-2";
            try
            {
                Alumno a2 = new Alumno(1, "Juan", "Murcia", dniTest2, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                Assert.Fail("Sin excepción para DNI inválido: " + dniTest2);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
            
            
            //Caso 3 Dni con letras
            string dniTest3 = "40asd0059700";
            try
            {
                Alumno a3 = new Alumno(1, "Juan", "Murcia", dniTest3, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
                Assert.Fail("Sin excepción para DNI inválido: " + dniTest3);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
            
            
        }
    }
}
