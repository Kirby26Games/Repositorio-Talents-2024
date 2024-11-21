using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorJuego : MonoBehaviour
{
    public delegate void Accion(bool opcion);
    public static event Accion AlAbrirHerramienta;
    private static bool _Abierta;

    public void Salir()
    {
        Application.Quit();
    }

    public static void CambiarEscena(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public static void AbrirCerrarHerramienta()
    {
        _Abierta = !_Abierta;

        if (AlAbrirHerramienta != null)
        {
            AlAbrirHerramienta(_Abierta);
        }
    }
}
