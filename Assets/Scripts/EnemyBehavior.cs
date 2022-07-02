using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int health = 10;
    int damage;
    int speed;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        MainController.actionList.Add(Behavior);
        isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            if (!isAlive) { OnDestroy(); }
            int dmg = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= dmg;
            
        }
    }

    public void Behavior()
    {
        if(health < 1)
        {
            isAlive = false;
            
        }
        

    }

    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        Destroy(gameObject);
        
        
    }
}
