using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWeatherController : MonoBehaviour
{
    public enum WeatherMode { Random, Manual }

    [Header("Wwise RTPC")]
    public AK.Wwise.RTPC weatherRTPC;   // Ahora podés arrastrar el RTPC desde el Wwise Picker

    [Header("Configuración de clima")]
    [Range(0, 100)]
    public int startValue = 0;          // Valor inicial ajustable
    public float stepDelay = 0.1f;      // Tiempo entre pasos (segundos)
    public int minValue = 0;            // Límite mínimo
    public int maxValue = 100;          // Límite máximo

    [Header("Modo de control")]
    public WeatherMode mode = WeatherMode.Random;

    [Header("Aleatorio")]
    public float changeInterval = 5f;   // Cada cuánto tiempo elegir destino aleatorio

    [Header("Manual")]
    [Range(0, 100)]
    public int manualTarget = 50;       // Valor objetivo cuando está en modo manual

    private int targetValue;            // Valor objetivo actual
    private int currentValue;           // Valor actual
    private float timeSinceChange;
    private float timeSinceStep;

    void Start()
    {
        currentValue = startValue;
        targetValue = startValue;

        // Seteamos el valor inicial en Wwise
        if (weatherRTPC != null)
            weatherRTPC.SetGlobalValue(currentValue);
    }

    void Update()
    {
        // Si está en modo aleatorio: cada cierto tiempo elige un nuevo destino
        if (mode == WeatherMode.Random)
        {
            timeSinceChange += Time.deltaTime;
            if (timeSinceChange >= changeInterval)
            {
                targetValue = Random.Range(minValue, maxValue + 1);
                timeSinceChange = 0f;
            }
        }
        else if (mode == WeatherMode.Manual)
        {
            // En manual, el target es el que definimos en el inspector o desde otro script
            targetValue = Mathf.Clamp(manualTarget, minValue, maxValue);
        }

        // Transición suave (de a 1 cada "stepDelay" segundos)
        timeSinceStep += Time.deltaTime;
        if (timeSinceStep >= stepDelay)
        {
            timeSinceStep = 0f;

            if (currentValue < targetValue)
            {
                currentValue++;
                if (weatherRTPC != null)
                    weatherRTPC.SetGlobalValue(currentValue);
            }
            else if (currentValue > targetValue)
            {
                currentValue--;
                if (weatherRTPC != null)
                    weatherRTPC.SetGlobalValue(currentValue);
            }
        }
    }

    void OnValidate()
    {
        // Ajuste inicial desde el Inspector
        currentValue = startValue;
        targetValue = startValue;
        if (Application.isPlaying && weatherRTPC != null)
        {
            weatherRTPC.SetGlobalValue(currentValue);
        }
    }
}