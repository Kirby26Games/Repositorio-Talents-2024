using UnityEngine;

public class ObjetoMovimientoFijo : Objeto, IMovible
{
    private Vector3 _PosicionOriginal;
    public Vector2 MinMaxX;
    public Vector2 MinMaxY;
    public Vector2 MinMaxZ;
    private void Awake()
    {
        _PosicionOriginal = transform.position;
        base.Awake();
    }
    public void AlMover()
    {
        MovimientoFijo();
    }
    private void MovimientoFijo()
    {
        Vector3 posicionFinal = Vector3.zero;
        posicionFinal = Camera.main.transform.position + Camera.main.transform.forward * 2;
        posicionFinal.x = Mathf.Clamp(posicionFinal.x, _PosicionOriginal.x + MinMaxX.x, _PosicionOriginal.x + MinMaxX.y);
        posicionFinal.y = Mathf.Clamp(posicionFinal.y, _PosicionOriginal.y + MinMaxY.x, _PosicionOriginal.y + MinMaxY.y);
        posicionFinal.z = Mathf.Clamp(posicionFinal.z, _PosicionOriginal.z + MinMaxZ.x, _PosicionOriginal.z + MinMaxZ.y);
        transform.position = posicionFinal;
    }
}
