using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void CheckFinished()
    {
        Collider[] near = Physics.OverlapSphere(transform.position, 0.4f);
        foreach(Collider i in near)
        {
            if (i.tag == "Block")
                SceneManager.LoadScene(0);
        }
    }
}