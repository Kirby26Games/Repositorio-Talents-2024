using System.Threading.Tasks;
using UnityEngine;

public class BotonGirar : Objeto, IInteractuable
{
    [Header("Objeto que rotar�")]
    public GameObject ObjetoARotar; // El objeto que rotar� al presionar el bot�n

    public async void AlInteractuar(GameObject objeto)
    {
        await Girando();
    }

    public async Task Girando()
    {
        Vector3 rotacion = ObjetoARotar.transform.localEulerAngles;
        while (rotacion.x < 180)
        {
            rotacion.x += 180 * Time.deltaTime;
            ObjetoARotar.transform.localEulerAngles = rotacion;
            await Task.Yield();
        }
        rotacion.x = 180;
        ObjetoARotar.transform.localEulerAngles = rotacion;
    }
}
