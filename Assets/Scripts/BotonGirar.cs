using System.Threading.Tasks;
using UnityEngine;

public class BotonGirar : Objeto, IInteractuable
{
    [Header("Objeto que rotará")]
    public GameObject ObjetoARotar; // El objeto que rotará al presionar el botón

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
