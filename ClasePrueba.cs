using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionV1
{
    /// <summary>
    /// Clase de prueba, cuyo objetivo es demostrar la utilización del espacio de nombres Reflection
    /// </summary>
    public class ClasePrueba
    {
        #region Atributos y Propiedades

        private int variableEntera;
        private string variableCadena;

        public int PropiedadEntero
        {
            get { return variableEntera; }
            set { variableEntera = value; }
        }

        public string PropiedadCadena
        {
            get { return variableCadena; }
            set { variableCadena = value; }
        }

        #endregion

        #region Constructores

        public ClasePrueba()
        {
            variableCadena = "";
            variableEntera = 0;
        }

        public ClasePrueba(int entero)
        {
            variableCadena = "";
            variableEntera = entero;
        }

        public ClasePrueba(string cadena)
        {
            variableCadena = cadena;
            variableEntera = 0;
        }

        public ClasePrueba(int entero, string cadena)
        {
            variableCadena = cadena;
            variableEntera = entero;
        }

        #endregion

        #region Funciones

        public int sumarUno(int dato)
        {
            PropiedadEntero = dato + 1;
            return PropiedadEntero;
        }

        public string insertarLetra(char caracter)
        {
            PropiedadCadena += caracter;
            return PropiedadCadena;
        }

        #endregion
    }
}
