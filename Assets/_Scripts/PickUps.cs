using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject prefabCube;
    public GameObject prefabPill;
    public GameObject prefabCylinder;
    
    void CreateObjects(int amount , string tag , List<GameObject> list , GameObject prefab)
    {
        for (int i = 0; i < amount; i++)
        {
            list.Add(Instantiate(prefab));
            for (int j = 0; j < i+1; j++)
            {
                list[j].gameObject.tag = tag;
            }
        }
    }
    
    void placeObject(List <GameObject> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = new Vector3(Random.Range(8, 33), 1.2f, Random.Range(3, 43));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        List <GameObject> cubes = new List<GameObject>();
        List <GameObject> pills = new List<GameObject>();
        List <GameObject> cylinders = new List<GameObject>();

        CreateObjects(3, "cube" , cubes, prefabCube);
        CreateObjects(3, "pill", pills, prefabPill);
        CreateObjects(2, "cyl", cylinders, prefabCylinder);

        placeObject(cubes);
        placeObject(pills);
        placeObject(cylinders);

    }
}
