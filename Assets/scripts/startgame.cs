using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Pradeti(string sceneName)
    {
        Debug.Log("Funkcija Pradeti iškviesta su scena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
