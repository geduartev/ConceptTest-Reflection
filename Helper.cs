using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionV1
{
    static class Helper
    {
        /// <summary>
        /// Función encargada de devolver un tipo de elemento en concreto de un objeto en un conjunto de pares clave - valor.
        /// </summary>
        static public Dictionary<string, object> ObtenerElementosSinLinq(object objeto, MemberTypes TipoElemento)
        {
            try
            {
                Dictionary<string, object> Elementos = new Dictionary<string, object>();

                switch (TipoElemento)
                {
                    case MemberTypes.Constructor:
                        break;
                    case MemberTypes.Event:
                        break;
                    case MemberTypes.Field:
                        break;
                    case MemberTypes.Method:
                        // Se recorren los miembros del objeto
                        foreach (MemberInfo infoMiembro in objeto.GetType().GetMembers())
                        {
                            // Si el tipo del objeto es del tipo que buscamos, se añade al diccionario
                            if ((infoMiembro.MemberType == TipoElemento) && ((PropertyInfo)infoMiembro != null))
                            {
                                Elementos.Add(infoMiembro.Name, null);
                            }
                        }

                        break;
                    case MemberTypes.Property:
                        // Se recorren los miembros del objeto
                        foreach (MemberInfo infoMiembro in objeto.GetType().GetProperties())
                        {
                            // Si el tipo del objeto es del tipo que buscamos, se añade al diccionario
                            if ((infoMiembro.MemberType == TipoElemento) && ((PropertyInfo)infoMiembro != null))
                            {
                                Elementos.Add(((PropertyInfo)infoMiembro).Name, ((PropertyInfo)infoMiembro).GetValue(objeto, null));
                            }
                        }

                        break;
                    case MemberTypes.TypeInfo:
                        break;
                    case MemberTypes.Custom:
                        break;
                    case MemberTypes.NestedType:
                        break;
                    case MemberTypes.All:
                        break;
                    default:
                        break;
                }

                return Elementos;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        static public Dictionary<string, object> ObtenerElementosLinq(object objeto, MemberTypes TipoElemento)
        {
            try
            {
                Dictionary<string, object> Elementos = new Dictionary<string, object>();

                switch (TipoElemento)   
                {
                    case MemberTypes.Constructor:
                        break;
                    case MemberTypes.Event:
                        break;
                    case MemberTypes.Field:
                        break;
                    case MemberTypes.Method:
                        var consulta = from i in objeto.GetType().GetMembers()
                                       where ((i.MemberType == TipoElemento) && (i != null))
                                       select new KeyValuePair<string, object>(i.Name, null);

                        foreach (KeyValuePair<string, object> kvp in consulta)
                            Elementos.Add(kvp.Key, kvp.Value);

                        break;
                    case MemberTypes.Property:
                        var consulta2 = from i in objeto.GetType().GetProperties()
                                       where ((i.MemberType == TipoElemento) && (i != null))
                                       select new KeyValuePair<string, object>(
                                           ((PropertyInfo)i).Name,
                                           ((PropertyInfo)i).GetValue(objeto, null));

                        foreach (KeyValuePair<string, object> kvp in consulta2)
                            Elementos.Add(kvp.Key, kvp.Value);

                        break;
                    case MemberTypes.TypeInfo:
                        break;
                    case MemberTypes.Custom:
                        break;
                    case MemberTypes.NestedType:
                        break;
                    case MemberTypes.All:
                        break;
                    default:
                        break;
                }

                return Elementos;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}