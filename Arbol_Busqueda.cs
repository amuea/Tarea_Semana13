using System;
using System.Collections.Generic;
using System.Linq;

class Revista
{
    public string Titulo;
    public Revista Izquierda;
    public Revista Derecha;

    public Revista(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

class CatalogoRevistas
{
    public Revista Raiz;

    public CatalogoRevistas()
    {
        Raiz = null;
    }

    // Método para agregar un título al árbol
    public void Agregar(string titulo)
    {
        Raiz = AgregarRecursivo(Raiz, titulo);
    }

    private Revista AgregarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Revista(titulo);
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierda = AgregarRecursivo(nodo.Izquierda, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecha = AgregarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;
    }

    // Búsqueda recursiva
    public bool BuscarRecursivo(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }

    private bool BuscarRecursivo(Revista nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        if (titulo == nodo.Titulo)
        {
            return true;
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, titulo);
        }
    }

    // Búsqueda iterativa
    public bool BuscarIterativo(string titulo)
    {
        Revista actual = Raiz;

        while (actual != null)
        {
            if (titulo == actual.Titulo)
            {
                return true;
            }

            if (string.Compare(titulo, actual.Titulo) < 0)
            {
                actual = actual.Izquierda;
            }
            else
            {
                actual = actual.Derecha;
            }
        }

        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Agregar 10 títulos de revistas
        catalogo.Agregar("National Geographic");
        catalogo.Agregar("Forbes");
        catalogo.Agregar("Time");
        catalogo.Agregar("The Economist");
        catalogo.Agregar("Popular Science");
        catalogo.Agregar("Nature");
        catalogo.Agregar("Scientific American");
        catalogo.Agregar("New Yorker");
        catalogo.Agregar("Wired");
        catalogo.Agregar("Vogue");

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar título (recursivo)");
            Console.WriteLine("2. Buscar título (iterativo)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 3) break;

            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = false;
            switch (opcion)
            {
                case 1:
                    encontrado = catalogo.BuscarRecursivo(titulo);
                    break;
                case 2:
                    encontrado = catalogo.BuscarIterativo(titulo);
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    continue;
            }

            if (encontrado)
            {
                Console.WriteLine("Resultado de la búsqueda: Encontrado.");
            }
            else
            {
                Console.WriteLine("Resultado de la búsqueda: No encontrado.");
            }
        }
    }
}
