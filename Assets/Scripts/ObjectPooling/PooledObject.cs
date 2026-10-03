using UnityEngine;
using UnityEngine.Events;

namespace MidtermTuringTest
{
    public class PooledObject : MonoBehaviour
    {
        //reference to object pool that created this object
        ObjectPool poolReference;
        float timer;
        bool setToDestory = false;
        float destroyTime = 0f;
        Rigidbody rigidbody;


        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            if (setToDestory)
            {
                timer += Time.deltaTime;
                if (timer >= destroyTime)
                {
                    setToDestory = false;
                    timer = 0f;
                    Destroy();
                }
            }
        }
        public void SetObjectPool(ObjectPool _pool)
        {
            poolReference = _pool;
            timer = 0f;
            destroyTime = 0f;
            setToDestory = false;
        }
        public void Destroy()
        {
            setToDestory = false;
            timer = 0f;
            if (poolReference != null)
            {
                poolReference.RestoreObjectToPool(this);
            }
        }
        public void Destroy(float time)
        {
            setToDestory = true;
            destroyTime = time;
            timer = 0f;
            
        }

        public void ResetObject()
        {
            timer = 0f;
            destroyTime = 0f;
            setToDestory = false;
            

            if (rigidbody != null)
            {
                rigidbody.linearVelocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.isKinematic = false;
            }


        }
    }
}
