using UnityEngine;

public class ObjetoConTexto : Objeto, IInteractuable
{
    public string Nota; // texto de indole narrativo
    private bool _Interactuado; // se esta mostrando la nota por pantalla

    public void AlInteractuar(GameObject objeto)
    {
        if (_Interactuado)
        {
            DejarDeLeerNota();
        }
        else
        {
            LeerNota();
        }   
    }
    public override void AlDejarDeMirar()
    {
        base.AlDejarDeMirar();
        DejarDeLeerNota();
    }

    private void LeerNota()
    {
        _Interactuado = true;
        GestorInterfaz.Instancia.MostrarNota(Nota);
    }

    private void DejarDeLeerNota()
    {
        _Interactuado = false;
        GestorInterfaz.Instancia.OcultarNota();

    }
}
