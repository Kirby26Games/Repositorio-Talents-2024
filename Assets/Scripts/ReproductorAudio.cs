using Sirenix.OdinInspector;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReporductorAudio : MonoBehaviour
{
    public Sonido Audio;
    private AudioSource _Reproductor;
    private CancellationTokenSource _TokenCancelacion;

    public void Awake()
    {
        _Reproductor = GetComponent<AudioSource>();
    }
    [Button]
    public void PonerSonidoTest()
    {
        if (_Reproductor.isPlaying)
        {
            _TokenCancelacion?.Cancel();
            _TokenCancelacion?.Dispose();
        }
        _TokenCancelacion = new(); //Se debe llamar esto siempre antes de poner el audio
        if (Audio.PonerAlEmpezar)
        {
            PonerAudio(Audio.TiempoReproduccion);
        }
    }

    private async void PonerAudio(int tiempoReproduccion)
    {
        //Pongo el audio
        GestorSonido.PonerAudio(Audio.Audio, _Reproductor, Audio.DebeRepetirse);
        if (tiempoReproduccion > 0)
        {
            //Si tiempoReproduccion es mayor a 0, se debe parar en el tiempo definido
            await PararAudio(tiempoReproduccion);
        }
    }
    private async Task PararAudio(int tiempoReproduccion)
    {  
        //Se para segun el tiempo y se registra el Token de cancelacion
        await Task.Delay(tiempoReproduccion * 1000, _TokenCancelacion.Token); 
        GestorSonido.PararAudio(_Reproductor);
    }
}