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

    // Start is called before the first frame update
    void Start()
    {
        List <GameObject> allPickUps = new List<GameObject>();

        List <GameObject> cubes = new List<GameObject>();
        List <GameObject> pills = new List<GameObject>();
        List <GameObject> cylinders = new List<GameObject>();

        CreateObjects(3, "cube" , cubes, prefabCube);
        CreateObjects(3, "pill", pills, prefabPill);
        CreateObjects(2, "cyl", cylinders, prefabCylinder);
        

        // x (11 -> 30)
        // z (20 -> 35) 

        // place the cubes 
        cubes[0].transform.position = new Vector3(14f, 1.2f, 29.2f);
        cubes[1].transform.position = new Vector3(20f, 1.2f, 22f);
        cubes[2].transform.position = new Vector3(27.48f, 1.2f, 20.62f);
        // place the pills
        pills[0].transform.position = new Vector3(15f, 1.2f, 33f);
        pills[1].transform.position = new Vector3(25f, 1.2f, 24f);
        pills[2].transform.position = new Vector3(18f, 1.2f, 33f);
        // place the cylinders 
        cylinders[0].transform.position = new Vector3(20f, 1.2f, 35f);
        cylinders[1].transform.position = new Vector3(26f, 1.2f, 29f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
