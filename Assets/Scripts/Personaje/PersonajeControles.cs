using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControles : MonoBehaviour
{
    private MovimientoPersonaje _Movimiento;
    private MovimientoCamara _Camara;
    private RayosPersonaje _Rayos;
    private bool _TiempoParado;

    public static event EventHandler EnPararTiempo;
    public static event EventHandler EnReanudarTiempo;
    public static event EventHandler EnInvertirTiempo;

    private void Awake()
    {
        _Movimiento = GetComponent<MovimientoPersonaje>();
        _Camara = GetComponent<MovimientoCamara>();
        _Rayos = GetComponent<RayosPersonaje>();
    }
    void Update()
    {
        Controles();
    }

    public void Controles()
    {
        _Movimiento.Ejes.x = Input.GetAxisRaw("Horizontal"); //Izquierda y derecha
        _Movimiento.Ejes.z = Input.GetAxisRaw("Vertical"); //Alante y atras

        _Camara.Ejes.y = Input.GetAxis("Mouse Y");
        _Camara.Ejes.x = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //LLamar a saltar
            _Movimiento.Saltar();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //empiezo a correr
            _Movimiento.Correr(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Dejo de correr
            _Movimiento.Correr(false);
        }
        if(Input.GetMouseButton(0))
        {
            _Rayos.Interactuar();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_TiempoParado)
            {
                EnReanudarTiempo?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                EnPararTiempo?.Invoke(this, EventArgs.Empty);
            }
            _TiempoParado = !_TiempoParado;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_TiempoParado)
            {
                EnInvertirTiempo?.Invoke(this, EventArgs.Empty);
                _TiempoParado = false;
            }
        }
    }
}
