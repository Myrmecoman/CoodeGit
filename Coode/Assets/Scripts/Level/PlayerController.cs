using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Reroll;
    public GameObject Settings;
    public GameObject Quit;
    public Finish finish;

    private bool forbid;
    private bool esc;

    void Start()
    {
        forbid = false;
        esc = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Settings.SetActive(false);
        Reroll.SetActive(false);
        Quit.SetActive(false);
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
        {
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
                        if (j.transform.position.z == transform.position.z + 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                    {
                        i.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                    }
                    break;
                }
            }
            if(!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
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
                        if (j.transform.position.z == transform.position.z - 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                    {
                        i.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                    }
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
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
                        if (j.transform.position.x == transform.position.x - 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                    {
                        i.transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                    }
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
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
                        if (j.transform.position.x == transform.position.x + 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                    {
                        i.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                    }
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
                Reroll.SetActive(true);
                Settings.SetActive(true);
                Quit.SetActive(true);
            }
            else
            {
                esc = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Reroll.SetActive(false);
                Settings.SetActive(false);
                Quit.SetActive(false);
            }
        }
    }
}
