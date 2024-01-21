using System.Collections.Generic;
using UnityEngine;

public class RedEnemyPoolerScript : MonoBehaviour
{
    public static RedEnemyPoolerScript PoolerRE; //Reference to this class
    public GameObject pooledObjectRE; //The spawned object
    public int pooledAmountRE; //The amount of objects in this pool
    public bool WillGrowRE; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsRE;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        pooledObjectsRE = new List<GameObject>();

        PoolerRE = this;
        for (int i = 0; i < pooledAmountRE; i++)
        {
            GameObject obj = Instantiate(pooledObjectRE);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsRE.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object 
    public GameObject GetPooledObjectRE()
    {
        for (int i = 0; i < pooledObjectsRE.Count; i++)
        {
            if (!pooledObjectsRE[i].activeInHierarchy)
            {
                return pooledObjectsRE[i];
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (WillGrowRE == true)
        {
            GameObject obj = Instantiate(pooledObjectRE);
            pooledObjectsRE.Add(obj);
            return obj;
        }

        //If WillGrowRB is false and there isnt enough objects it returns null to not cause an error
        return null;
    }

    /*
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var gameObject in pooledObjects)
            {
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                Transform tf = gameObject.GetComponent<Transform>();

                rb.velocity *= -1f;
            }
        }
    }
    */
}
