using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    //code referenced from https://www.raywenderlich.com/847-object-pooling-in-unity

    public List<GameObject> spawnedObjs;
    public GameObject cube;
    public int amount;

    //public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObjs = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject myCube = (GameObject)Instantiate(cube);
            myCube.SetActive(false);
            spawnedObjs.Add(myCube); 
        }
    }
    
    public GameObject getPooledObj()
    {
        for (int i =0; i < spawnedObjs.Count; i++)
        {
            if (!spawnedObjs[i].activeInHierarchy)
            {
                return spawnedObjs[i];
            }
        }

        return null;

    }


    // Update is called once per frame
    void Update()
    {
        //this is wrong, needs to instantiate and destory for the object pooling
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Instantiate(cube);
        //}
        if (spawnedObjs.Count <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
