using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;
    [SerializeField] float flickerFrequency;//частота мерцания
    [SerializeField] float flickerAlarmFrequency;//частота моргания когда враг около фонаря
    [SerializeField] float minIntensivity;//минимальная интенсивность
    [SerializeField] float maxIntensivity;//максимальная интенсивность
    [SerializeField] float correctionForPointLight;//коррекция интенсивности для точетного света
    
    float rangeLightSpot;//диапазон светимости
    float rangeLightPoint;
    Light lightCompPoint;
    Light lightCompSpot;

    void Start()
    {        
        lightCompPoint = pointLight.GetComponent<Light>();
        lightCompSpot = spotLight.GetComponent<Light>();

        rangeLightSpot = lightCompSpot.GetComponent<Light>().range;
        rangeLightPoint = lightCompPoint.GetComponent<Light>().range;

        StartCoroutine(IntensivityLight());
        

    }

    IEnumerator IntensivityLight()//мерцание фонаря
    {
        while(true)
        {           
            float rnd = Random.Range(minIntensivity, maxIntensivity);
            lightCompPoint.intensity = rnd - correctionForPointLight;
            lightCompSpot.intensity = rnd;
            yield return new WaitForSeconds(flickerFrequency);            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "enemy") StartCoroutine(EnemyAlarm());
        
    }

    IEnumerator EnemyAlarm()//если враг около фонаря
    {

        float rnd = Random.Range(2f, flickerAlarmFrequency);
        lightCompSpot.range = 0;
        lightCompPoint.range = 0;
        yield return new WaitForSeconds(rnd);
        lightCompSpot.range = rangeLightSpot;
        lightCompPoint.range = rangeLightPoint;
        StopCoroutine(EnemyAlarm());
    }
}
