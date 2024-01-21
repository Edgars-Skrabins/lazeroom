using System.Collections.Generic;
using UnityEngine;

public class RedBulletPoolerScript : MonoBehaviour
{
    public static RedBulletPoolerScript PoolerRB; //Reference to this class
    public GameObject pooledObjectRB; //The spawned object
    public int pooledAmountRB; //The amount of objects in this pool
    public bool WillGrowRB; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsRB;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        pooledObjectsRB = new List<GameObject>();

        PoolerRB = this;
        for (int i = 0; i < pooledAmountRB; i++)
        {
            GameObject obj = Instantiate(pooledObjectRB);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsRB.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object
    public GameObject GetPooledObjectRB()
    {
        for (int i = 0; i < pooledObjectsRB.Count; i++)
        {
            if (!pooledObjectsRB[i].activeInHierarchy)
            {
                return pooledObjectsRB[i];
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (WillGrowRB)
        {
            GameObject obj = Instantiate(pooledObjectRB);
            pooledObjectsRB.Add(obj);
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
