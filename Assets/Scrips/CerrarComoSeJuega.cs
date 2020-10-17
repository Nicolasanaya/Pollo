using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarComoSeJuega : MonoBehaviour
{
    [Header("Canvas como se juega")]
    [SerializeField] private Canvas canvasComoSeJuega;

    public void CerrarElComoSeJuega()
    {
        canvasComoSeJuega.enabled = false;
    }
}
