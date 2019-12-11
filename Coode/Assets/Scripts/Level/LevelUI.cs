using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public void Reroll()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Quit()
    {

    }
}
