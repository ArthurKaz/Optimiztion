using System.Collections.Generic;
using UnityEngine;

namespace Optimization
{
    public abstract class PoolBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T _prefab;
        [SerializeField] private int _initialPoolSize = 10;
        private List<T> _pool;
        protected virtual Transform Container => transform;

        private void Awake()
        {
            _pool = new List<T>();
            for (int i = 0; i < _initialPoolSize; i++)
            {
                var obj = Instantiate();
                obj.gameObject.SetActive(false);
            }
        }
        
        public T GetObjectFromPool()
        {
            foreach (var obj in _pool)
            {
                if (obj.gameObject.activeInHierarchy == false)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }

            var newObj = Instantiate();
            return newObj;
        }

        public bool HasActiveObject()
        {
            foreach (var obj in _pool)
            {
                if (obj.gameObject.activeInHierarchy)
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual T Instantiate()
        {
            var newObj = Instantiate(_prefab, Container);
            _pool.Add(newObj);
            return newObj;
        }
    }
}