using UnityEngine;

public class ObjetoMovimientoFijo : Objeto, IMovible
{
    private Vector3 _PosicionOriginal;
    public float LimiteX;
    public float LimiteY;
    public float LimiteZ;

    private void Start()
    {
        _PosicionOriginal = transform.position;
    }
    public void AlMover()
    {
        MovimientoFijo();
    }
    private void MovimientoFijo()
    {
        Vector3 posicionFinal;
        posicionFinal = Camera.main.transform.position + Camera.main.transform.forward * 2;
        posicionFinal.x = Mathf.Clamp(posicionFinal.x, _PosicionOriginal.x, _PosicionOriginal.x + LimiteX);
        posicionFinal.y = Mathf.Clamp(posicionFinal.y, _PosicionOriginal.y, _PosicionOriginal.y + LimiteY);
        posicionFinal.z = Mathf.Clamp(posicionFinal.z, _PosicionOriginal.z, _PosicionOriginal.z + LimiteZ);
        transform.position = posicionFinal;
    }
}
