using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Camera Camara;
    public Vector2 Ejes;
    public float Sensibilidad = 1;
    public float LimiteCamara=90;
    private float _RotacionX;
    public float ZoomDuracion = 1;
    public bool ZoomInmediato = false;   //hacer zoom de golpe o no
    private float _RangoDeVisionNormal = 60; //Debo hacer que esto sean opciones del juego y opciones estatico
    public float RangoDeVisionAlHacerZoom = 30;
    private float _RangoDeVision;

    void Start()
    {
        LimitarCursor();
        CambiarZoom(false);
    }

    void Update()
    {
        RotacionCamara();
        ZoomCamara();
    }

    public void RotacionCamara()
    {
        _RotacionX -= Ejes.y * Sensibilidad;

        //Limito el movimiento de la camara arriba y abajo, Mathf.clamp limita un valor
        _RotacionX = Mathf.Clamp(_RotacionX, -LimiteCamara, LimiteCamara);

        //Giro el personaje
        transform.Rotate(Ejes.x * Sensibilidad * Vector3.up);
        //Aqui giro la camara
        Camara.transform.localEulerAngles = new Vector3(_RotacionX, 0, 0);
    }

    public void CambiarZoom(bool opcion)
    {
        if(opcion) 
            {
            _RangoDeVision = RangoDeVisionAlHacerZoom;
            }
            else
        {
            _RangoDeVision = _RangoDeVisionNormal;
        }
    }
    public void ZoomCamara()
    {
        if (Camara.fieldOfView == _RangoDeVision)
        {
            return;
        }
            CalcularZoom(_RangoDeVision);    
    }
    private void CalcularZoom(float objetivo)
    {
        float distTotal = Mathf.Abs(_RangoDeVisionNormal - RangoDeVisionAlHacerZoom); // cantidad total para llegar la target
        if (ZoomInmediato)
        {
            Camara.fieldOfView = objetivo;
        }
        else
        {
            Camara.fieldOfView = Mathf.MoveTowards(Camara.fieldOfView, objetivo, distTotal / ZoomDuracion * Time.deltaTime);
        }
        // comprobamos ZoomInmediato y si es true o no se hace de inmediato el cambio o usamos moveTowards en donde en maxDelta ponemos
        // distTotal entre duracion para obtener la velocidad para hacer todo el recorrido
    }
    public void LimitarCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; //El cursor se pone en el centro
        Cursor.visible = false; //el cursor se hace invisible
    }
}
