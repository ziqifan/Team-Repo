using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //a pool for a game object with certain size
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    //Create the list and dictionary for the pool
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    // Start is called before the first frame update
    void Start()
    {
        //put all pools into pool dictionary
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject ob = Instantiate(pool.prefab);
                ob.SetActive(false);
                objectPool.Enqueue(ob);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }

    //using certain pool inside the pool dictionary to spawn object
    public GameObject SpawnObject (string tag, Vector3 pos, Quaternion rot)
    {
        if(!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " not exist!");
            return null;
        }

        GameObject objectGoSpawn = poolDict[tag].Dequeue();

        objectGoSpawn.SetActive(true);
        objectGoSpawn.transform.position = pos;
        objectGoSpawn.transform.rotation = rot;

        poolDict[tag].Enqueue(objectGoSpawn);

        return objectGoSpawn;
    }

}
