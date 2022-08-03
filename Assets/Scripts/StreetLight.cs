using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float flickerFrequency;//������� ��������
    [SerializeField] float flickerAlarmFrequency;//������� �������� ����� ���� ����� ������
    [SerializeField] float minIntensivity;//����������� �������������
    [SerializeField] float maxIntensivity;//������������ �������������
    [SerializeField] float correctionForPointLight;//��������� ������������� ��� ��������� �����
    
    float rangeLightSpot;//�������� ����������
    float rangeLightPoint;
    Light lightCompPoint;
    Light lightCompSpot;
    AudioSource audioSource;
    Inventary inventary;
    public bool recoveryOn;//����� �� ������������ �������� ��

    void Start()
    {        
        inventary = new Inventary();
        audioSource = GetComponent<AudioSource>();
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
        if (other.gameObject.tag == "enemy") 
        {
            StartCoroutine(EnemyAlarm());
            recoveryOn = false;
        } 

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            recoveryOn = true;
            StartCoroutine(HealthRecovery());//�������� �������������� �������� �� ��� ������

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            recoveryOn = false;//��������� �������������� �������� �� ��� ������

        }
        if (other.gameObject.tag == "enemy")
        {
            recoveryOn = true;
        }
    }

    IEnumerator EnemyAlarm()//���� ���� ����� ������
    {
        
        float rnd = Random.Range(2f, flickerAlarmFrequency);
        lightCompSpot.range = 0;
        lightCompPoint.range = 0;
        yield return new WaitForSeconds(rnd);
        lightCompSpot.range = rangeLightSpot;
        lightCompPoint.range = rangeLightPoint;
        audioSource.PlayOneShot(audioClip);
        StopCoroutine(EnemyAlarm());
    }

    IEnumerator HealthRecovery()//�������������� ��������
    {
        while (recoveryOn)
        {
            inventary.HealthRecovery();
            yield return new WaitForSeconds(inventary.TimeRecovery);
        }
        StopCoroutine(HealthRecovery());
    }
}
