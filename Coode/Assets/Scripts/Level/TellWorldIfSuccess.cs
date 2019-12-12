using UnityEngine;
using UnityEngine.SceneManagement;

public class TellWorldIfSuccess : MonoBehaviour
{
    private bool success;
    private int sceneID;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        success = false;
        sceneID = SceneManager.GetActiveScene().buildIndex;
    }


    public void Success()
    {
        success = true;
    }


    public void UpdateFence(CharacterManager player)
    {
        if (!player.FenceList[sceneID - 2].open && success)
        {
            Debug.Log("Setting fence number " + (sceneID - 2) + " to true");
            player.SetFence(sceneID - 2);
        }
        Destroy(gameObject);
    }
}