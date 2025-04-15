using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Movible : Objeto, IInteractuable
{
    internal Rigidbody _RigidBody;
    //public float ModificadorTraccion;
    //public float FuerzaDeTraccionMaxima;
    //public float VelocidadTraccion;
    //public float Distancia;
    public Transform Objetivo;
    public Vector3 Direccion;
    public override void CogerComponentesBasicos()
    {
        base.CogerComponentesBasicos();
        _RigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoverHacia();
    }

    public void Coger(Transform objetivo)
    {
        Objetivo = objetivo;
    }

    public void AlInteractuar(GameObject objeto)
    {
        if (Objetivo != null)
        {
            Soltar();
            return;
        }
        Coger(objeto.transform);
    }
    public void MoverHacia()
    {
        if (Objetivo == null)
        {
            return;
        }
        // Distancia = Vector3.Distance(Objetivo.position, transform.position);
        //VelocidadTraccion += Time.deltaTime / Distancia * ModificadorTraccion;
        //VelocidadTraccion = Mathf.Clamp(VelocidadTraccion, 0, FuerzaDeTraccionMaxima);
        //Direccion = (Objetivo.position - transform.position) * VelocidadTraccion;
        Direccion = Objetivo.position - transform.position;
        //Acciones segun distancia

        //if (Distancia > 5f)
        //{
        //    Direccion.y = _RigidBody.linearVelocity.y;
        //}
        //if (Distancia <= 5)
        //{
        //    _RigidBody.useGravity = false;

        //}
        //if (Distancia <= 2)
        //{
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 1000 * Time.deltaTime);
            _RigidBody.angularVelocity = Vector3.zero;

        //}
        _RigidBody.linearVelocity = Direccion*10;
    }

    public void Soltar()
    {
        //VelocidadTraccion = 0;
        Objetivo = null;
        _RigidBody.useGravity = true;
    }
}