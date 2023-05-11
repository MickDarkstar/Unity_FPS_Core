using UnityEngine;

// Todo: use master singleton instead: https://gamedevbeginner.com/singletons-in-unity-the-right-way/
// Ex. Omen.SomeManager.SomeMethod(something);
namespace Assets._Scripts.Core
{
    /// <summary>
    /// Basklass som kan ärvas av klasser som vi endast vill ha en instans av
    /// Viktigt att den läggs så tidigt som möjligt i hierarkin (gameobjects i project)
    /// och bara referera till en "Singleton" i Start-metoder i andra klasser
    /// Kriterier vi behöver förhålla oss till när vi vill använda singleton-pattern:
    /// 1. Endast en instans behövs och får finnas (genom hela spelet)
    /// 2. Åtkomlig i all kod (våra olika assemblies, bör därför läggas i Core som alla har åtkomst till)
    /// 3. Kontrollerar åtkomst till en resurs, t.ex playerstats, highscore och liknande.
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    FindExisting();
                    if (_instance == null)
                    {
                        _instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();
                    }
                }
                return _instance;

                void FindExisting()
                {
                    _instance = FindObjectOfType<T>();
                }
            }
        }

        private void Awake()
        {
            if (_instance != null) Destroy(this);
            DontDestroyOnLoad(this);
        }
    }
}
