using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextScene : MonoBehaviour
{
    public string SceneName = "";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!String.IsNullOrWhiteSpace(SceneName))
                SceneManager.LoadScene(SceneName);
            else
                Debug.LogError("Setup scenename and a loadable scene!");
        }
    }
}
