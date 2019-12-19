using UnityEngine;

public class Fence : MonoBehaviour
{
    [HideInInspector] public bool open;
    private MeshRenderer screen;


    private void Awake()
    {
        open = false;
        screen = GetComponent<MeshRenderer>();
        screen.materials[2].color = Color.red;
    }


    public void OnChange(bool b)
    {
        open = b;
        if (open)
        {
            screen.materials[2].color = Color.green;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
        }
        else
        {
            screen.materials[2].color = Color.red;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0);
        }
    }
}