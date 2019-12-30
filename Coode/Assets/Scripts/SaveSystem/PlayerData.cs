
[System.Serializable]
public class PlayerData
{
    public int Currentindex;
    public int maxIndex;
    public double[] timesRecord;


    public PlayerData(CharacterManager player)
    {
        timesRecord = new double[player.SlotList.Length];
        for (int i = 0; i < player.SlotList.Length; i++)
            timesRecord[i] = player.TimesList[i];
        Currentindex = player.CurrentIndex;
        maxIndex = player.GetMaxIndex();
    }
}