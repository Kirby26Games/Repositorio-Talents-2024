using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GestorImagenes : MonoBehaviour
{
    public Image[] HuecoImagen;
    [SerializeField]
    UnityEvent SinHueco;

    public void AssignaImagen(Sprite NuevoSprite)
    {
        for (int i = 0; i < HuecoImagen.Length; i++)
        {
            if (HuecoImagen[i].sprite == null)
            {
                HuecoImagen[i].sprite = NuevoSprite;
                HuecoImagen[i].enabled = true;
                return;
            }
        }



        SinHueco.Invoke();
    }
}