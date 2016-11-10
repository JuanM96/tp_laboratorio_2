using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
namespace UnitTestEntidades
{
    [TestClass]
    public class UnitTestNulos
    {
        [TestMethod]
        public void TestNulo()
        {
            //Verfico que las listas no sean nulas en gimnasio
            Gimnasio g1 = new Gimnasio();
            Assert.IsNotNull(g1.Alumnos);
            Assert.IsNotNull(g1.Jornadas);
            Assert.IsNotNull(g1.Instructores);
        }
    }
}
