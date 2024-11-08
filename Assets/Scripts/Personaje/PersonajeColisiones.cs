using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColisiones : MonoBehaviour
{
    private void OnTriggerEnter(Collider objetoTocado)
    {
        //si toco un objeto ITriggereableEntrar, ejecuto AlTriggerearEntrar
        if (objetoTocado.gameObject.TryGetComponent(out ITriggereableEntrar colisionable))
        {
            colisionable.AlTriggerearEntrar(objetoTocado, gameObject);
        }
    }
    private void OnTriggerExit(Collider objetoTocado)
    {
        
    }

    private void OnCollisionEnter(Collision objetoTocado)
    {
        //si toco un objeto IColisionableEntrar, ejecuto AlColisionarEntrar
        if (objetoTocado.gameObject.TryGetComponent(out IColisionableEntrar colisionable))
        {
            colisionable.AlColisionarEntrar(objetoTocado.collider,gameObject);
        }
    }
    private void OnCollisionExit(Collision objetoTocado)
    {

    }
}
