using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollison : MonoBehaviour
{
    private PlayerController Pc;
    private Rigidbody Prb;
    [SerializeField] public int pushForce;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        Pc = GetComponent<PlayerController>();
        Prb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        EnemyPlayerCol(other);
        foodCollision(other);
        PlayerDie(other);
    }
    public void EnemyPlayerCol(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Pc.speed = 0;
            Prb.AddForce(-transform.forward * pushForce * 1, ForceMode.Impulse);

            StartCoroutine(StopThePlayer());


            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            otherRb.AddForce(transform.forward * pushForce * 4, ForceMode.Impulse);

        }
    }

    public void foodCollision(Collider other)
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
    public void PlayerDie(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator StopThePlayer()
    {
        yield return new WaitForSeconds(0.3f);
        Pc.speed = 5;
        Prb.velocity = Vector3.zero;
    }
}
