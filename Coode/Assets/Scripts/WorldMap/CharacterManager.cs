using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public int startLevelIndex;
    public Transform[] SlotList;

    private int CurrentIndex;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CurrentIndex = 0;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(startLevelIndex + CurrentIndex);

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) && CurrentIndex > 0)
        {
            CurrentIndex--;
            transform.position =
                new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentIndex < SlotList.Length - 1)
        {
            CurrentIndex++;
            transform.position =
                new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
        }
    }
}
