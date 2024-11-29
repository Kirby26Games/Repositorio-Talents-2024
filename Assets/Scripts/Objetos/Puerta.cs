using UnityEngine;

public class Puerta : Objeto,IActivable
{
    [Header("Configuración de Movimiento")]
    public bool MovimientoConstante = false; // Si debe moverse constantemente
    public float Velocidad = 1f;
    public Vector3 Direccion;

    [Header("Datos")]
    private Vector3[] Posiciones = new Vector3[2];
    private bool DeboMoverme;
    private int Indice;

    private void Start()
    {
        Posiciones[1] = transform.localPosition;
        Posiciones[0] = transform.localPosition + Direccion;
    }

    private void Update()
    {
        if (!DeboMoverme)
        {
            return;
        }
        //Aqui debo moverme hacia la direccion objetivo a la Velocidad
        //MoveTowards mueve en direccion a un objeto(Origen,Destino,Velocidad)
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, Posiciones[Indice], Velocidad * Time.deltaTime);
        CalcularDistancia();
    }

    public void CalcularDistancia()
    {
        //si he lllegado a la posicion objetivo, dejo de poder moverme y continuo
        if (Vector3.Distance(transform.localPosition, Posiciones[Indice]) <= 0.01f)
        {
            transform.localPosition = Posiciones[Indice];
            DeboMoverme = false;
            AvanzarIndice();
        }
    }
    public void AvanzarIndice()
    {
        Indice++;
        if(Indice>=Posiciones.Length)
        {
            Indice = 0;
        }
    }
    public void AlActivar()
    {
        DeboMoverme = true;
    }
}
