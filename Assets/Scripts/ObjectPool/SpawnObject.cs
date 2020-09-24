using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YergoScripts.ObjectPool
{
    [System.Serializable]
    public class SpawnObject
    {
        public GameObject Prefab;
        public int InPool;
    }
}