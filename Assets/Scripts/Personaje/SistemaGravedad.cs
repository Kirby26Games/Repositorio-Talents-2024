using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaGravedad : MonoBehaviour
{
    public float Gravedad = -9.82f;
    public float LimiteVelocidadCaida;
    public float EjeY;
    public bool EnSuelo;

    void Update()
    {
        CalcularGravedad();
    }
    public void CalcularGravedad()
    {
        if (EnSuelo && EjeY <= 0)
        {
            EjeY = 0;
        }
        else if (EjeY> LimiteVelocidadCaida)
        {
            EjeY += Gravedad * Time.deltaTime;
        }
    }
}
