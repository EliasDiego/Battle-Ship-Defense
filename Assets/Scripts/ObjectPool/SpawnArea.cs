using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YergoScripts.ObjectPool
{
        public class SpawnArea : MonoBehaviour
    {
        [SerializeField] Vector3 _Size;
        [SerializeField] List<SpawnObject> _SpawnObjects;

        List<ObjectPool> _ObjectPool = new List<ObjectPool>();
        Bounds _Bounds;

        void Awake()
        {
            _Bounds = new Bounds(transform.position, _Size);
        }

        // Update is called once per frame
        void Update()
        {
            foreach(ObjectPool pool in _ObjectPool)
                pool.CheckActiveObjects();
        }
        
        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, _Size);
        }

        public void Instantiate()
        {
            for(int i = 0; i < _SpawnObjects.Count; i++)
                _ObjectPool.Add(new ObjectPool());

            for(int i = 0; i < _SpawnObjects.Count; i++)
                _ObjectPool[i].Instantiate(_SpawnObjects[i]);

        }

        public void Spawn(int index, int numObjects)
        {
            GameObject obj;

            for(int i = 1; i <= numObjects; i++)
            {
                obj = _ObjectPool[index].TryGetObject();

                if(!obj)
                    break;
                obj.SetActive(true);

                obj.transform.position = new Vector3(
                    Random.Range(_Bounds.center.x - _Bounds.extents.x, _Bounds.center.x + _Bounds.extents.x),
                    Random.Range(_Bounds.center.y - _Bounds.extents.y, _Bounds.center.y + _Bounds.extents.y),
                    Random.Range(_Bounds.center.z - _Bounds.extents.z, _Bounds.center.z + _Bounds.extents.z));
            }
        }

        public void DestroySpawnArea()
        {
            foreach(ObjectPool pool in _ObjectPool)
                pool.DestroyPool();
        }
    }
}