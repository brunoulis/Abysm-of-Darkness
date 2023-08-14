using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider; // Referencia al componente Slider

    void Start()
    {
        // slider = GetComponent<Slider>(); // Cambia esta línea

        // Verifica si la referencia al slider es nula y asígnala si es necesario
        if (!slider) 
            slider = GetComponent<Slider>();

        // Muestra un mensaje de error si no se encuentra el componente Slider
        if (slider == null)
        {
            Debug.LogError("No se ha encontrado el componente Slider en el objeto " + gameObject.name);
        }
    }

    // Establece el valor máximo del slider (que representa la vida máxima)
    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    // Actualiza el valor actual del slider (que representa la vida actual)
    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    // Inicializa la barra de vida estableciendo los valores máximo y actual
    public void InicializarBarraDeVida(float cantidadVida)
    {
        // Verifica si la referencia al slider es nula y asígnala si es necesario
        if (!slider) 
            slider = GetComponent<Slider>();

        // Establece los valores máximo y actual del slider
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
