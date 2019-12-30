using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject img;
    public Finish finish;

    private bool forbid;
    private bool esc;

    void Start()
    {
        forbid = false;
        esc = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        img.SetActive(false);
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.51f);
            foreach(Collider i in hitColliders)
            {
                if (i.transform.position.z == transform.position.z + 1)
                {
                    if(i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.51f);
                    foreach(Collider j in further)
                    {
                        if (j.transform.position.z == i.transform.position.z + 1)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(i.transform.position.x, i.transform.position.y, i.transform.position.z + 1);
                    break;
                }
            }
            if(!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.51f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.z == transform.position.z - 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.51f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.z == i.transform.position.z - 1)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(i.transform.position.x, i.transform.position.y, i.transform.position.z - 1);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.51f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.x == transform.position.x - 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.51f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.x == i.transform.position.x - 1)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(i.transform.position.x - 1, i.transform.position.y, i.transform.position.z);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.51f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.x == transform.position.x + 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.51f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.x == i.transform.position.x + 1)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(i.transform.position.x + 1, i.transform.position.y, i.transform.position.z);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }

        finish.CheckFinished();

        if (forbid)
            forbid = false;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!esc)
            {
                esc = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                img.SetActive(true);
            }
            else
            {
                esc = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                img.SetActive(false);
            }
        }
    }
}