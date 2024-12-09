using UnityEngine;
using UnityEngine.VFX;

public class GestorDeTiempo : MonoBehaviour
{
    private static bool _TiempoParado;

    public delegate void Tiempo();
    public static event Tiempo AlPararElTiempo;
    public static event Tiempo AlReanudarElTiempo;
    public static event Tiempo AlInvertirTiempo;

    public static void PararReanudarTiempoGlobal()
    {
        if (_TiempoParado)
        {
            AlReanudarElTiempo?.Invoke();
        }
        else
        {
            AlPararElTiempo?.Invoke();
        }
        _TiempoParado = !_TiempoParado;
    }

    public static void InvertirTiempoGlobal()
    {
        if (_TiempoParado)
        {
            AlInvertirTiempo?.Invoke();
        }
    }
}