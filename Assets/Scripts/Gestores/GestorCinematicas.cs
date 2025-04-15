using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;



public class GestorCinematica : MonoBehaviour
{
    public static GestorCinematica Instancia;
    public Transform Personaje;
    public Camera Camara;
    public EfectoPostProcesadoDatos[] EfectosPostProcesado;
    public Volume VolumenPostProcesado;

    private MovimientoPersonaje _Movimiento;
    private MovimientoCamara _Camara;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            Personaje.TryGetComponent(out _Movimiento);
            Personaje.TryGetComponent(out _Camara);
            return;
        }
        Destroy(gameObject);
    }

    public void PersonajeMiraHacia(Vector3 direccion)
    {
        Personaje.LookAt(direccion);
    }

    public void AplicarPostProcesado(EfectoPostProcesadoDatos datosEfecto)
    {
        if (datosEfecto.NombreEfecto == EfectoPostProcesado.CHROMATIC_ABERRATION)
        {
            ChromaticAberration parametros = (ChromaticAberration)datosEfecto.Parametros;
            if (VolumenPostProcesado.profile.TryGet(out ChromaticAberration chrAberration))
            {
                chrAberration = parametros;
            }
            else
            {
                VolumenPostProcesado.profile.Add<ChromaticAberration>(parametros);
            }
            return;
        }
        if (datosEfecto.NombreEfecto == EfectoPostProcesado.BLOOM)
        {
            if (VolumenPostProcesado.profile.TryGet(out Bloom bloom))
            {
                bloom = (Bloom)datosEfecto.Parametros;
            }
            return;
        }
        if (datosEfecto.NombreEfecto == EfectoPostProcesado.FOG)
        {
            if (VolumenPostProcesado.profile.TryGet(out Fog fog))
            {
                fog = (Fog)datosEfecto.Parametros;
            }
            return;
        }
    }

    public void ImpedirMovimiento()
    {
        if (_Movimiento != null && _Camara != null)
        {
            _Movimiento.enabled = _Camara.enabled = false;
        }
    }

    public void PermitirMovimiento()
    {
        if (_Movimiento != null && _Camara != null)
        {
            _Movimiento.enabled = _Camara.enabled = true;
        }
    }
}