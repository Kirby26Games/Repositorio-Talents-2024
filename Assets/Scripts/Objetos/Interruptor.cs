using System.Collections.Generic;
using UnityEngine;

public class Interruptor : Objeto, IInteractuable
{
    public string Contrase�a;
    public string Contrase�aIntroducida;
    // Lista de objetos que implementan la interfaz IActivable
    [Header("Lista de Objetos Activables")]
    public IReferencia<IActivable>[] ObjetosActivables;
    public void AlInteractuar(GameObject objeto)
    {
        if(!ComprobarContrase�a())
        {
            return;
        }
        // Activar todos los objetos en la lista
        for (int i = 0; i < ObjetosActivables.Length; i++)
        {
            ObjetosActivables[i].I.AlActivar();
            print("Activo " + ObjetosActivables[i].gameObject.name);
        }
    }

    public bool ComprobarContrase�a()
    {
        return Contrase�a == Contrase�aIntroducida;
    }
}

