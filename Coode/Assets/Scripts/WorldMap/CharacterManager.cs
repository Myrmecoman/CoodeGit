using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public int startLevelIndex;
    public Transform[] SlotList;
    public Fence[] FenceList;

    [HideInInspector]public int CurrentIndex;

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CurrentIndex = 0;
        LoadPlayer();
        if (GameObject.Find("TellToWorldThatWeSucceeded"))
            GameObject.Find("TellToWorldThatWeSucceeded").GetComponent<TellWorldIfSuccess>().UpdateFence(this);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SavePlayer();
            SceneManager.LoadScene(startLevelIndex + CurrentIndex);
        }

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)) && CurrentIndex > 0)
        {
            CurrentIndex--;
            transform.position =
                new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentIndex < SlotList.Length - 1 && FenceList[CurrentIndex].open)
        {
            CurrentIndex++;
            transform.position =
                new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("The length of SlotList is " + SlotList.Length);
            Debug.Log("CurrentIndex is " + CurrentIndex);
            foreach(Fence f in FenceList)
                Debug.Log(f.open);
        }
    }


    public int GetMaxIndex()
    {
        int MaxIndex = -1;
        foreach(Fence f in FenceList)
        {
            if (f.open)
                MaxIndex++;
            else
                break;
        }
        return MaxIndex;
    }


    public void SetFence(int index)
    {
        FenceList[index].OnChange(true);
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Debug.Log("CurrentIndex = " + data.Currentindex);
        Debug.Log("MaxIndex = " + data.maxIndex);
        CurrentIndex = data.Currentindex;
        for (int i = data.maxIndex; i >= 0; i--)
            FenceList[i].OnChange(true);
        transform.position = new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
    }
}