using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public Transform cam;


    public void BackMenu()
    {
        cam.position = new Vector3(-100.44f, 9, -81.87f);
    }
}