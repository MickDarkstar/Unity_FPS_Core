/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              ObjectPool.cs 
 *Author:                BjazzZ 
 *Version:               1.0 
 *UnityVersion:          2021.3.14f1 
 *Date:                  2022-12-08 
 *Description:           
 *History:               
================================================================*/

using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Core.Base.Pooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] public GameObject prefabObject;
        [SerializeField] public int poolDepth;
        [SerializeField] public bool canGrow = true;
        [SerializeField] public GameObject parentObject;
        private List<GameObject> pool = new List<GameObject>();

        void Awake()
        {
            Init();
        }

        public void RebuildPool()
        {
            this.pool = new List<GameObject>();
            Init();
        }

        public GameObject GetAvailableObject()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].activeInHierarchy == false)
                    return pool[i];
            }

            if (canGrow)
                return AddToPool();

            return null;
        }

        private void Init()
        {
            for (int i = 0; i < poolDepth; i++)
            {
                AddToPool();
            }
        }

        private GameObject AddToPool()
        {
            GameObject pooledObject = Instantiate(prefabObject);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
            return pooledObject;
        }
    }
}
