using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour, IMirable, IInteractuable
{
    private Renderer _Renderer;
    public string Interaccion; // texto que define el tipo de interaccion

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }
    public void AlMirar()
    {
        GestorInterfaz.Instancia.MostrarInterfazInteraccion(Interaccion);
        _Renderer.materials[1].SetInt("_Activo", 1);
    }

    public void AlDejarDeMirar()
    {
        GestorInterfaz.Instancia.OcultarInterazInteraccion();
        _Renderer.materials[1].SetInt("_Activo", 0);
    }

    public void AlInteractuar()
    {

    }
}
