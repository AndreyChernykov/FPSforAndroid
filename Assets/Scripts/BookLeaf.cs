using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLeaf : MonoBehaviour
{
    Inventary inventary;
    AudioSource audioSource;

    private void Start()
    {
        inventary = new Inventary();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            inventary.BookLeaf = 1;
            Debug.Log(inventary.BookLeaf);
            Invoke("OnDestroy", 1);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
