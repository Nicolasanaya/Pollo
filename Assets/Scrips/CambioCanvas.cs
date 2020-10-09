using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCanvas : MonoBehaviour
{
    [Header("Canvas inicio")]
    [SerializeField] private Canvas canvasInicio;
    [Header("Canvas galpon")]
    [SerializeField] private Canvas canvasGalpon;
    [Header("Canvas tienda")]
    [SerializeField] private Canvas canvasTienda;
    [Header("Canvas comprar pollos")]
    [SerializeField] private Canvas canvasComprarPollos;
    [Header("Canvas vender pollos")]
    [SerializeField] private Canvas canvasVenderPollos;

    public void CanvasInicio()
    {
        canvasInicio.enabled = true;
        canvasGalpon.enabled = false;
        canvasTienda.enabled = false;
        canvasComprarPollos.enabled = false;
        canvasVenderPollos.enabled = false;
    }

    public void CanvasGalpon()
    {
        canvasGalpon.enabled = true;
        canvasInicio.enabled = false;
    }
}
