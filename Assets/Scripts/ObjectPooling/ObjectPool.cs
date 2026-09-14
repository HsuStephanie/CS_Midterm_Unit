using System.Collections.Generic;
using UnityEngine;

namespace MidtermTuringTest
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool instance;

        //Two lists for Object pooling: 1 in use, and 1 available
        public List<PooledObject> unusedPool = new List<PooledObject>();
        public List<PooledObject> usedPool = new List<PooledObject>();
        [SerializeField] GameObject objectToCreate;
        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else if (instance == null)
            {
                instance = this;
            }

            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < 20; i++)
            {
                AddNewObject();
            }
        }


        public void AddNewObject()
        {
            GameObject newObject = Instantiate(objectToCreate, transform.position, Quaternion.identity);
            newObject.GetComponent<PooledObject>().SetObjectPool(this);

            //Hide new object on creation
            newObject.SetActive(false);
            unusedPool.Add(newObject.GetComponent<PooledObject>());
        }

        public PooledObject GetPooledObject()
        {

            if (unusedPool.Count > 0)
            {
                //grab first available
                usedPool.Add(usedPool[0]);

                //remove it from the available
                unusedPool.RemoveAt(0);
                //activate and return to caller
                usedPool[usedPool.Count - 1].gameObject.SetActive(true);
                return usedPool[usedPool.Count - 1];
            }

            else
            {
                Debug.Log("No pooled objects");
                return null;
            }
        }
        public void RestoreObjectToPool(PooledObject _pooledObject)
        {
            //return object to available pool
            unusedPool.Add(_pooledObject);
            //remove object from used pool
            usedPool.Remove(_pooledObject);
            _pooledObject.gameObject.SetActive(false);
        }
    }
}
