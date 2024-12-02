using UnityEngine;

public class ObjetoInvertible : Objeto
{
    private Vector3 _PosicionOriginal;
    private Vector3 _RotacionOriginal;
    private Rigidbody _RigidBody;
    private Vector3 _UltimaVelocidad;
    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
        _PosicionOriginal = transform.position;
        _RotacionOriginal = transform.eulerAngles;
        base.Awake();       
    }

    private void OnEnable()
    {
        GestorDeTiempo.AlPararElTiempo += Detenerse;
        GestorDeTiempo.AlReanudarElTiempo += Reanudarse;
        GestorDeTiempo.AlInvertirTiempo += Invertirse;
    }

    private void OnDisable()
    {
        GestorDeTiempo.AlPararElTiempo -= Detenerse;
        GestorDeTiempo.AlReanudarElTiempo -= Reanudarse;
        GestorDeTiempo.AlInvertirTiempo -= Invertirse;
    }

    private void Detenerse()
    {
        if (!_RigidBody.useGravity)
        {
            return;
        }
        _UltimaVelocidad = _RigidBody.linearVelocity;
        _RigidBody.useGravity = false;
        _RigidBody.linearVelocity = Vector3.zero;
    }
    private void Reanudarse()
    {
        if(_RigidBody.useGravity)
        {
            return;
        }
        _RigidBody.linearVelocity = _UltimaVelocidad;
        _RigidBody.useGravity = true;
    }
    private void Invertirse()
    {
        if (_RigidBody.useGravity)
        {
            return;
        }
        _UltimaVelocidad *= -1f;
        _RigidBody.linearVelocity = _UltimaVelocidad;
        _RigidBody.useGravity = true;
    }
}
