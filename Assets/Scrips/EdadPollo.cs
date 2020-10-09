using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdadPollo : MonoBehaviour
{
    [Header("Pollito")]
    [SerializeField] private GameObject pollito;
    [Header("Pollo")]
    [SerializeField] private GameObject pollo;

    [Header("Tiempo para madures pollito a pollo")]
    [SerializeField] private float tiempoMadures;
    private float temporizadorMadures;
    private bool banderaGrande = true;
    private bool banderaOcultarMostrar = true;

    // Start is called before the first frame update
    void Start()
    {
        temporizadorMadures = tiempoMadures;
    }

    private void FixedUpdate()
    {
        temporizadorMadures -= Time.deltaTime;
        if (temporizadorMadures <= 0 && banderaGrande)
        {
            pollito.SetActive(false);
            pollo.SetActive(true);
            temporizadorMadures = tiempoMadures;
            banderaGrande = false;
        }
    }

    public void MostrarOcultarPollo()
    {
        if (banderaOcultarMostrar)
        {
            if (banderaGrande)
            {
                pollito.SetActive(true);
            }
            else
            {
                pollo.SetActive(true);
            }
            banderaOcultarMostrar = false;
        }
        else
        {
            if (banderaGrande)
            {
                pollito.SetActive(false);
            }
            else
            {
                pollo.SetActive(false);
            }
            banderaOcultarMostrar = true;
        }
    }
}
