using UnityEngine;

// Clase para cualquier objeto que se pueda mirar. Aqu� a�adiremos propiedades y m�todos como RESALTAR o PINTAR
public abstract class Mirable : MonoBehaviour
{
    public bool EsTransparente;                // Se pueden interactuar con objetos detr�s de este
}
// Clase para cualquier objeto con el que se pueda interactuar. Hereda de Mirable. Aqu� a�adiremos propiedades y m�todos como AGARRAR o INVESTIGAR
public abstract class Interactuable : Mirable
{
    public bool EsInteractuable;               // Si es actualmente interactuable o no
    public bool AtraviesaTransparentes;        // Se puede interactuar si se interponen IMirables transparentes
    public string Nombre;                      // Nombre referencia, por ejemplo gameObject.name
    public abstract void Interaccion();        // M�todo que define qu� es lo que hace un objeto cuando interactuamos con �l
}
