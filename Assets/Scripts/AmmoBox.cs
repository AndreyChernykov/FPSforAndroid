using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] int amountBullet;//количество патронов
    Inventary inventary;
    AudioSource audioSource;

    enum Box
    {
        Bullet,
        Dummy,
        Shot,
    }
    [SerializeField] Box box;

    void Start()
    {
        inventary = new Inventary();  
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (box)
            {
                case Box.Bullet:
                    inventary.AddBullet(amountBullet);
                    break;
                case Box.Dummy:
                    inventary.AddDummy(amountBullet);
                    break;
                case Box.Shot:
                    inventary.AddShot(amountBullet);
                    break;
            }

            audioSource.Play();
            Invoke("OnDestroy", 0.3f);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
