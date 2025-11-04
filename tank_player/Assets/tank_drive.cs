using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationspeed = 40.0f;

    public GameObject TankBase;
    bool rotates = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime;

        this.transform.Translate(0, translation, 0);
        this.transform.Rotate(0, 0, -rotation);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            rotates = true;
        }

        if (rotates)
            lookAtBase();


    }


    void lookAtBase()
    {
        Vector3 distanceVector = (TankBase.transform.position - this.transform.position).normalized;
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(distanceVector, this.transform.up) / (distanceVector.normalized.magnitude * this.transform.up.magnitude));

        Vector3 cross = Vector3.Cross(distanceVector, this.transform.up.normalized).normalized;

        angle = Mathf.Lerp(0, angle, 5 * Time.deltaTime);

        if (cross.z > 0)
            angle = angle * -1;

        if (Mathf.Abs(angle) > 3)
        {
            this.transform.Rotate(0, 0, angle);
        }
        else
            rotates = false;
            
    }
}
