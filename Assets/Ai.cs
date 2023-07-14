using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    [SerializeField] private int pushForce;
    private Rigidbody EnemyRb;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Enemy_Enemy_Collision(other);
        EnemyDie(other);
        FoodTrigger(other);
    }

    public void Enemy_Enemy_Collision(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("enemyEnemy");
            EnemyRb.AddForce(-transform.forward * pushForce * 4, ForceMode.Impulse);
        }
    }
    public void EnemyDie(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }
    public void FoodTrigger(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            print("Foood");
            temp = transform.localScale;
            temp.x += 1f;
            temp.y += 0.2f;
            temp.z = 1f;
            transform.localScale = temp;
            other.gameObject.SetActive(false);
        }
    }
}
