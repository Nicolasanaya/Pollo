﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadisticasGalpon : MonoBehaviour
{
    #region Variables
    [Header("Agua inicial")]
    [SerializeField] private int agua;
    [Header("Salud inicial")]
    [SerializeField] private int salud;
    [Header("Comida inicial")]
    [SerializeField] private int comida;

    [Header("Tiempo de disminucion de agua")]
    [SerializeField] private float tiempoAgua;
    [Header("Tiempo de disminucion de salud")]
    [SerializeField] private float tiempoSalud;
    [Header("Tiempo de disminucion de comida")]
    [SerializeField] private float tiempoComida;

    [Header("Campo de texto de agua")]
    [SerializeField] private Text txtAgua;
    [Header("Campo de texto de salud")]
    [SerializeField] private Text txtSalud;
    [Header("Campo de texto de comida")]
    [SerializeField] private Text txtComida;

    private float contTiempoAgua;
    private float contTiempoSalud;
    private float contTiempoComida;

    [Header("Canvas tienda")]
    [SerializeField] private Canvas canvasTienda;

    [Header("Cantidad de monedas para iniciar")]
    [SerializeField] private float cantntidadMonedas;
    [Header("Campo de texto de modena inicio")]
    [SerializeField] private Text txtMonedasInicio;
    [Header("Campo de texto de comida")]
    [SerializeField] private Text txtMonedasGalpon;

    private bool banderaTienda = true;

    [Header("Tiempo para madures pollito a pollo")]
    [SerializeField] private float tiempoMadures;
    private float temporizadorMadures;
    #endregion

    #region Variables Compra y venta
    [Header("Canvas comprar pollos")]
    [SerializeField] private Canvas canvasComprarPollos;
    [Header("Canvas vender pollos")]
    [SerializeField] private Canvas canvasVentaPollos;
    [Header("Campo de texto de niveles")]
    [SerializeField] private Text txtNvl;
    private int exp = 1000;
    private int expNvl = 0;
    private int Nvl = 0;
    private bool banderaComprarPollos = true;
    private bool banderaVentaPollos = true;
    private bool banderaPollosVendido = false;

    [Header("Precio por pollo a comprar")]
    [SerializeField] private float precioPolloCompra;
    [Header("precio por pollo a ¨vender")]
    [SerializeField] private float precioPolloVenta;

    [Header("Campo de texto de pollos vivos")]
    [SerializeField] private Text txtPollosVivos;
    [Header("Campo de texto de pollos muertos")]
    [SerializeField] private Text txtPollosMuertos;
    [Header("Campo de texto de buton al vender pollos")]
    [SerializeField] private Text txtVentaPollos;

    private int cantidadPollosVivos = 0;
    private int cantidadPollosMuertos = 0;
    #endregion

    #region Variables de perder
    [Header("Canvas de perder")]
    [SerializeField] private Canvas canvasPerder;
    #endregion

    #region Varbiables de muertes
    [Header("Tiempo entre muertes")]
    [SerializeField] private float tiempoEsperaEntreMuertes;
    private float contTiempoEsperaEntreMuertes;
    #endregion

    void Start()
    {
        #region Inicializar variables
        txtPollosVivos.text = cantidadPollosVivos.ToString();
        txtPollosMuertos.text = cantidadPollosMuertos.ToString();
        txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
        txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
        txtAgua.text = string.Concat(agua, "%");
        txtSalud.text = string.Concat(salud, "%");
        txtComida.text = string.Concat(comida, "%");
        contTiempoAgua = tiempoAgua;
        contTiempoSalud = tiempoSalud;
        contTiempoComida = tiempoComida;
        temporizadorMadures = tiempoMadures;
        Nvl = 1;
        txtNvl.text = Nvl.ToString();
        contTiempoEsperaEntreMuertes = tiempoEsperaEntreMuertes;
        #endregion
    }

    private void FixedUpdate()
    {
        txtPollosVivos.text = cantidadPollosVivos.ToString();
        txtPollosMuertos.text = cantidadPollosMuertos.ToString();
        txtVentaPollos.text = cantidadPollosVivos.ToString();
        if (cantidadPollosVivos > 0)
        {
            ControlAgua();
            ControlSalud();
            ControlComida();

            contTiempoEsperaEntreMuertes -= Time.deltaTime;
            if (contTiempoEsperaEntreMuertes <= 0)
            {
                GestionMuertosPollos();
                contTiempoEsperaEntreMuertes = tiempoEsperaEntreMuertes;
            }

            temporizadorMadures -= Time.deltaTime;
            if (temporizadorMadures <= 0 && !banderaPollosVendido)
            {
                banderaPollosVendido = true;
            }
        }
        Perdiste();
    }

    private void Perdiste()
    {
        if (cantidadPollosVivos == 0 && cantntidadMonedas < 1000)
        {
            canvasPerder.enabled = true;
            Time.timeScale = 0;
        }
    }

    private void GestionNiveles()
    {
        Nvl += 1;
        txtNvl.text = Nvl.ToString();
    }

    #region Gestion galpon
    private void ControlComida()
    {
        contTiempoComida -= Time.deltaTime;
        if (contTiempoComida <= 0 && comida > 0)
        {
            txtComida.text = string.Concat(Convert.ToString(comida -= 1), "%");
            contTiempoComida = tiempoComida;
        }
    }

    private void ControlSalud()
    {
        contTiempoSalud -= Time.deltaTime;
        if (contTiempoSalud <= 0 && salud > 0)
        {
            txtSalud.text = string.Concat(Convert.ToString(salud -= 1), "%");
            contTiempoSalud = tiempoSalud;
        }
    }

    private void ControlAgua()
    {
        contTiempoAgua -= Time.deltaTime;
        if (contTiempoAgua <= 0 && agua > 0)
        {
            txtAgua.text = string.Concat(Convert.ToString(agua -= 1), "%");
            contTiempoAgua = tiempoAgua;
        }
    }

    public void MostrarTienda()
    {
        if (banderaTienda)
        {
            canvasTienda.enabled = true;
            banderaTienda = false;
        }
        else
        {
            canvasTienda.enabled = false;
            banderaTienda = true;
        }

    }

    public void ComprarAgua()
    {
        if (agua <= 99 && cantntidadMonedas > 0)
        {
            agua += 1;
            cantntidadMonedas -= 5;
            txtAgua.text = string.Concat(agua, "%");
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
        }
    }

    public void ComprarSalud()
    {
        if (salud <= 99 && cantntidadMonedas > 0)
        {
            salud += 1;
            cantntidadMonedas -= 5;
            txtSalud.text = string.Concat(salud, "%");
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
        }
    }

    public void ComprarComida()
    {
        if (comida <= 99 && cantntidadMonedas > 0)
        {
            comida += 1;
            cantntidadMonedas -= 5;
            txtComida.text = string.Concat(comida, "%");
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
        }
    }
    #endregion

    #region Venta y Compra pollos    
    public void ComprarMilPollos()
    {
        if (cantidadPollosVivos == 0)
        {
            cantidadPollosVivos = 1000;
            cantntidadMonedas -= (1000 * precioPolloCompra);
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
            txtPollosVivos.text = cantidadPollosVivos.ToString();
        }
    }
    public void ComprarTresMilPollos()
    {
        if (cantidadPollosVivos == 0)
        {
            cantidadPollosVivos = 3000;
            cantntidadMonedas -= (3000 * precioPolloCompra);
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
            txtPollosVivos.text = cantidadPollosVivos.ToString();
        }
    }
    public void ComprarCincoMilPollos()
    {
        if (cantidadPollosVivos == 0)
        {
            cantidadPollosVivos = 5000;
            cantntidadMonedas -= (5000 * precioPolloCompra);
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
            txtPollosVivos.text = cantidadPollosVivos.ToString();
        }
    }
    public void ComprarDiesMilPollos()
    {
        if (cantidadPollosVivos == 0)
        {
            cantidadPollosVivos = 10000;
            cantntidadMonedas -= (10000 * precioPolloCompra);
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
            txtPollosVivos.text = cantidadPollosVivos.ToString();
        }
    }

    public void VenderLote()
    {
        if (cantidadPollosVivos > 0 && banderaPollosVendido)
        {
            cantntidadMonedas += (cantidadPollosVivos * precioPolloVenta);
            cantidadPollosVivos = 0;
            cantidadPollosMuertos = 0;
            txtMonedasGalpon.text = string.Concat("$", cantntidadMonedas);
            txtMonedasInicio.text = string.Concat("$", cantntidadMonedas);
            txtPollosMuertos.text = cantidadPollosMuertos.ToString();
            txtPollosVivos.text = cantidadPollosVivos.ToString();
            temporizadorMadures = tiempoMadures;
            banderaPollosVendido = false;
            GestionNiveles();
        }
    }

    public void TiendaComprarPollos()
    {
        if (banderaComprarPollos)
        {
            canvasComprarPollos.enabled = true;
            banderaComprarPollos = false;
        }
        else
        {
            canvasComprarPollos.enabled = false;
            banderaComprarPollos = true;
        }
    }

    public void TiendaVenderPollos()
    {
        if (banderaVentaPollos)
        {
            canvasVentaPollos.enabled = true;
            banderaVentaPollos = false;
        }
        else
        {
            canvasVentaPollos.enabled = false;
            banderaVentaPollos = true;
        }
    }
    #endregion

    #region Muertes
    public void GestionMuertosPollos()
    {
        if (salud <= 75)
        {
            cantidadPollosMuertos += 3;
            cantidadPollosVivos -= 3;
        }
        else if (salud <= 50)
        {
            cantidadPollosMuertos += 6;
            cantidadPollosVivos -= 6;
        }
        else if (salud <= 25)
        {
            cantidadPollosMuertos += 9;
            cantidadPollosVivos -= 9;
        }
        else if (salud == 0)
        {
            cantidadPollosMuertos += 12;
            cantidadPollosVivos -= 12;
        }

        if (comida <= 75)
        {
            cantidadPollosMuertos += 1;
            cantidadPollosVivos -= 1;
        }
        else if (comida <= 50)
        {
            cantidadPollosMuertos += 2;
            cantidadPollosVivos -= 2;
        }
        else if (comida <= 25)
        {
            cantidadPollosMuertos += 3;
            cantidadPollosVivos -= 3;
        }
        else if (comida == 0)
        {
            cantidadPollosMuertos += 5;
            cantidadPollosVivos -= 5;
        }

        if (agua <= 75)
        {
            cantidadPollosMuertos += 1;
            cantidadPollosVivos -= 1;
        }
        else if (agua <= 50)
        {
            cantidadPollosMuertos += 2;
            cantidadPollosVivos -= 2;
        }
        else if (agua <= 25)
        {
            cantidadPollosMuertos += 3;
            cantidadPollosVivos -= 3;
        }
        else if (agua == 0)
        {
            cantidadPollosMuertos += 5;
            cantidadPollosVivos -= 5;
        }
    }
    #endregion
}
