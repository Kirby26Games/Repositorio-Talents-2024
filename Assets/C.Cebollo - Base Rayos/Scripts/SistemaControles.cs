using UnityEngine;

public class SistemaControles : MonoBehaviour
{
    private SistemaPersonaje _Personaje;
    [Header("Ejes")]
    public float EjeX;
    public float EjeZ;
    [Header("Raton")]
    private float _RatonHorizontal;
    private float _RatonVertical;
    public float SensibilidadRaton;
    [HideInInspector] public Vector3 PunteroRaton;
    [HideInInspector] public Vector3 IncrementoRotacion;
    [Header("Apuntado")]
    private Interactuable _ObjetivoInteraccion;

    private void Awake()
    {
        _Personaje = GetComponent<SistemaPersonaje>();
    }

    private void Start()
    {
        // Opciones de inicio para el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // TODO: personalizar esta parte según sea necesario
        SensibilidadRaton = Mathf.Clamp(SensibilidadRaton, 1f, 10f);
        PunteroRaton = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }
    private void Update()
    {
        // Sistema de interacciones
        if (Input.GetKeyDown(Controles.Interactuar))
        {
            _Interactuar();
        }
        
        // TODO: Implementar en sistema de movimiento
        EjeX = _EjeXTotal();
        EjeZ = _EjeZTotal();
        _RatonHorizontal = Input.GetAxis("Mouse X");
        _RatonVertical = Input.GetAxis("Mouse Y");

        // En caso de que el ratón controle un puntero, dejar este código
        PunteroRaton += new Vector3(_RatonHorizontal, _RatonVertical, 0f) * SensibilidadRaton;
        PunteroRaton = new Vector3(Mathf.Clamp(PunteroRaton.x, 0f, Screen.width), Mathf.Clamp(PunteroRaton.y, 0f, Screen.height), 0f);

        // En caso de que el ratón controle la rotación de la cámara, dejar este código
        IncrementoRotacion = new Vector3(_RatonHorizontal, _RatonVertical, 0f) * SensibilidadRaton;


        //if (Input.GetKeyDown(Controles.Saltar))
        //{
        //    Personaje.Movimiento.Saltar(1);
        //}

        //if (Input.GetKeyDown(Controles.Correr))
        //{
        //    Personaje.Movimiento.Correr(true);
        //}
        //if (Input.GetKeyUp(Controles.Correr))
        //{
        //    Personaje.Movimiento.Correr(false);
        //}
    }

    // Administra las interacciones del jugador
    void _Interactuar()
    {
        //Detectar
        _ObjetivoInteraccion = _Personaje.Apuntado.Detectar(Camera.main.transform.position, _Personaje.transform.forward, 10f);

        // Interactuar
        print("Interactuando con: " + _ObjetivoInteraccion?.Nombre);
        if (_ObjetivoInteraccion != null)
        {
            _ObjetivoInteraccion.Interaccion();
        }
    }

    // Administra la dirección en la que se mueve el jugador (Eje X)
    float _EjeXTotal()
    {
        if (Input.GetKey(Controles.Derecha))
        {
            return 1;
        }
        if (Input.GetKey(Controles.Izquierda))
        {
            return -1;
        }
        return 0;
    }

    // Administra la dirección en la que se mueve el jugador (Eje Z)
    float _EjeZTotal()
    {
        if (Input.GetKey(Controles.Adelante))
        {
            return 1;
        }
        if (Input.GetKey(Controles.Atras))
        {
            return -1;
        }
        return 0;
    }
}
