using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private string boxTag;

    [SerializeField]
    private int damage = 35;

    private Vector3 direction;
    private const float forceMultiplier = 1000;

    private GameObject target;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustTrajectory();
        Clamp();
    }

    void AdjustTrajectory()
    {
        if (target != null)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            direction = target.transform.position - transform.position;
        }
        else
            Destroy(gameObject);
    }

    void Clamp()
    {
        if (WorldBounds.HasLeftGameWorld(gameObject))
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(boxTag))
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(direction * forceMultiplier);
    }
    public GameObject Target
    {
        get => target;
        set
        {
            if (target == null)
            {
                target = value;
                direction = target.transform.position - transform.position;
            }
        }
    }

    public int Damage
    {
        get => damage;
    }
}
