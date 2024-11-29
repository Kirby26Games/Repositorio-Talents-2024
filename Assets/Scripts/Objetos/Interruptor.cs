using System.Collections.Generic;
using UnityEngine;

public class Interruptor : Objeto, IInteractuable
{

    // Lista de objetos que implementan la interfaz IActivable
    [Header("Lista de Objetos Activables")]
    [SerializeField] public IReferencia<IActivable>[] ObjetosActivables; 

    public void AlInteractuar()
    {
        // Activar todos los objetos en la lista
        for (int i = 0; i < ObjetosActivables.Length; i++)
        {

            ObjetosActivables[i].I.AlActivar();
            print("Activo " + ObjetosActivables[i].gameObject.name);
        }
    }

}

