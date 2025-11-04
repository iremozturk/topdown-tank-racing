using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAIScript : MonoBehaviour
{
    public CharacterController EnemyController;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 100.0f;
    private float speed = 15.0f;
    // Start is called before the first frame update
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject Cube5;
    public GameObject Cube6;
    public GameObject Cube7;
    public GameObject Cube8;
    public GameObject Cube9;
    void Start()
    {
        EnemyController = GetComponent<CharacterController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyController.isGrounded == true)
        {
            moveDirection = transform.TransformDirection(Vector3.forward);

        }
        moveDirection.y -= gravity * Time.deltaTime;
        EnemyController.Move(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube1")
        {
            transform.LookAt(Cube2.transform.position);
        }
        if (other.gameObject.tag == "Cube2")
        {
            transform.LookAt(Cube3.transform.position);
        }
        if (other.gameObject.tag == "Cube3")
        {
            transform.LookAt(Cube4.transform.position);
        }
        if (other.gameObject.tag == "Cube4")
        {
            transform.LookAt(Cube5.transform.position);
        }
        if (other.gameObject.tag == "Cube5")
        {
            transform.LookAt(Cube6.transform.position);
        }
        if (other.gameObject.tag == "Cube6")
        {
            transform.LookAt(Cube7.transform.position);
        }
        if (other.gameObject.tag == "Cube7")
        {
            transform.LookAt(Cube8.transform.position);
        }
        if (other.gameObject.tag == "Cube8")
        {
            transform.LookAt(Cube9.transform.position);
        }
        if (other.gameObject.tag == "Cube9")
        {
            transform.LookAt(Cube1.transform.position);
        }
    }
}
