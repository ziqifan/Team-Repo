using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
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

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    // Start is called before the first frame update
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject ob = Instantiate(pool.prefab);
                objectPool.Enqueue(ob);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }

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
