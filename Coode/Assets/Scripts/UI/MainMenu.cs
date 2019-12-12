using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }


    public void ResetProgress()
    {
        string path = Application.persistentDataPath + "/player.chancla";
        if(File.Exists(@path))
            File.Delete(@path);
    }


    public void Quit()
    {
        Application.Quit();
    }
}