using UnityEngine;

public class InteraccionEjemplo : Interactuable
{
    private void Start()
    {
        // Interactuable
        Nombre = gameObject.name;

        if(EsInteractuable && EsTransparente)
        {
            Debug.Log("Aunque " + Nombre + "sea transparente, se interactuará con él.");
        }
    }
    // Definir interacción
    public override void Interaccion()
    {
        print(Nombre);
        return;
    }
}
