using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxArena : MonoBehaviour
{
    [SerializeField] GameObject[] ammoType;    
    [SerializeField] int minCartriges;
    [SerializeField] int maxCartriges;
    GameObject ammo;
    private float posY = 0.2f;

    void Start()
    {
        GameObject ammoPref = ammoType[Random.Range(0, ammoType.Length)];
        ammo = Instantiate(ammoPref);
        //int amountBullet = ammo.GetComponent<AmmoBox>().AmountBullet;
        ammo.GetComponent<AmmoBox>().AmountBullet = Random.Range(minCartriges, minCartriges + 1);
        ammo.transform.SetParent(gameObject.transform);
        ammo.transform.position = new Vector3(transform.position.x, transform.position.y + posY, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            ammo.transform.parent = null;
            OnDestroy();
            
        }
    }

    private void OnDestroy()
    {
        
        Destroy(gameObject);
    }
}
