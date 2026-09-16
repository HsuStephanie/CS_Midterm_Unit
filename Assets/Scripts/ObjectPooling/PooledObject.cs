using UnityEngine;

namespace MidtermTuringTest
{
    public class PooledObject : MonoBehaviour
    {
        //reference to object pool that created this object
        ObjectPool poolReference;

        public void SetObjectPool(ObjectPool _pool)
        {
            poolReference = _pool;
        }
        public void DestroyWithTime(float time)
        {
            Invoke("ResetObject", time);
        }

        public void ResetObject()
        {
            poolReference.RestoreObjectToPool(this);
        }
    }
}
