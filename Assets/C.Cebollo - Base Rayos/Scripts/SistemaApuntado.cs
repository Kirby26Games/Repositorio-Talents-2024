using UnityEngine;

// Clase que controla como interactúa el personaje con el medio
public class SistemaApuntado : MonoBehaviour
{
    // Obtiene todos los objetos delante del personaje y devuelve el más cercano interactuable o null
    public Interactuable Detectar(Vector3 inicio, Vector3 direccion, float distancia)
    {
        RaycastHit[] datos;
        Debug.DrawRay(inicio, direccion * distancia, Color.red);
        datos = Physics.RaycastAll(inicio, direccion, distancia);
        if (datos.Length <= 0)
        {
            return null;
        }
        return _MasCercano(datos, distancia);
    }

    // Comprueba que objetos son interactuables y los ordena por distancia, devolviendo el más cercano
    private Interactuable _MasCercano(RaycastHit[] lista, float distanciaMaxima = 1000f)
    {
        float distanciaMinima = distanciaMaxima;
        int indice = -1;
        for (int i = 0; i < lista.Length; i++)
        {
            if (distanciaMinima > lista[i].distance)
            {
                if(_EsInteractuable(lista[i]))
                {
                    indice = i;
                    distanciaMinima = lista[i].distance;
                }
                else if (indice != -1 && !_RespetaTransparencias(lista[i], lista[indice]))
                {
                    indice = -1;
                    distanciaMinima = lista[i].distance;
                }
            }
        }
        if(indice == -1)
        {
            return null;
        }
        return lista[indice].collider.gameObject.GetComponent<Interactuable>();
    }

    // Comprueba que un objeto está disponible para interactuar
    private bool _EsInteractuable(RaycastHit objeto)
    {
        Interactuable interfaz = objeto.collider.gameObject.GetComponent<Interactuable>();
        if (interfaz != null)
        {
            return interfaz.EsInteractuable;
        }
        return false;
    }

    // Verifica que se cumplen las reglas de transparencia e interacciones
    private bool _RespetaTransparencias(RaycastHit objeto, RaycastHit referencia)
    {
        Interactuable interactuable = objeto.collider.gameObject.GetComponent<Interactuable>();
        Mirable mirable = objeto.collider.gameObject.GetComponent<Mirable>();
        if(mirable == null || interactuable == null)
        {
            return true;
        }
        return mirable.EsTransparente && interactuable.AtraviesaTransparentes;
    }
}
