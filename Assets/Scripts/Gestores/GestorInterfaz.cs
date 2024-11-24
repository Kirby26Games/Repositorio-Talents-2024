using TMPro;
using UnityEngine;

public class GestorInterfaz : MonoBehaviour
{
    public TMP_Text TextoInteraccion; // elemento de texto
    public static GestorInterfaz Instancia;
    void Awake()
    {
        Instancia = this;
        if (TextoInteraccion == null)
        {
            Debug.Log("Falta asignar el gameobject de texto");
        }
    }

    public void MostrarInterfazInteraccion(string texto)
    {
        // asignar texto
        TextoInteraccion.text = texto;
        // activar texto
        // podria llevar una animacion con el alpha, para que aparezca/desaparezca poco a poco
        TextoInteraccion.gameObject.SetActive(true);
    }

    public void OcultarInterazInteraccion()
    {
        // desactivar texto
        TextoInteraccion.text = "";
        // podria llevar una animacion con el alpha, para que aparezca/desaparezca poco a poco
        TextoInteraccion.gameObject.SetActive(false);
    }
}
