using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;
namespace UnitTestEntidades
{
    [TestClass]
    public class UnitTestNulos
    {
        [TestMethod]
        public void TestNulo()
        {
            Alumno a3 = new Alumno(3, "pocho", "pantera", "123", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

            Assert.AreEqual(123, a3.Dni);
            Assert.AreEqual(Persona.ENacionalidad.Argentino, a3.Nacionalidad);

            Instructor I1 = new Instructor(4, "juan", "instructor", "90000000", Persona.ENacionalidad.Extranjero);
            Assert.IsNotNull(I1);
            Assert.AreEqual(Persona.ENacionalidad.Extranjero, I1.Nacionalidad);
            Assert.AreEqual(90000000, I1.Dni);

            Gimnasio gim = new Gimnasio();

            gim += a3;
            Assert.IsTrue(gim == a3);
            Assert.AreEqual(a3, gim.Alumnos[0]);
            Assert.IsNotNull(gim.Alumnos);
            //devuelve un Exception de tipo AlumnoRepetidoException
            try
            {
                gim += a3;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

            //Devuelve una Exception de tipo ArgumentOutOfRangeException porque
            //no se agrego al alumno
            try
            {
                Alumno a6 = gim.Alumnos[1];
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }



            gim += I1;
            Assert.AreEqual(I1, gim.Instructores[0]);
            Assert.IsTrue(gim == I1);
            //Devuelve una Exception de tipo ArgumentOutOfRangeException porque
            //no se agrego al Instructor
            try
            {
                gim += I1;
                Instructor I2 = gim.Instructores[1];
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }

            Jornada j1 = new Jornada(Gimnasio.EClases.Pilates, I1);
            j1 += a3;
            Assert.IsTrue(j1 == a3);

            Assert.IsTrue(Gimnasio.Guardar(gim));


            
        }
    }
}
