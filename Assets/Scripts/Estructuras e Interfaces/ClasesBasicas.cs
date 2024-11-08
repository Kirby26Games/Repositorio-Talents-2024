using UnityEngine;

// Clase para cualquier objeto que se pueda mirar. Aquí añadiremos propiedades y métodos como RESALTAR o PINTAR
public abstract class Mirable : MonoBehaviour
{
    public bool EsTransparente;                // Se pueden interactuar con objetos detrás de este
}
// Clase para cualquier objeto con el que se pueda interactuar. Hereda de Mirable. Aquí añadiremos propiedades y métodos como AGARRAR o INVESTIGAR
public abstract class Interactuable : Mirable
{
    public bool EsInteractuable;               // Si es actualmente interactuable o no
    public bool AtraviesaTransparentes;        // Se puede interactuar si se interponen IMirables transparentes
    public string Nombre;                      // Nombre referencia, por ejemplo gameObject.name
    public abstract void Interaccion();        // Método que define qué es lo que hace un objeto cuando interactuamos con él
}
