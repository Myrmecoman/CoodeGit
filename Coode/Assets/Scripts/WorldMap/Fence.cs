using UnityEngine;

public class Fence : MonoBehaviour
{
    public bool open;
    public Material red;
    public Material green;

    private MeshRenderer screen;


    private void Awake()
    {
        open = false;
        screen = GetComponent<MeshRenderer>();
    }


    public void OnChange(bool b)
    {
        open = b;
        if (open)
        {
            //screen.materials[2] = green;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
        }
        else
        {
            //screen.materials[2] = red;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0);
        }
    }
}