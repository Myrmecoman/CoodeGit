using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public TellWorldIfSuccess theTeller;

    public void Reroll()
    {
        Destroy(theTeller.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
