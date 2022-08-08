using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour
{
    [SerializeField] GameObject boxObj;
    [SerializeField] float spawnTime;//время через которое происходит спавн боксов с боеприпасами
    GameObject box;
    
    void Start()
    {
        StartCoroutine(SpawnAmmoBox());
    }

    IEnumerator SpawnAmmoBox()
    {
        while (true)
        {
            box = Instantiate(boxObj);
            box.transform.position = transform.position;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
