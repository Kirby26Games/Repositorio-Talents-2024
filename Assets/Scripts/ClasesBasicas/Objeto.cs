using UnityEngine;
public abstract class Objeto : MonoBehaviour, IInteractuable
{
    public string Nombre;

    public abstract void AlInteractuar();
}