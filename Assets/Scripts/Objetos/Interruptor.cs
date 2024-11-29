using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour,IInteractuable
{

    // Lista de objetos que implementan la interfaz IActivable
    [Header("Lista de Objetos Activables")]
    public List<IActivable> ObjetosActivables;

    public void AlInteractuar()
    {
        // Activar todos los objetos en la lista
        foreach (IActivable activable in ObjetosActivables)
        {
            if (activable != null)
            {
                activable.AlActivar();
            }
        }
    }

}

