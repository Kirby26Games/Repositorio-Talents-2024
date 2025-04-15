using UnityEngine;

public class GestorSonido : MonoBehaviour
{
    public static void PonerAudio(AudioClip audio, AudioSource reporductor, bool debeRepetirse)
    {
        reporductor.clip = audio;
        reporductor.loop = debeRepetirse;
        reporductor.Play();
    }

    public static void PararAudio(AudioSource reproductor)
    {
        if (reproductor.isPlaying)
        {
            reproductor.Stop();
        }
    }

    public static void ModificarVolumen(AudioSource reproductor, float volumen)
    {
        reproductor.volume = volumen;
    }
}