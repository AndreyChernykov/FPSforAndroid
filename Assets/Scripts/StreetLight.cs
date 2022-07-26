using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;
    [SerializeField] float flickerFrequency;//������� ��������
    [SerializeField] float flickerAlarmFrequency;//������� �������� ����� ���� ����� ������
    [SerializeField] float minIntensivity;//����������� �������������
    [SerializeField] float maxIntensivity;//������������ �������������
    [SerializeField] float correctionForPointLight;//��������� ������������� ��� ��������� �����
    
    float rangeLightSpot;//�������� ����������
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

    IEnumerator IntensivityLight()//�������� ������
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

    IEnumerator EnemyAlarm()//���� ���� ����� ������
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
