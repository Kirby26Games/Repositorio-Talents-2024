
using UnityEngine;

public class Celula : Movible
{

    public void InsertarCelula(Transform slot)
    {
        Objetivo = slot;
        transform.parent = slot;
        transform.localPosition = Vector3.zero;
        _RigidBody.angularVelocity = Vector3.zero;
        _RigidBody.useGravity = false;
    }

    public void SacarCelula(Transform personaje)
    {
        // Objetivo = personaje;
        transform.parent = null;
        _RigidBody.useGravity = true;
    }
}
