using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Speed of player's movement")]
    public float speed = 7f;

    public Text numberFloor;
    private int floor = 0;

    public GameObject dead;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RelocateUp")
        {
            float positionZ = (float)3.5 - 2 * transform.position.z;
            float positionX = (float)16 - 2 * transform.position.x;
            transform.position += new Vector3(positionX, 6.5f, positionZ);
            transform.Rotate(0, 180f, 0, Space.Self);
            floor++;
            numberFloor.text = floor.ToString();
        }
        if (collision.gameObject.tag == "RelocateDown" && floor > 0)
        {
            float positionZ = (float)3.5 - 2 * transform.position.z;
            float positionX = (float)16 - 2 * transform.position.x;
            transform.position += new Vector3(positionX, -6.5f, positionZ);
            transform.Rotate(0, 180f, 0, Space.Self);
            floor--;
            numberFloor.text = floor.ToString();
        }
        if (collision.gameObject.tag == "SCP0871")
        {
            dead.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            floor = 0;
        }
    }
}
