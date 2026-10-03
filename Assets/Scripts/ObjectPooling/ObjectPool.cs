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
        [SerializeField] GameObject objectToPool;
        PooledObject _tempObject;

        int _poolStartSize = 10;

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

        }
        void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < _poolStartSize; i++)
            {
                AddNewObject();
            }
        }


        public void AddNewObject()
        {
            _tempObject = Instantiate(objectToPool, transform.position, Quaternion.identity).GetComponent<PooledObject>();

            //Hide new object on creation
            _tempObject.gameObject.SetActive(false);

            _tempObject.SetObjectPool(this);
            unusedPool.Add(_tempObject);
        }

        public PooledObject GetPooledObject()
        {

            if (unusedPool.Count == 0)
                AddNewObject();

            PooledObject obj = unusedPool[0];
            unusedPool.RemoveAt(0);
            usedPool.Add(obj);

            obj.gameObject.SetActive(true);
            obj.ResetObject();
            return obj;
        }

        public void DestroyPooledObject(PooledObject obj, float time = 0)
        {
            obj.Destroy(time);
        }
        public void RestoreObjectToPool(PooledObject _pooledObject)
        {
            if (!usedPool.Remove(_pooledObject))
                return; // already returned

            _pooledObject.gameObject.SetActive(false);
            unusedPool.Add(_pooledObject);
        }
    }
}
