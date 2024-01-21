using System.Collections.Generic;
using UnityEngine;

public class BlueBulletPoolerScript : MonoBehaviour
{
    public static BlueBulletPoolerScript PoolerBB; //Reference to this class
    public GameObject pooledObjectBB; //The spawned object
    public int pooledAmountBB; //The amount of objects in this pool
    public bool WillGrowBB; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsBB;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        pooledObjectsBB = new List<GameObject>();

        PoolerBB = this;
        for (int i = 0; i < pooledAmountBB; i++)
        {
            GameObject obj = Instantiate(pooledObjectBB);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsBB.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object
    public GameObject GetPooledObjectBB()
    {
        foreach (GameObject t in pooledObjectsBB)
        {
            if (!t.activeInHierarchy)
            {
                return t;
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (!WillGrowBB) return null;
        GameObject obj = Instantiate(pooledObjectBB);
        pooledObjectsBB.Add(obj);
        return obj;

        //If WillGrowRB is false and there isnt enough objects it returns null to not cause an error
    }
}
