using Sirenix.OdinInspector;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class SistemaSubtitulos : MonoBehaviour
{
    public TMP_Text RecuadroTexto;
    public ObjetoDialogo ObjetoDialogo;

    int _Intercalado = 75;
    string _Mensaje;
    [Button]
    public async void PonerDialogo()
    {
        _Mensaje = ObjetoDialogo.Dialogo.Texto;
        LimpiarDialogo();
        await EscribirLetras();
        await Task.Delay(ObjetoDialogo.Dialogo.Duracion * 1000);
        LimpiarDialogo();
    }

    public void LimpiarDialogo()
    {
        RecuadroTexto.text = "";
    }
    async Task EscribirLetras()
    {
        RecuadroTexto.text = ObjetoDialogo.Dialogo.Nobre+": ";
        for (int i = 0; i < _Mensaje.Length; i++)
        {
            RecuadroTexto.text += _Mensaje[i];
            await Task.Delay(_Intercalado);
        }
        //foreach (char letra in _Mensaje.ToCharArray())
        //{
        //    RecuadroTexto.text += letra;
        //    await Task.Delay(_Intercalado);
        //}
    }
}