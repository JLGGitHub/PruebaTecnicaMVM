using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoEvolutivo
{
    class Utils
    {
        /// <summary>
        /// Cadena de texto que contiene todas las letras del abecedario 
        /// </summary>
        public static readonly string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        /// <summary>
        /// Cadena final a la cual el algoritmo busca llegar
        /// </summary>
        public static readonly string cadenaObjetivo = "MVM INGENIERIA DE SOFTWARE";
        /// <summary>
        /// Longitud + 1 de la cantidad de caracteres en la cadena  MVM INGENIERIA DE SOFTWARE
        /// </summary>
        public static readonly int longitud = 27;
        /// <summary>
        /// Instancia de randon para generar letras aleatorias
        /// </summary>
        public static Random random = new Random();


        /// <summary>
        /// Metodo utilizado para imprimir el valor de cada iteración
        /// </summary>
        /// <param name="cadena">Cadena a imprimir en consola</param>
        public static void Imprimir(string cadena)
        {
            Console.WriteLine(cadena);
        }

        /// <summary>
        /// Metodo que genera la probabilidad de cambio de una letra
        /// </summary>
        /// <returns>Retornaa booleano </returns>
        public static bool generarProbabilidad()
        {
            return (random.Next(0, 99) < 3) ? true : false;
        }
    }
}
