using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [Header("Referencias")]
    private SistemaGravedad _Gravedad;
    private RayosPersonaje _Rayos;
    private Rigidbody _RigidBody;
    [Header("Movimiento")]
    public Vector3 Ejes;
    public Vector3 DireccionFinal;
    public float VelocidadBase;
    public float MultiplicadorAlCorrer;
    private Vector3 _DireccionXZ; //Direccion sin altura
    private float _VelocidadFinal;
    private float _VelocidadModificador=1;
    [Header("Salto")]
    public float DistanciaSalto=2;
    public int SaltosEnElAireMaximos;
    public int SaltosEnElAireActuales;

    private void Awake()
    {
        _Gravedad = GetComponent<SistemaGravedad>();
        _RigidBody = GetComponent<Rigidbody>();
        _Rayos = GetComponent<RayosPersonaje>();
    }

    void Start()
    {
        CalcularVelocidad();
    }

    void Update()
    {
        Movimiento();
        ReiniciarSaltos();
    }

    void Movimiento()
    {
        _DireccionXZ = new Vector3(Ejes.x,0,Ejes.z).normalized;
        DireccionFinal= transform.TransformDirection(_DireccionXZ)*_VelocidadFinal;
        DireccionFinal = Vector3.ProjectOnPlane(DireccionFinal, _Rayos.DatosPendiente.normal);
        DireccionFinal.y += _Gravedad.EjeY;
        _RigidBody.linearVelocity = DireccionFinal;
    }

    public void Correr(bool corriendo)
    {
        if (corriendo)
        {
            _VelocidadModificador = MultiplicadorAlCorrer;
        }
        else
        {
            _VelocidadModificador = 1;
        }
        CalcularVelocidad();
    }
    public void CalcularVelocidad()
    {
        _VelocidadFinal = VelocidadBase * _VelocidadModificador;
    }
    public void Saltar()
    {
        if(!PuedoSaltar())
        {
            return;
        }
        //Salto
        Ejes.y = Mathf.Sqrt(DistanciaSalto*-2*_Gravedad.Gravedad);
    }
    public bool PuedoSaltar()
    {
        bool puedo = false;
        //Si estoy en el suelo, siempre puedo saltar
        if(_Gravedad.EnSuelo)
        {
            puedo = true; 
        }
        //si estoy en el aire, puedo saltar si no he llegado a los saltos maximos
        else if(SaltosEnElAireActuales<SaltosEnElAireMaximos)
        {
            puedo = true;
            SaltosEnElAireActuales++;
        }
        return puedo;
    }

    void ReiniciarSaltos()
    {
        if(_Gravedad.EnSuelo)
        {
            SaltosEnElAireActuales = 0;
        }
    }
}
