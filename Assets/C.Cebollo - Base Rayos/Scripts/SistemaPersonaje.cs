using UnityEngine;

[RequireComponent(typeof(SistemaApuntado), typeof(SistemaGravedad), typeof(SistemaControles))]



public class SistemaPersonaje : MonoBehaviour
{
    public SistemaGravedad Gravedad;
    public SistemaControles Controles;
    public SistemaApuntado Apuntado;



    private void Awake()
    {
        Gravedad = GetComponent<SistemaGravedad>();
        Controles = GetComponent<SistemaControles>();
        Apuntado = GetComponent<SistemaApuntado>();
    }
}
