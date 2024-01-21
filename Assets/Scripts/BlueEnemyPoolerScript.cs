using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyPoolerScript : MonoBehaviour
{
    public static BlueEnemyPoolerScript PoolerBE; //Reference to this class
    public GameObject pooledObjectBE; //The spawned object
    public int pooledAmountBE; //The amount of objects in this pool
    public bool WillGrowBE; //If the list is dynamically going to get bigger or not

    public List<GameObject> pooledObjectsBE;

    //Creates a new list and assigns the reference to this class
    //For every object in this pool it instantiates it in the scene,deactivates it and adds it to the pooledObjects list
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        pooledObjectsBE = new List<GameObject>();

        PoolerBE = this;
        for (int i = 0; i < pooledAmountBE; i++)
        {
            GameObject obj = Instantiate(pooledObjectBE);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pooledObjectsBE.Add(obj);
        }
    }

    //A function that will return a GameObject
    //Searches through all the GameObjects of the pool and if it isnt enabled it returns that object 
    public GameObject GetPooledObjectBE()
    {
        for (int i = 0; i < pooledObjectsBE.Count; i++)
        {
            if (!pooledObjectsBE[i].activeInHierarchy)
            {
                return pooledObjectsBE[i];
            }
        }

        //If the list is dynamic then everytime there arent enough objects in the pool to reuse it instantiates and adds one to the pool
        if (WillGrowBE == true)
        {
            GameObject obj = Instantiate(pooledObjectBE);
            pooledObjectsBE.Add(obj);
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
