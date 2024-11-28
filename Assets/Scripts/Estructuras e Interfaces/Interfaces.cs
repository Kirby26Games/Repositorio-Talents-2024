using UnityEngine;

public interface IMirable
{
    public void AlMirar();
    public void AlDejarDeMirar();
}

public interface IInteractuable
{

    public void AlInteractuar();
}

public interface IActivable
{
    public void AlActivar();
}

public interface IColisionableEntrar
{
    public void AlColisionarEntrar(Collider colision, GameObject objeto);

}

public interface IColisionableSalir
{
    public void AlColisionarSalir(Collider colision, GameObject objeto);

}
public interface ITriggereableEntrar
{
    public void AlTriggerearEntrar(Collider colision,GameObject objeto);

}
public interface ITriggereableSalir
{
    public void AlTriggerearEntrar(Collider colision, GameObject objeto);

}
