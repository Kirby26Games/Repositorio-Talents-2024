using System.Collections.Generic;
using UnityEngine;

public class Interruptor : Objeto, IInteractuable
{
    public string Contraseña;
    public string ContraseñaIntroducida;
    // Lista de objetos que implementan la interfaz IActivable
    [Header("Lista de Objetos Activables")]
    public IReferencia<IActivable>[] ObjetosActivables;
    public void AlInteractuar(GameObject objeto)
    {
        if(!ComprobarContraseña())
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

    public bool ComprobarContraseña()
    {
        return Contraseña == ContraseñaIntroducida;
    }
}

