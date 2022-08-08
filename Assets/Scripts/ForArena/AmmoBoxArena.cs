using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxArena : MonoBehaviour
{
    [SerializeField] GameObject ammoPref;
    private float posY = 0.2f;

    void Start()
    {
        GameObject ammo = Instantiate(ammoPref);
        ammo.transform.SetParent(gameObject.transform);
        ammo.transform.position = new Vector3(transform.position.x, transform.position.y + posY, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
