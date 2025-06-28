using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    private string bulletTag;

    [SerializeField]
    private string boxTag;

    [SerializeField]
    private float radius;
    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        // Ensure only one bullet exists at a time
        if (GameObject.FindGameObjectsWithTag(bulletTag).Length != 0)
            return;

        GameObject target = FindTarget(radius);
        if (target == null)
           return;

        Vector3 spawnPosition = Vector3.up + transform.position + 3 * transform.forward;
        GameObject bullet = Instantiate<GameObject>(
            bulletPrefab,
            spawnPosition,
            Quaternion.identity
        );
        bullet.GetComponent<Bullet>().Target = target;
    }

    private bool IsInView(GameObject target)
    {
        Vector3 view = Camera.main.WorldToViewportPoint(target.transform.position);

        return view.x >= 0
            && view.x <= 1
            && view.y >= 0
            && view.y <= 1
            && view.z > 0;
    }

    private bool isWithinRadius(GameObject target)
    {
        return Vector3.Distance(target.transform.position, transform.position) < radius;
    }
    public GameObject FindTarget(float radius)
    {
        List<GameObject> targets = new List<GameObject>();

        targets.Clear();
        targets.AddRange(GameObject.FindGameObjectsWithTag(boxTag));
        targets = targets
            .Where(isWithinRadius)
            .Where(IsInView)
            .ToList();

        if (targets.Count > 0)
        {
            GameObject target = targets[0];
            float distance = Vector3.Distance(target.transform.position, transform.position);

            foreach (GameObject newTarget in targets)
            {
                float current = Vector3.Distance(newTarget.transform.position, transform.position);
                if (current < distance)
                {
                    distance = current;
                    target = newTarget;
                }
            }

            return target;
        }
        else
        {
            return null;
        }
    }
}
