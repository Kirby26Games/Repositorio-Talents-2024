using UnityEngine;


public class RayosPersonaje : MonoBehaviour
{
    [Header("Referencias")]
    public Transform Camara;
    [HideInInspector]public RaycastHit DatosPendiente;
    private Collider _Colision;
    [Header("Interacciones")]
    public Color ColorDeteccionSuelo;
    public bool EnSuelo;
    public float RangoInteraccion=4;
    public Color ColorInteraccion;
    public float RangoMirar = 10;
    public float AnguloEscaladaMaximo = 50;
    private float _RangoDeteccionSuelo;
    private float _AngulacionSuelo;
    [Header("Medidas")]
    private float _Alto;
    private float _Ancho;
    private float _Radio;
    private IMirable _UltimoObjetoMirado;

    private void Awake()
    {
        _Colision = GetComponent<Collider>();
    }

    void Start()
    {
        CalcularMedidas();
    }

    void Update()
    {
        DetectarSuelo();
        Mirar();
    }
    public void DetectarSuelo()
    {
        if (Physics.SphereCast(transform.position, _Radio, -transform.up, out DatosPendiente, _RangoDeteccionSuelo))
        {
            Debug.DrawRay(transform.position, -transform.up * (DatosPendiente.distance + _Radio), ColorDeteccionSuelo);
            //Comprobamos si estamos en una pendiente
            //Cogemos el angulo de la pendiente usando su normal
            _AngulacionSuelo = Vector3.Angle(transform.up, DatosPendiente.normal);
            //Estamos en el suelo si AngulacionSuelo es menor a el angolo de escalada maximo
            EnSuelo = _AngulacionSuelo <= AnguloEscaladaMaximo;
        }
        else
        {
            EnSuelo = false;
            Debug.DrawRay(transform.position, -transform.up * (_RangoDeteccionSuelo + _Radio), Color.green);
        }
    }

    public void Interactuar()
    {
        RaycastHit Datos;
        if (Physics.Raycast(Camara.position, Camara.forward, out Datos, RangoInteraccion))
        {
            Debug.DrawRay(Camara.position, Camara.forward * Datos.distance, ColorInteraccion, 10f);
            if (Datos.transform.TryGetComponent(out IInteractuable ObjetoInteractuable))
            {
                ObjetoInteractuable.AlInteractuar();
            }
        }
    }
    public void Mover()
    {
        if (Physics.Raycast(Camara.position, Camara.forward, out RaycastHit Datos, RangoInteraccion))
        {
            Debug.DrawRay(Camara.position, Camara.forward * Datos.distance, ColorInteraccion, 10f);
            if (Datos.transform.TryGetComponent(out IMovible ObjetoInteractuable))
            {
                ObjetoInteractuable.AlMover();
            }
        }
    }

    private void Mirar()
    {
        if (Physics.Raycast(Camara.position, Camara.forward, out RaycastHit Datos, RangoInteraccion))
        {
            if (Datos.transform.TryGetComponent(out IMirable ObjetoMirable))
            {
                ObjetoMirable.AlMirar();
                _UltimoObjetoMirado= ObjetoMirable;
                return;
            }
        }
        if(_UltimoObjetoMirado !=null)
        {
            _UltimoObjetoMirado.AlDejarDeMirar();
            _UltimoObjetoMirado = null;
        }
    }
    public void CalcularMedidas()
    {
        _Alto = _Colision.bounds.size.y;
        _Ancho = _Colision.bounds.size.x;
        _Radio = _Ancho / 2;
        _RangoDeteccionSuelo = _Alto / 2 - _Radio + 0.001f;
    }
}
