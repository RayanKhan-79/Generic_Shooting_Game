using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WorldBounds.HasLeftGameWorld(gameObject))
            Destroy(gameObject);
    }
}
