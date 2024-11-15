using UnityEngine;
using UnityEngine.UIElements;

public class ObjetoMovimientoFijo : Objeto, IMirable
{
    public string Interaccion; // texto que define el tipo de interaccion
    private Renderer _Renderer;
    private Vector3 _PosicionOriginal;
    private Vector3 _RotacionOriginal;
    private Rigidbody _RigidBody;
    public float LimiteX;
    public float LimiteY;
    public float LimiteZ;
    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
        _RigidBody = GetComponent<Rigidbody>();
        _PosicionOriginal = transform.position;
        _RotacionOriginal = transform.eulerAngles;
    }
    public void AlMirar()
    {
        GestorInterfaz.Instancia.MostrarInterfazInteraccion(Interaccion);
        _Renderer.materials[1].SetInt("_Activo", 1);
    }

    public void AlDejarDeMirar()
    {
        GestorInterfaz.Instancia.OcultarInterazInteraccion();
        _Renderer.materials[1].SetInt("_Activo", 0);
    }

    public override void AlInteractuar()
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

        _RigidBody.linearVelocity = Vector3.zero;
        transform.eulerAngles = _RotacionOriginal;
    }
}
