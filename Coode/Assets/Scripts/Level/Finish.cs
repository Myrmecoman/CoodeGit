using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public TellWorldIfSuccess teller;


    public void CheckFinished()
    {
        Collider[] near = Physics.OverlapSphere(transform.position, 0.4f);
        foreach(Collider i in near)
        {
            if (i.tag == "Block")
            {
                teller.Success();
                SceneManager.LoadScene(1);
            }
        }
    }
}