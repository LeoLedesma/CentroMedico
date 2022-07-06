using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using Entidades.Extension_Class;

namespace TestCentroMedico
{
    [TestClass]
    public class TestCentroMedico
    {
        [TestMethod]
        public void EliminarPaciente_CuandoNoExisteEnLaListaDePacientes_DeberiaRetornarFalse()
        {
            // Arrange
            CentroMedico centroMedico = CentroMedico.Instanciar("centro");
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10), 
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");
            centroMedico.AgregarPersona(paciente);
            Paciente paciente2 = new Paciente("Juan", "Perez", new System.DateTime(1960, 10, 05), 
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "18458969", "458599*/", "", "", "");

            bool result;            
            //act
            result = centroMedico.RemoverPersona(paciente2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IgualarPacientes_CuandoLosDosTienenElMismoDocumento_DeberiaRetornarTrue()
        {
            //Arrange
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");            
            Paciente paciente2 = new Paciente("Juan", "Perez", new System.DateTime(1960, 10, 05),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "458599*/", "", "", "");

            bool result;

            //act
            result = paciente == paciente2;

            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CastearIntGenero_CuandoEsMasculino_DeberiaRetornar0()
        {
            //Arrange
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");

            int expected = 1;
            int result;

            //act
            result = (int)paciente.Genero;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EliminarCoincidencias_CuandoHayCoincidencias_DeberiaRetornarListaSinCoincidencias()
        {
            //Arrange
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");
            Paciente paciente2 = new Paciente("Juan", "Ledesma", new System.DateTime(2000, 02, 10),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "45585858", "1145858574", "", "", "");
            List<Persona> lista = new List<Persona>();
            lista.Add(paciente);
            lista.Add(paciente2);
            List<Persona> lista2 = new List<Persona>();
            lista2.Add(paciente);

            int expected = 1;
            int result;

            //act
            result = lista.EliminarCoincidencias(lista2).Count;

            //Assert
            Assert.AreEqual(expected, result);
        }

    }

    
        
}
