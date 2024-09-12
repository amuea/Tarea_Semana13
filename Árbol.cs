using System;
using System.Collections.Generic;
using System.Linq;

class Arbol
{
    static void Main(){
        List<string> catalogo = new List<string>();
        IngresarTitulos(catalogo);
        MostrarMenu(catalogo);
    }

    static void IngresarTitulos(List<string> catalogo){
        Console.WriteLine("Ingrese 10 títulos de revistas:");

        for (int i = 0; i < 10; i++){
            Console.Write($"Título {i + 1}: ");
            string titulo = Console.ReadLine();
            catalogo.Add(titulo);
        }
    }

    static void MostrarMenu(List<string> catalogo){
        while (true){
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título (búsqueda iterativa)");
            Console.WriteLine("2. Buscar un título (búsqueda recursiva)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();

            switch (opcion){
                case "1":
                    BuscarTituloIterativo(catalogo);
                    break;
                case "2":
                    BuscarTituloRecursivo(catalogo);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void BuscarTituloIterativo(List<string> catalogo){
        Console.Write("Ingrese el título a buscar: ");
        string titulo = Console.ReadLine();
        
        if (catalogo.Contains(titulo)){
            Console.WriteLine("Título encontrado.");
        }
        else{
            Console.WriteLine("Título no encontrado.");
        }
    }

    static void BuscarTituloRecursivo(List<string> catalogo){
        Console.Write("Ingrese el título a buscar: ");
        string titulo = Console.ReadLine();
        
        bool encontrado = BuscarTituloRecursivoHelper(catalogo, titulo, 0);
        
        if (encontrado){
            Console.WriteLine("Título encontrado.");
        }
        else{
            Console.WriteLine("Título no encontrado.");
        }
    }

    static bool BuscarTituloRecursivoHelper(List<string> catalogo, string titulo, int index){
        if (index >= catalogo.Count){
            return false;
        }
        if (catalogo[index] == titulo){
            return true;
        }
        return BuscarTituloRecursivoHelper(catalogo, titulo, index + 1);
    }
}
