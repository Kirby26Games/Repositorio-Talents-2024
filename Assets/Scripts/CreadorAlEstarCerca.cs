using UnityEngine;

public class CreadorAlEstarCerca : MonoBehaviour, ITriggereableEntrar
{
    public GameObject objetoACrear;
    public void AlTriggerearEntrar(Collider colision, GameObject objeto)
    {
        GameObject objetoCreado = Instantiate(objetoACrear);
        objetoCreado.transform.position = transform.position;
    }
}
