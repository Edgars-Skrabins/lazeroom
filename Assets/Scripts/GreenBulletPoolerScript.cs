using System.Collections.Generic;
using UnityEngine;

public class GreenBulletPoolerScript : MonoBehaviour
{
    public static GreenBulletPoolerScript PoolerGB; //Reference to this class
    public GameObject pooledObjectGB; //The spawned object
    public int pooledAmountGB; //The amount of objects in this pool
    public bool WillGrowGB; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsGB;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        pooledObjectsGB = new List<GameObject>();

        PoolerGB = this;
        for (int i = 0; i < pooledAmountGB; i++)
        {
            GameObject obj = Instantiate(pooledObjectGB);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsGB.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object 
    public GameObject GetPooledObjectGB()
    {
        for (int i = 0; i < pooledObjectsGB.Count; i++)
        {
            if (!pooledObjectsGB[i].activeInHierarchy)
            {
                return pooledObjectsGB[i];
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (WillGrowGB == true)
        {
            GameObject obj = Instantiate(pooledObjectGB);
            pooledObjectsGB.Add(obj);
            return obj;
        }

        //If WillGrowRB is false and there isnt enough objects it returns null to not cause an error
        return null;
    }
}
