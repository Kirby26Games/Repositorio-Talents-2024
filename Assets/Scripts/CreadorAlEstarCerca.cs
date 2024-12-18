using UnityEngine;
using UnityEngine.VFX;

public class CreadorAlEstarCerca : MonoBehaviour, ITriggereableEntrar, ITriggereableSalir
{
    public Collider Colision;
    public GameObject objetoACrear;
    public VisualEffect Efecto;
    public void AlTriggerearEntrar(Collider colision, GameObject objeto)
    {
        objetoACrear.GetComponent<VisualEffect>().SetInt("Estado Actual", Efecto.GetInt("Estado Actual"));
        Efecto.enabled = false;
        objetoACrear.SetActive(true);
    }
    public void AlTriggerearSalir(Collider colision, GameObject objeto)
    {
        Efecto.SetInt("Estado Actual", objetoACrear.GetComponent<VisualEffect>().GetInt("Estado Actual"));
        Efecto.enabled = true;
        objetoACrear.SetActive(false);
    }
}
