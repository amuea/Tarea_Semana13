using System.Security.Cryptography.X509Certificates;

public static class Arbol{

    /// <summary>
    /// Definición de un nodo
    /// </summary>
    public class Node{
        public int Value;
        public Node? left;
        public Node? right;

        /// <summary>
        /// Constructor de un nodo
        /// </summary>
        /// <param name="valor">Requiere un valor entero</param>
        public Node(int valor){
            Value = valor;
            left = null;
            right = null;
        }
    }

    public class ArbolBinario{
        public Node? Raiz;

        public void insertar(int nuevoValor){
            // Si la raiz es nula, inserto el nuevo valor
            if (Raiz == null)
            {
                Raiz = new Node(nuevoValor);
            } else{
                // si la raíz no es nula llamo a una función recurrente
                insertarRecurrente(Raiz, nuevoValor);
            } 
        }

        private void insertarRecurrente(Node nodo, int valor){
            // Si el valor es menor que el valor de la raiz, vamos por la izq
            if(valor<nodo.Value){
                // si el nodo es nulo lo creamos
                if(nodo.left == null){
                    nodo.left = new Node(valor);
                } else{
                    insertarRecurrente(nodo.left, valor);
                }
            } else{
                if(nodo.right == null){
                    nodo.right = new Node(valor);
                } else{
                    insertarRecurrente(nodo.right, valor);
                }
            }
        }

    }
    public static void Run(){
        
    }
}