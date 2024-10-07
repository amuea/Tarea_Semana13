using System;
using System.Collections.Generic;
using System.Linq;

class Arbol
{
    static void Main(string[] args)
    {
        List<string> catalogo = new List<string>();
        Busqueda busqueda = new Busqueda();
        
        // Ingresar 10 títulos al catálogo
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Ingrese el título de la revista {i}: ");
            catalogo.Add(Console.ReadLine());
        }

        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Buscar título con búsqueda iterativa");
            Console.WriteLine("2. Buscar título con búsqueda recursiva");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion = int.Parse(Console.ReadLine());
            
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloIterativo = Console.ReadLine();
                    bool encontradoIterativa = busqueda.BuscarIterativa(catalogo, tituloIterativo);
                    Console.WriteLine(encontradoIterativa ? "Título encontrado" : "Título no encontrado");
                    break;
                    
                case 2:
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloRecursivo = Console.ReadLine();
                    bool encontradoRecursiva = busqueda.BuscarRecursiva(catalogo, tituloRecursivo);
                    Console.WriteLine(encontradoRecursiva ? "Título encontrado" : "Título no encontrado");
                    break;
                    
                case 3:
                    salir = true;
                    break;
                    
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
}


public class Busqueda
{
    // Método para realizar una búsqueda iterativa
    public bool BuscarIterativa(List<string> catalogo, string tituloBuscado)
    {
        foreach (string titulo in catalogo)
        {
            if (titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si el título es encontrado
            }
        }
        return false; // Si no se encuentra el título
    }

    // Método para realizar una búsqueda recursiva
    public bool BuscarRecursiva(List<string> catalogo, string tituloBuscado, int index = 0)
    {
        if (index >= catalogo.Count) return false; // Si se llega al final sin encontrar
        if (catalogo[index].Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase)) return true; // Si se encuentra el título
        return BuscarRecursiva(catalogo, tituloBuscado, index + 1); // Llamada recursiva al siguiente índice
    }
}
