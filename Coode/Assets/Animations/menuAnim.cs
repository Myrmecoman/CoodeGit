using UnityEngine;

public class menuAnim : MonoBehaviour
{
    private Vector3 minZ;
    private Vector3 maxZ;
    private bool b;

    private void Start()
    {
        minZ = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
        maxZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-0.2f, 0.2f));
        float a = Random.Range(-1, 1);
        if (a > 0)
            b = true;
        else
            b = false;
    }

    void Update()
    {
        if (b)
        {
            transform.position = Vector3.Lerp(transform.position, minZ, Time.smoothDeltaTime/12);
            if (transform.position.z <= minZ.z + 0.05f)
                b = false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, maxZ, Time.smoothDeltaTime/12);
            if (transform.position.z >= maxZ.z - 0.05f)
                b = true;
        }
    }
}