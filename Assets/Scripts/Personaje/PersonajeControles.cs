using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControles : MonoBehaviour
{
    private MovimientoPersonaje _Movimiento;
    private MovimientoCamara _Camara;
    private RayosPersonaje _Rayos;


    private void Awake()
    {
        _Movimiento = GetComponent<MovimientoPersonaje>();
        _Camara = GetComponent<MovimientoCamara>();
        _Rayos = GetComponent<RayosPersonaje>();
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
        if(Input.GetKeyDown(Controles.Correr))
        {
            //empiezo a correr
            _Movimiento.Correr(true);
        }
        if (Input.GetKeyUp(Controles.Correr))
        {
            //Dejo de correr
            _Movimiento.Correr(false);
        }
        if(Input.GetMouseButtonDown(0))
        {
            _Rayos.Interactuar();
        }
        if (Input.GetKeyDown(Controles.Herramienta))
        {
            GestorJuego.AbrirCerrarHerramienta();
        }
    }
}
