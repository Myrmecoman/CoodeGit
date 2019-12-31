using UnityEngine;
using UnityEngine.SceneManagement;

public class TellWorldIfSuccess : MonoBehaviour
{
    private bool success;
    private int sceneID;
    private double timer;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        success = false;
        timer = 0;
        sceneID = SceneManager.GetActiveScene().buildIndex;
    }


    public void Success()
    {
        success = true;
    }

    
    private void Update()
    {
        if (!success)
            timer += Time.deltaTime;
    }


    // we destroy the object
    public void UpdateAll(CharacterManager player)
    {
        if (!player.FenceList[sceneID - 2].open && success)
        {
            Debug.Log("Setting fence number " + (sceneID - 2) + " to true");
            player.SetFence(sceneID - 2);
        }

        if ((player.TimesList[player.CurrentIndex] > timer || player.TimesList[player.CurrentIndex] == 0) && success)
            player.TimesList[player.CurrentIndex] = timer;

        Destroy(gameObject);
    }
}