using System;
using UnityEngine;
using UnityEngine.Rendering;


[Serializable]
public struct Dialogo
{
    public string Nobre;
    public int Duracion;
    public string Texto;
}

[Serializable]
public struct Sonido
{
    public AudioClip Audio;
    public float Volumen;
    public int TiempoReproduccion;
    public bool PonerAlEmpezar;
    public bool DebeRepetirse;
}

public enum EfectoPostProcesado
{
    NONE = 0,
    BLOOM = 1,
    CHROMATIC_ABERRATION = 2,
    FOG = 3
}

public struct EfectoPostProcesadoDatos
{
    public EfectoPostProcesado NombreEfecto;
    public VolumeComponent Parametros;

    public EfectoPostProcesadoDatos(EfectoPostProcesado efecto, VolumeComponent configuracion)
    {
        NombreEfecto = efecto;
        Parametros = configuracion;
    }
}
