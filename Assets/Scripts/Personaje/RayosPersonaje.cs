using System.Collections.Generic;
using UnityEngine;


public class RayosPersonaje : MonoBehaviour
{
    [Header("Referencias")]
    public Transform Camara;
    [HideInInspector] public RaycastHit DatosPendiente;
    private Collider _Colision;
    [Header("Interacciones")]
    public Color ColorDeteccionSuelo;

    public float RangoMirar = 10;
    public float AnguloEscaladaMaximo = 50;
    private float _RangoDeteccionSuelo;
    private float _AngulacionSuelo;
    [Header("Medidas")]
    private float _Alto;
    private float _Ancho;
    private float _Radio;
    private Collider[] _Colisiones;
    private SistemaGravedad _Gravedad;
    public LayerMask NoSuelo;

    private void Awake()
    {
        _Colisiones = new Collider[5];
        _Colision = GetComponent<Collider>();
        _Gravedad = GetComponent<SistemaGravedad>();
    }

    void Start()
    {
        CalcularMedidas();
    }

    void Update()
    {
        DetectarSuelo();

    }
    public void DetectarSuelo()
    {
        int colisiones = Physics.OverlapSphereNonAlloc(transform.position - transform.up * _RangoDeteccionSuelo, _Radio, _Colisiones,~NoSuelo);
        if (colisiones < 1)
        {
            _Gravedad.EnSuelo = false;
            return;
        }
        if (Physics.SphereCast(transform.position, _Radio, -transform.up, out DatosPendiente, _RangoDeteccionSuelo))
        {
            Debug.DrawRay(transform.position, -transform.up * (DatosPendiente.distance + _Radio), ColorDeteccionSuelo);
            //Comprobamos si estamos en una pendiente
            //Cogemos el angulo de la pendiente usando su normal
            _AngulacionSuelo = Vector3.Angle(transform.up, DatosPendiente.normal);
            //Estamos en el suelo si AngulacionSuelo es menor a el angolo de escalada maximo
            _Gravedad.EnSuelo = _AngulacionSuelo <= AnguloEscaladaMaximo;
        }
    }

    //Esto se puede transformar en una sola funcion, apunte
    public GameObject RayoEnfrente(float rango)
    {
        if (Physics.Raycast(Camara.position, Camara.forward, out RaycastHit Datos, rango))
        {
            return Datos.transform.gameObject;

        }
        return null;
    }
    public void CalcularMedidas()
    {
        _Alto = _Colision.bounds.size.y;
        _Ancho = _Colision.bounds.size.x;
        _Radio = _Ancho / 2-0.01f;
        _RangoDeteccionSuelo = _Alto / 2 - _Radio + 0.001f+0.01f;
    }
}
