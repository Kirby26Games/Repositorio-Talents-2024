using System.Threading.Tasks;
using UnityEngine;

public class ObjetoMirable : Objeto, IMirable
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

    public override void AlInteractuar()
    {
      
    }
    //quitar esto luego, es solo para hacer pruebas
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
        GestorJuego.AlAbrirHerramienta += Brillo;  
    }

    private void OnDisable()
    {
        GestorJuego.AlAbrirHerramienta -= Brillo;
    }
}