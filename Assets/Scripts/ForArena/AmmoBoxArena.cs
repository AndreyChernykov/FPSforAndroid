using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxArena : MonoBehaviour
{
    [SerializeField] GameObject[] ammoType;    
    [SerializeField] int minCartriges;
    [SerializeField] int maxCartriges;
    [SerializeField] AudioClip crashedAudio;
    AudioSource audioSource;
    GameObject ammo;
    private float posY = 0.2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject ammoPref = ammoType[Random.Range(0, ammoType.Length)];
        ammo = Instantiate(ammoPref);
        ammo.GetComponent<AmmoBox>().AmountBullet = Random.Range(minCartriges, minCartriges + 1);
        ammo.transform.SetParent(gameObject.transform);
        ammo.transform.position = new Vector3(transform.position.x, transform.position.y + posY, transform.position.z);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {

            ammo.transform.parent = null;
            ammo.AddComponent<Rigidbody>();
            audioSource.PlayOneShot(crashedAudio);

            Invoke("OnDestroy", 0.3f);

        }
        else
        {
            audioSource.Play();
        }

    }

    private void OnDestroy()
    {
        
        Destroy(gameObject);
    }
}
