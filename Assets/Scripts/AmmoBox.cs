using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] int amountBullet;//количество патронов
    [SerializeField] Box box;
    [SerializeField] Material materialAmmo;
    Inventary inventary;
    AudioSource audioSource;

    public int AmountBullet
    {
        get { return amountBullet; }
        set { amountBullet = value; }
    }

    enum Box
    {
        Bullet,
        Dummy,
        Shot,
    }

    void Start()
    {
        
        inventary = new Inventary();
        audioSource = GetComponent<AudioSource>();
        Color color = Color.red;
        switch (box)
        {
            case Box.Bullet:
                color = Color.red;
                break;
            case Box.Shot:
                color = Color.blue;
                break;
            case Box.Dummy:
                color = Color.green;
                break;
        }
        materialAmmo.color = color;
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
