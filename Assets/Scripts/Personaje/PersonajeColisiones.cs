using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColisiones : MonoBehaviour
{
    public float RangoDeteccion;
    public GameObject Trigger;

    void Awake() {
      if (Trigger != null) {
        Trigger.transform.localScale = Vector3.one * RangoDeteccion;
      }
    }

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
        if (objetoTocado.gameObject.TryGetComponent(out ITriggereableSalir colisionable))
        {
            colisionable.AlTriggerearSalir(objetoTocado, gameObject);
        }
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
