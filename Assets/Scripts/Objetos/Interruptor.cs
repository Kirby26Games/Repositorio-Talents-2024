using System.Collections.Generic;
using UnityEngine;

public class Interruptor : Objeto, IInteractuable
{

    // Lista de objetos que implementan la interfaz IActivable
    [Header("Lista de Objetos Activables")]
    public IReferencia<IActivable>[] ObjetosActivables;
        public void AlInteractuar(GameObject objeto)
    {
        // Activar todos los objetos en la lista
        for (int i = 0; i < ObjetosActivables.Length; i++)
        {

            ObjetosActivables[i].I.AlActivar();
            print("Activo " + ObjetosActivables[i].gameObject.name);
        }
    }

}

