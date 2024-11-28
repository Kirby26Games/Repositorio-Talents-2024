public class ObjetoConTexto : Objeto, IInteractuable
{
    public string Nota; // texto de indole narrativo
    private bool _Interactuado; // se esta mostrando la nota por pantalla

    public void AlInteractuar()
    {
        if (_Interactuado)
        {
            _DejarDeLeerNota();
        }
        else
        {
            _LeerNota();
        }   
    }
    public override void AlDejarDeMirar()
    {
        base.AlDejarDeMirar();
        _DejarDeLeerNota();
    }

    private void _LeerNota()
    {
        _Interactuado = true;
        GestorInterfaz.Instancia.MostrarNota(Nota);
    }

    private void _DejarDeLeerNota()
    {
        _Interactuado = false;
        GestorInterfaz.Instancia.OcultarNota();

    }
}
