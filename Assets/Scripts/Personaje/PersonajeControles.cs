using System;
using UnityEngine;

public class PersonajeControles : MonoBehaviour
{
    public static Action InteractuarAlt;

    private MovimientoPersonaje _Movimiento;
    private MovimientoCamara _Camara;
    private Interacciones _Interacciones;



    private void Awake()
    {
        _Movimiento = GetComponent<MovimientoPersonaje>();
        _Camara = GetComponent<MovimientoCamara>();
        _Interacciones = GetComponent<Interacciones>();
    }
    void Update()
    {
        ControlesFuncion();
    }

    public void ControlesFuncion()
    {
        _Movimiento.Ejes.x = Input.GetAxisRaw("Horizontal"); //Izquierda y derecha
        _Movimiento.Ejes.z = Input.GetAxisRaw("Vertical"); //Alante y atras

        _Camara.Ejes.y = Input.GetAxis("Mouse Y");
        _Camara.Ejes.x = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(Controles.Saltar))
        {
            //LLamar a saltar
            _Movimiento.Saltar();
        }
        if (Input.GetKeyDown(Controles.Correr))
        {
            //empiezo a correr
            _Movimiento.Correr(true);
        }
        if (Input.GetKeyUp(Controles.Correr))
        {
            //Dejo de correr
            _Movimiento.Correr(false);
        }
        if (Input.GetKeyDown(Controles.Interactuar))
        {
            _Interacciones.Interactuar();
        }
        if (Input.GetKey(Controles.Mover))
        {
            _Interacciones.Mover();//
        }
        if (Input.GetKeyDown(Controles.Zoom))
        {
            _Camara.CambiarZoom(true);//
        }
        if (Input.GetKeyUp(Controles.Zoom))
        {
            _Camara.CambiarZoom(false);//
        }
        if (Input.GetKeyDown(Controles.InvertirElTiempo))
        {
            GestorDeTiempo.InvertirTiempoGlobal();
        }
        if (Input.GetKeyDown(Controles.PararElTiempo))
        {
            GestorDeTiempo.PararReanudarTiempoGlobal();
        }
        if (Input.GetKeyDown(Controles.Herramienta))
        {
            GestorJuego.AbrirCerrarHerramienta();
        }
    }
}
