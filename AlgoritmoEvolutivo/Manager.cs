using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoEvolutivo
{
    class Manager
    {
        /// <summary>
        /// Instancia de la clase para utilizar patron singleton 
        /// </summary>
        private static Manager instancia = null;

        /// <summary>
        /// Vector de las cadenas generadas por cada iteracion recursiva
        /// </summary>
        public List<EstructuraCadenas> cadenasGeneradas;
        /// <summary>
        /// Cadena aleatoria, generada al inicial el algoritmo y reutilizada en cada ciclo  
        /// </summary>
        public string cadenaInicial { get; set; }
        /// <summary>
        /// Indica la cadena generada de mayor afinidad con la cadena "MVM INGENIERIA DE SOFTWARE"
        /// </summary>
        public int puntajeMayor { get; set; }
        /// <summary>
        /// Indica la generacion (iteracion) actual
        /// </summary>
        public int generacion { get; set; }

        public Manager()
        {

        }

        /// <summary>
        /// Metodo que genera una unica instancia de la clase Manager utilizando patron singleton
        /// </summary>
        /// <returns>Instancia de Manager</returns>
        public static Manager GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Manager(); 
            }
            return instancia; 
        }

        /// <summary>
        /// Metodo que genera la cadena inicial 
        /// </summary>
        /// <returns>Cadena de texto</returns>
        public string GenerarCadenaInicial()
        {
            StringBuilder cadena = new StringBuilder();

            for (int i = 0; i < Utils.longitud - 1; i++)
            {
                int indice = Utils.random.Next(0, Utils.longitud);
                cadena.Append(Utils.letras[indice]);
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Metodo que itera a partir de una cadena inicial y de forma recursiva.
        /// </summary>
        /// <param name="cadenaInicial">Cadena inicial con la que inicia el algoritmo</param>
        public void Recursividad(string cadenaInicial)
        {
            cadenasGeneradas = new List<EstructuraCadenas>();
            for (int i = 0; i < 50; i++)
            {
                StringBuilder nuevaCadena = new StringBuilder();
                EstructuraCadenas estructura = new EstructuraCadenas();
                int contador = 0;
                var cadenaAuxiliarChar = cadenaInicial.ToCharArray();

                for (int j = 0; j < Utils.longitud - 1; j++)
                {
                    if (Utils.generarProbabilidad())
                    {
                        int indice = Utils.random.Next(0, Utils.longitud);
                        nuevaCadena.Append(Utils.letras[indice]);
                    }
                    else
                    {
                        nuevaCadena.Append(cadenaAuxiliarChar[j]);
                    }

                    if (Utils.cadenaObjetivo[j].Equals(nuevaCadena[j]))
                    {
                        contador++;
                    }
                }
                estructura.puntaje = contador;
                estructura.cadena = nuevaCadena.ToString();
                cadenasGeneradas.Add(estructura);
                if (contador > puntajeMayor)
                {
                    puntajeMayor = contador;
                }
            }
            var x = cadenasGeneradas.Select(u => u).Where(q => q.puntaje == puntajeMayor).ToArray();
            generacion++;
            Utils.Imprimir("Generacion: " + generacion.ToString() + " --- " + x[0].cadena + "--" + "Puntaje: " + x[0].puntaje);
            if (x[0].puntaje != 26)
            {
                Recursividad(x[0].cadena);
            }
        }
    }

    /// <summary>
    /// Estructura de una cadena generada
    /// </summary>
    public class EstructuraCadenas
    {
        public int puntaje { get; set; }
        public string cadena { get; set; }
    }
}
