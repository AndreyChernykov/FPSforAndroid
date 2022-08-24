using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject[] spawnArray;
    [SerializeField] float spawnTime;//время через которое происходит спавн объектов
    GameObject obj;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            obj = Instantiate(spawnArray[Random.Range(0, spawnArray.Length)]);
            obj.transform.position = transform.position;
            yield return new WaitForSeconds(spawnTime);
        }

    }
}
