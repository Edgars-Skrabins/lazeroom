using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyPoolerScript : MonoBehaviour
{
    public static GreenEnemyPoolerScript PoolerGE; //Reference to this class
    public GameObject pooledObjectGE; //The spawned object
    public int pooledAmountGE; //The amount of objects in this pool
    public bool WillGrowGE; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsGE;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        pooledObjectsGE = new List<GameObject>();

        PoolerGE = this;
        for (int i = 0; i < pooledAmountGE; i++)
        {
            GameObject obj = Instantiate(pooledObjectGE);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsGE.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object
    public GameObject GetPooledObjectGE()
    {
        for (int i = 0; i < pooledObjectsGE.Count; i++)
        {
            if (!pooledObjectsGE[i].activeInHierarchy)
            {
                return pooledObjectsGE[i];
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (WillGrowGE == true)
        {
            GameObject obj = Instantiate(pooledObjectGE);
            pooledObjectsGE.Add(obj);
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
