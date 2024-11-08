using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorJuego : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }

    public static void CambiarEscena(int ID)
    {
        SceneManager.LoadScene(ID);
    }
}
