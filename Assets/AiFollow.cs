using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{

    public float MaxSpeed;
    private float Speed;
    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;
    public Rigidbody rb;
    public GameObject Target;
    private bool seePlayer;
    // Start is called before the first frame update
    void Start()
    {
        Speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DetectAtarget();
    }

    public void DetectAtarget()
    {
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {

                if (HitCollider == GetComponent<Collider>()) // Skip the enemy's own collider
                    continue;


                if (HitCollider.tag == "Player" || HitCollider.tag == "Enemy")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                    

                }
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player" && Hit.collider.tag != "Enemy")
                {
                    seePlayer = false;
                }
                else
                {
                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;
                    Vector3 Move = new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
                    rb.velocity = Move;
                    transform.forward = Move;
                }
            }
        }
    }
}
