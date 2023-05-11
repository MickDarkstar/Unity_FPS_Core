using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Scripts.Core.Helpers
{
    public static class FindByInterface
    {
        public static List<T> Find<T>()
        {
            List<T> interfaces = new List<T>();
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootGameObject in rootGameObjects)
            {
                T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
                foreach (var childInterface in childrenInterfaces)
                {
                    interfaces.Add(childInterface);
                }
            }
            return interfaces;
        }
    }
}
