using UnityEngine;

public class SlotPuerta : MonoBehaviour, ITriggereableEntrar {
  public Celula Celula;
  public SphereCollider Rango;
  public float ModificadorRango;

  public void Start() {
    Rango.radius = ModificadorRango;
  }

  public void AlTriggerearEntrar(Collider colision, GameObject personaje) {
    if (!personaje.TryGetComponent(out Interacciones interacciones) || interacciones.ObjetoInteractuado == null) {
      return;
    }
    // Si ya hay una celula y no tenemos objeto agarrado
    //if (interacciones.ObjetoInteractuado == null && Celula != null) {
    //  Celula.SacarCelula(personaje.transform);
    //  Celula = null;
    //  return;
    //}
    // Si no hay celula y lo que tenemos agarrado es una celula
    if (Celula == null && interacciones.ObjetoInteractuado.TryGetComponent(out Celula celula)) {
      Celula = celula;
      Celula.InsertarCelula(transform);
    }
  }
}
