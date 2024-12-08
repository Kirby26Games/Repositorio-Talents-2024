using UnityEngine;

public class ObjetoInvertible : Objeto
{
    private Rigidbody _RigidBody;
    private Vector3 _UltimaVelocidad;

    public override void CogerComponentesBasicos()
    {
        base.CogerComponentesBasicos();
        _RigidBody = GetComponent<Rigidbody>();
    }

    public override void SuscribirEventos()
    {
        base.SuscribirEventos();
        GestorDeTiempo.AlPararElTiempo += Detenerse;
        GestorDeTiempo.AlReanudarElTiempo += Reanudarse;
        GestorDeTiempo.AlInvertirTiempo += Invertirse;
    }

    public override void DesuscribirEventos()
    {
        base.DesuscribirEventos();
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
