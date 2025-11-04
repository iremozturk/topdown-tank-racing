using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrack : MonoBehaviour
{
    public GameObject TheMarker;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject Cube5;
    public GameObject Cube6;
    public GameObject Cube7;
    public GameObject Cube8;
    public GameObject Cube9;
    public int CubeTracker;


    void Update()
    {
        if (CubeTracker == 0)
        {
            TheMarker.transform.position = Cube1.transform.position;
        }
        if (CubeTracker == 1)
        {
            TheMarker.transform.position = Cube2.transform.position;
        }
        if (CubeTracker == 2)
        {
            TheMarker.transform.position = Cube3.transform.position;
        }
        if (CubeTracker == 3)
        {
            TheMarker.transform.position = Cube4.transform.position;
        }
        if (CubeTracker == 4)
        {
            TheMarker.transform.position = Cube5.transform.position;

        }
        if (CubeTracker == 5)
        {
            TheMarker.transform.position = Cube6.transform.position;
        }
        if (CubeTracker == 6)
        {
            TheMarker.transform.position = Cube7.transform.position;
        }
        if (CubeTracker == 7)
        {
            TheMarker.transform.position = Cube8.transform.position;
        }
        if (CubeTracker == 8)
        {
            TheMarker.transform.position = Cube9.transform.position;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "AI_Car")
        {
            StartCoroutine(HandleCheckpoint());
        }
    }

    IEnumerator HandleCheckpoint()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        CubeTracker += 1;
        if (CubeTracker == 8)
        {
            CubeTracker = 0;
        }
        yield return new WaitForSeconds(1);
        this.GetComponent<BoxCollider>().enabled = true;
    }


}

