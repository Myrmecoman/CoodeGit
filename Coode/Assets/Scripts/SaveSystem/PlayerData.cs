
[System.Serializable]
public class PlayerData
{
    public int Currentindex;
    public int maxIndex;
    public float[] position;


    public PlayerData(CharacterManager player)
    {
        Currentindex = player.CurrentIndex;
        maxIndex = player.GetMaxIndex();
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
