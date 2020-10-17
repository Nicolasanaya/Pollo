using System;
using UnityEngine;
using UnityEngine.UI;

public class EdadPollo : MonoBehaviour
{
    [Header("Pollito")]
    [SerializeField] private GameObject pollito;
    [Header("Pollo")]
    [SerializeField] private GameObject pollo;

    [Header("Tiempo para madures pollito a pollo")]
    [SerializeField] private float tiempoMadures;

    [Header("Campo de texto de pollos vivos")]
    [SerializeField] private Text txtPollosVivos;

    private float temporizadorMadures;
    private bool banderaGrande = true;
    private bool banderaOcultarMostrar = true;

    void Start()
    {
        temporizadorMadures = tiempoMadures;
    }

    private void FixedUpdate()
    {
        if (Convert.ToInt32(txtPollosVivos.text) > 0)
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
    }

    public void ComprarPollito()
    {
        pollito.SetActive(true);
        pollo.SetActive(false);
        banderaOcultarMostrar = false;
    }

    public void VenderPollos()
    {
        pollo.SetActive(false);
        pollito.SetActive(false);
        temporizadorMadures = tiempoMadures;
        banderaGrande = true;
        banderaOcultarMostrar = true;
    }

    public void MostrarOcultarPollo()
    {
        if (Convert.ToInt32(txtPollosVivos.text) > 0 && banderaOcultarMostrar)
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
        else if (Convert.ToInt32(txtPollosVivos.text) > 0 && !banderaOcultarMostrar)
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
