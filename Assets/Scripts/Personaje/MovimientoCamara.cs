using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Camera Camara;
    public Vector2 Ejes;
    public float Sensibilidad = 1;
    public float LimiteCamara=90;
    private float _RotacionX;

    void Start()
    {
        LimitarCursor();
    }

    void Update()
    {
        RotacionCamara();
    }

    public void RotacionCamara()
    {
        _RotacionX -= Ejes.y * Sensibilidad;

        //Limito el movimiento de la camara arriba y abajo, Mathf.clamp limita un valor
        _RotacionX = Mathf.Clamp(_RotacionX, -LimiteCamara, LimiteCamara);

        //Aqui giro la camara
        Camara.transform.localEulerAngles = new Vector3(_RotacionX, 0, 0);
        //Giro el personaje
        transform.Rotate(Vector3.up * Ejes.x * Sensibilidad);
    }

    public void LimitarCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; //El cursor se pone en el centro
        Cursor.visible = false; //el cursor se hace invisible
    }
}
