using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public void PantallaCompleta(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void Volumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
