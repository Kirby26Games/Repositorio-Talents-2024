using UnityEngine;
public abstract class Objeto : MonoBehaviour,IMirable
{
    private Renderer _Renderer;
    public string Nombre;
    public string Interaccion;

    private void Awake()
    {
        CogerComponentesBasicos();
    }
    public virtual void CogerComponentesBasicos()
    {
        _Renderer = GetComponent<Renderer>();
    }

    public virtual void AlMirar()
    {
        GestorInterfaz.Instancia.MostrarInterfazInteraccion(Nombre+"\n"+Interaccion);
        _Renderer.materials[1].SetInt("_Activo", 1);
    }

    public virtual void AlDejarDeMirar()
    {
        GestorInterfaz.Instancia.OcultarInterazInteraccion();
        _Renderer.materials[1].SetInt("_Activo", 0);
    }
    public void Brillo(bool opcion)
    {
        _Renderer.material.EnableKeyword("_EMISSION");
        if (opcion)
        {
            _Renderer.material.SetColor(Atajos.Emisivo, Atajos.ColorObjetos);
        }
        else
        {
            _Renderer.material.SetColor(Atajos.Emisivo, Color.black);
        }
    }

    private void OnEnable()
    {
        SuscribirEventos();
    }

    private void OnDisable()
    {
        DesuscribirEventos();
    }
    public virtual void SuscribirEventos()
    {

        GestorJuego.AlAbrirHerramienta += Brillo;
    }

    public virtual void DesuscribirEventos()
    {

        GestorJuego.AlAbrirHerramienta -= Brillo;
    }

}