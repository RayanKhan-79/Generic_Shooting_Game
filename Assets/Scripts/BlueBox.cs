using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    [SerializeField]
    private string bulletTag;

    [SerializeField]
    private int health = 100;

    // Update is called once per frame
    void Update()
    {
        DestroySelf();
    }

    void DestroySelf()
    {
        if (WorldBounds.HasLeftGameWorld(gameObject))
            Destroy(gameObject);

        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            health -= collision.gameObject.GetComponent<Bullet>().Damage;
        }
    }
}
