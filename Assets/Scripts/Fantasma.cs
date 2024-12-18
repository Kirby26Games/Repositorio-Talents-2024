using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Fantasma : Objeto
{
    private VisualEffect _EfectoParticulas;
    private int _EstadoAnterior;
    public override void CogerComponentesBasicos()
    {
        _EfectoParticulas = GetComponent<VisualEffect>();
    }

    private void Detenerse()
    {
        _EstadoAnterior = 1;
        if (_EfectoParticulas.GetInt("Estado Actual") == 2)
        {
            return;
        }
        _EfectoParticulas.SetInt("Estado Actual", 1);
    }

    private void Reanudarse()
    {
        _EstadoAnterior = 0;
        if (_EfectoParticulas.GetInt("Estado Actual") == 2)
        {
            return;
        }
        _EfectoParticulas.SetInt("Estado Actual", 0);
    }

    private void Herramienta(bool opcion)
    {
        if (opcion)
        {
            _EfectoParticulas.SetInt("Estado Actual", 2);
        }
        else
        {
            _EfectoParticulas.SetInt("Estado Actual", _EstadoAnterior);
        }
    }

    public override void SuscribirEventos()
    {
        GestorDeTiempo.AlPararElTiempo += Detenerse;
        GestorDeTiempo.AlReanudarElTiempo += Reanudarse;

        GestorJuego.AlAbrirHerramienta += Herramienta;
    }

    public override void DesuscribirEventos()
    {
        GestorDeTiempo.AlPararElTiempo -= Detenerse;
        GestorDeTiempo.AlReanudarElTiempo -= Reanudarse;

        GestorJuego.AlAbrirHerramienta -= Herramienta;
    }
}
