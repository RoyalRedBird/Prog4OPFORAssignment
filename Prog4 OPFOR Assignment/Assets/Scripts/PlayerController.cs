using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject playerCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {

            playerPos += Vector3.forward * moveSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {

            playerPos += Vector3.left * moveSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {

            playerPos += -Vector3.forward * moveSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D))
        {

            playerPos += Vector3.right * moveSpeed * Time.deltaTime;

        }

        transform.position = playerPos;

        //playerPos.Rotate = new Vector3(Input.mousePositionDelta.x, 0, 0);

    }
}
