using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionV1
{
    /// <summary>
    /// Ver: https://goo.gl/Jxss9c
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            ListarMiembrosDeUnaClase();
            ListarUnMiembroEspecificoDeUnaClase();
            EjecutarMetodoConParametro();        
        }

        /// <summary>
        /// Ejecutamos un método mediante Reflection.
        /// </summary>
        private static void EjecutarMetodoConParametro()
        {
            ClasePrueba objClasePrueba = new ClasePrueba();
            Type tipoObjeto = objClasePrueba.GetType();

            // Obtenemos una referencia al método.
            MethodInfo Metodo = tipoObjeto.GetMethod("sumarUno");
            int dato;
            object[] parametros = new object[1] { 2 };

            // A continuación, llamamos al método Invoke del tipo, pasándole como primer parámetro
            // el objeto cuyo método queremos ejecutar y como segundo parámetro, un array de objetos con
            // los parámetros que espera el método o función.
            dato = (int)Metodo.Invoke(objClasePrueba, parametros);
            Console.WriteLine("El resultado de la invocación ha sido: " + dato.ToString());

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadLine();

            // Otra forma de invocar un método mediante Reflection: utilizando Activator
            // Utilizamos la clase Activator para ejecutar el método de otro objeto
            object objeto2 = Activator.CreateInstance(tipoObjeto);
            dato = (int)tipoObjeto.InvokeMember("sumarUno", BindingFlags.InvokeMethod, null, objeto2, parametros);
            Console.WriteLine("El resultado de la invocación (mediante Activator) ha sido: " + dato.ToString());

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadLine();
        }

        private static void ListarMiembrosDeUnaClase()
        {
            // "Reflexionando" ;)

            // Instanciamos el objeto
            ClasePrueba objClasePrueba = new ClasePrueba();

            // Obtenemos su tipo
            Type tipoObjeto = objClasePrueba.GetType();


            // "Exprimimos" el contenido de nuestro tipo...

            // Obtenemos información sobre miembros, constructores y métodos
            ConstructorInfo[] Constructores = tipoObjeto.GetConstructors();
            MemberInfo[] Miembros = tipoObjeto.GetMembers();
            PropertyInfo[] Propiedades = tipoObjeto.GetProperties();
            MethodInfo[] Metodos = tipoObjeto.GetMethods();

            // Presentamos en pantalla la información...
            Console.WriteLine("\n\nListar todos los miembros de una clase");

            Console.WriteLine("\n\nConstructores:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (ConstructorInfo info in Constructores)
                Console.WriteLine(info.ToString());

            Console.WriteLine("\n\nMiembros:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (MemberInfo info in Miembros)
                Console.WriteLine(info.ToString());

            Console.WriteLine("\n\nPropiedades:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (PropertyInfo info in Propiedades)
                Console.WriteLine(info.ToString());

            Console.WriteLine("\n\nMetodos:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (MethodInfo info in Metodos)
                Console.WriteLine(info.ToString());

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadLine();
        }

        private static void ListarUnMiembroEspecificoDeUnaClase()
        {
            ClasePrueba objClasePrueba = new ClasePrueba();

            Dictionary<string, object> propiedades = Helper.ObtenerElementosLinq(objClasePrueba, MemberTypes.Property);
            Dictionary<string, object> metodos = Helper.ObtenerElementosLinq(objClasePrueba, MemberTypes.Method);

            // Presentamos en pantalla la información...
            Console.WriteLine("\n\nListar un miembro específico de una clase");

            Console.WriteLine("\n\nPropiedades extraídas mediante Linq:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (var info in propiedades)
            {
                Console.WriteLine(info.ToString());
            }

            Console.WriteLine("\n\nMétodos extraídos mediante Linq:");
            Console.WriteLine("-------------------------------------------------------------\n");
            foreach (var info in metodos)
            {
                Console.WriteLine(info.ToString());
            }

            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadLine();
        }
    }
}