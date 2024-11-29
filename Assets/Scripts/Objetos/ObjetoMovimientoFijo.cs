using UnityEngine;

public class ObjetoMovimientoFijo : Objeto, IMovible
{
    private Vector3 _PosicionOriginal;
    public float LimiteX;
    public float LimiteY;
    public float LimiteZ;
    private void Awake()
    {
        _PosicionOriginal = transform.position;
    }
    public void AlMover()
    {
        MovimientoFijo();
    }
    private void MovimientoFijo()
    {
        Vector3 posicionFinal = Vector3.zero;
        posicionFinal = Camera.main.transform.position + Camera.main.transform.forward * 2;
        posicionFinal.x = Mathf.Clamp(posicionFinal.x, _PosicionOriginal.x - LimiteX, _PosicionOriginal.x + LimiteX);
        posicionFinal.y = Mathf.Clamp(posicionFinal.y, _PosicionOriginal.y - LimiteY, _PosicionOriginal.y + LimiteY);
        posicionFinal.z = Mathf.Clamp(posicionFinal.z, _PosicionOriginal.z - LimiteZ, _PosicionOriginal.z + LimiteZ);
        transform.position = posicionFinal;
    }
}
