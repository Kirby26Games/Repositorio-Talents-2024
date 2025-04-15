using UnityEngine;
using UnityEngine.Rendering;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "Dialogo", menuName = "Scriptable Objects/Dialogo", order = 2)]
public class ObjetoDialogo : ScriptableObject
{
    public Dialogo Dialogo;
}


[CreateAssetMenu(fileName = "CinematicaEjemplo", menuName = "Scriptable Objects/CinematicaEjemplo")]
public class CinematicaEjemplo : ScriptableObject
{
    private VolumeComponent efectoBloom;

    public async void Cinematica1()
    {
        EfectoPostProcesadoDatos efecto1 = new(EfectoPostProcesado.BLOOM, efectoBloom);
        GestorCinematica.Instancia.ImpedirMovimiento();
        GestorCinematica.Instancia.AplicarPostProcesado(efecto1);
        await Task.Delay(3000);
        GestorCinematica.Instancia.PersonajeMiraHacia(Vector3.right);
        await Task.Delay(3000);
        GestorCinematica.Instancia.PermitirMovimiento();
    }
}