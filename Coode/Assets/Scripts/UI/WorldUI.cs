using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldUI : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}