using UnityEngine;

public class Interacciones : MonoBehaviour
{
    public float RangoInteraccion = 4;
    public GameObject Mano;
    private IMirable _UltimoObjetoMirado;
    private IInteractuable _UltimoObjetoInteractuado;
    private RayosPersonaje _Rayos;
    private GameObject _ObjetoMirado;


    private void Awake()
    {
        _Rayos = GetComponent<RayosPersonaje>();
    }
    public void Update()
    {
        Mirar();
    }
    public void Interactuar()
    {
        if (_UltimoObjetoInteractuado != null)
        {
            _UltimoObjetoInteractuado.AlInteractuar(Mano);
            _UltimoObjetoInteractuado = null;
            return;
        }
        GameObject objeto = _Rayos.RayoEnfrente(RangoInteraccion);
        if (objeto == null)
        {
            return;
        }
        if (!objeto.TryGetComponent(out IInteractuable objetoInteractuable))
        {
            return;
        }
        objetoInteractuable.AlInteractuar(Mano);
        _UltimoObjetoInteractuado = objetoInteractuable;
    }
    public void Mover()
    {
        GameObject objeto = _Rayos.RayoEnfrente(RangoInteraccion);
        if (objeto == null)
        {
            return;
        }
        if (objeto.TryGetComponent(out IMovible objetoMovible))
        {
            objetoMovible.AlMover();
        }
    }
    public void Mirar()
    {
        _ObjetoMirado = _Rayos.RayoEnfrente(RangoInteraccion);
        if (_ObjetoMirado == null)
        {
            DejarDeMirar();
            return;
        }
        if (_ObjetoMirado.TryGetComponent(out IMirable ObjetoMirable))
        {
            ObjetoMirable.AlMirar();
            _UltimoObjetoMirado = ObjetoMirable;
            return;
        }
        DejarDeMirar();
    }
    public void DejarDeMirar()
    {
        if (_UltimoObjetoMirado != null)
        {
            _UltimoObjetoMirado.AlDejarDeMirar();
            _UltimoObjetoMirado = null;
        }
    }


}