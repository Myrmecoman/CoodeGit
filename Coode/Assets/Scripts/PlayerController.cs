using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool forbid;

    void Start()
    {
        forbid = false;
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.6f);
            foreach(Collider i in hitColliders)
            {
                if (i.transform.position.z == transform.position.z + 1)
                {
                    if(i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.6f);
                    foreach(Collider j in further)
                    {
                        if (j.transform.position.z == transform.position.z + 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if(!forbid)
                        i.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                    break;
                }
            }
            if(!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.6f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.z == transform.position.z - 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.6f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.z == transform.position.z - 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.6f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.x == transform.position.x - 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.6f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.x == transform.position.x - 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.6f);
            foreach (Collider i in hitColliders)
            {
                if (i.transform.position.x == transform.position.x + 1)
                {
                    if (i.tag == "Wall")
                    {
                        forbid = true;
                        break;
                    }
                    Collider[] further = Physics.OverlapSphere(transform.position, 1.6f);
                    foreach (Collider j in further)
                    {
                        if (j.transform.position.x == transform.position.x + 2)
                        {
                            forbid = true;
                            break;
                        }
                    }
                    if (!forbid)
                        i.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                    break;
                }
            }
            if (!forbid)
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }

        if (forbid)
            forbid = false;
    }
}
