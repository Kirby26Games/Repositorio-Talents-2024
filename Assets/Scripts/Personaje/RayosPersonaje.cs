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

    public float RangoMirar = 10;
    public float AnguloEscaladaMaximo = 50;
    private float _RangoDeteccionSuelo;
    private float _AngulacionSuelo;
    [Header("Medidas")]
    private float _Alto;
    private float _Ancho;
    private float _Radio;

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
        _Radio = _Ancho / 2;
        _RangoDeteccionSuelo = _Alto / 2 - _Radio + 0.001f;
    }
}
