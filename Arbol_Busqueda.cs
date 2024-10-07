using System;
using System.Collections.Generic;

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