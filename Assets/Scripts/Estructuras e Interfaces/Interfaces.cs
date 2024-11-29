using System;
using UnityEngine;

public interface IMirable
{
    public void AlMirar();
    public void AlDejarDeMirar();
}

public interface IInteractuable
{

    public void AlInteractuar();
}

public interface IActivable
{
    public void AlActivar();
}

public interface IColisionableEntrar
{
    public void AlColisionarEntrar(Collider colision, GameObject objeto);

}

public interface IColisionableSalir
{
    public void AlColisionarSalir(Collider colision, GameObject objeto);

}
public interface ITriggereableEntrar
{
    public void AlTriggerearEntrar(Collider colision,GameObject objeto);

}
public interface ITriggereableSalir
{
    public void AlTriggerearEntrar(Collider colision, GameObject objeto);

}


//NO TOCAR

[Serializable]
public class IReferencia<T> : ISerializationCallbackReceiver where T : class
{
    public UnityEngine.Object objetivo;
    public T I { get => objetivo as T; }
   [HideInInspector] public GameObject gameObject;
    //public static implicit operator bool(IReferencia<T> referenciaInterfaz) => referenciaInterfaz.objetivo != null;
    void AlValidar()
    {
        if (objetivo is not T)
        {
            if (objetivo is GameObject go)
            {
                gameObject = go;
                objetivo = null;
                Component[] componentes = go.GetComponents<Component>();
                for (int i = 0; i < componentes.Length; i++)
                {
                    if (componentes[i] is T)
                    {
                        objetivo= componentes[i];
                        break;
                    }
                }
            }
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() => AlValidar();
    void ISerializationCallbackReceiver.OnAfterDeserialize() { }
}
