using UnityEngine;

public class ObjetoRecolectable : MonoBehaviour
{
    [SerializeField] Sprite _ImagenObjeto;
    [SerializeField] GestorImagenes _MiGestor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    public void CollectItem()
    {


        if (_MiGestor != null)
        {
            _MiGestor.AssignaImagen(_ImagenObjeto);
            Destroy(gameObject);
        }
    }
}