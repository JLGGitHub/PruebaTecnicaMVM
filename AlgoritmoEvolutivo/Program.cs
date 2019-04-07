using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoEvolutivo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Genera instancia de la clase Manager
            Manager manager = Manager.GetInstancia(); 

            // Genera cadena inicial
            manager.cadenaInicial = manager.GenerarCadenaInicial();
            Utils.Imprimir("La cadena inicial es: " + manager.cadenaInicial);

            
            manager.Recursividad(manager.cadenaInicial);
            Utils.Imprimir("La ejecucion del algoritmo a finalizado...");


            Console.ReadLine();
        }
    }
}
