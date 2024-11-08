using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EfectoHoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI _TextoBoton;

    void Start()
    {
        _TextoBoton = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_TextoBoton != null)
        {
            _TextoBoton.fontStyle = FontStyles.Bold;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_TextoBoton != null)
        {
            _TextoBoton.fontStyle = FontStyles.Normal;
        }
    }
}
