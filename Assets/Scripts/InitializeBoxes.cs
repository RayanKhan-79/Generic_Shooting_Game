using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class InitializeBoxes : MonoBehaviour
{
    [SerializeField]
    List<GameObject> boxPrefabs = new List<GameObject>();

    [SerializeField]
    int numberOfBoxes = 0;

    private void Awake()
    {
        WorldBounds.Initialize(GetComponent<BoxCollider>().bounds);
    }

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < numberOfBoxes; i++)
        {
            Vector3 pos;
            do
            {
                pos = new Vector3(
                    Random.Range(WorldBounds.min.x, WorldBounds.max.x),
                    1,
                    Random.Range(WorldBounds.min.z, WorldBounds.max.z)
                );

            } while (Physics.CheckBox(pos, Vector3.one * 0.5f));

            int index = Random.Range(0, boxPrefabs.Count);
            GameObject box = Instantiate<GameObject>(boxPrefabs[index], pos, Quaternion.identity);
        }
    }
}
