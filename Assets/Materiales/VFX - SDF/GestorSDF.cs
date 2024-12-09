using UnityEngine;
using UnityEngine.VFX;

public class GestorSDF : MonoBehaviour
{
    private VisualEffect _SDF_Test;

    private void Awake()
    {
        _SDF_Test = GetComponent<VisualEffect>();
    }

    private void OnEnable()
    {
        SuscribirEventos();
    }

    private void OnDisable()
    {
        DesuscribirEventos();
    }

    private void Detenerse()
    {
        _SDF_Test.SetFloat("RevertirTiempo", .2f);
    }

    private void Reanudarse()
    {
        _SDF_Test.SetFloat("RevertirTiempo", 1f);
    }

    private void Invertirse()
    {
        _SDF_Test.SetFloat("RevertirTiempo", -1f);
    }

    public virtual void SuscribirEventos()
    {
        GestorDeTiempo.AlPararElTiempo += Detenerse;
        GestorDeTiempo.AlReanudarElTiempo += Reanudarse;
        GestorDeTiempo.AlInvertirTiempo += Invertirse;
    }

    public virtual void DesuscribirEventos()
    {
        GestorDeTiempo.AlPararElTiempo -= Detenerse;
        GestorDeTiempo.AlReanudarElTiempo -= Reanudarse;
        GestorDeTiempo.AlInvertirTiempo -= Invertirse;
    }
}
