using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public int startLevelIndex;
    public TextMeshProUGUI timeRecord;
    public Transform[] SlotList;
    public Fence[] FenceList;

    [HideInInspector] public int CurrentIndex;
    [HideInInspector] public double[] TimesList;

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CurrentIndex = 0;
        LoadPlayer();
        GameObject found = GameObject.Find("TellToWorldThatWeSucceeded");
        if (found)
        {
            found.GetComponent<TellWorldIfSuccess>().UpdateFence(this);
            found.GetComponent<TellWorldIfSuccess>().UpdateTimes(this);
            timeRecord.text = "Personnal record : " + TimesList[CurrentIndex] + " sec";
        }
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
            timeRecord.text = "Personnal record : " + TimesList[CurrentIndex] + " sec";
            transform.position =
                new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentIndex < SlotList.Length - 1 && FenceList[CurrentIndex].open)
        {
            CurrentIndex++;
            timeRecord.text = "Personnal record : " + TimesList[CurrentIndex] + " sec";
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
        TimesList = new double[SlotList.Length];
        CurrentIndex = data.Currentindex;
        for (int i = data.maxIndex; i >= 0; i--)
            FenceList[i].OnChange(true);
        transform.position = new Vector3(SlotList[CurrentIndex].position.x, SlotList[CurrentIndex].position.y + 1, SlotList[CurrentIndex].position.z);
    }
}