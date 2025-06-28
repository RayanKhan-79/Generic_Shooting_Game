using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private const float sensitivity = 5;

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        MovePlayer();
    }

    void MoveCamera()
    {
        if (Input.GetMouseButton(1))
        {
            float xRotation = Input.GetAxis("Mouse X");
            //float yRotation = Input.GetAxis("Mouse Y");

            
            transform.Rotate(new Vector3(0, xRotation * sensitivity, 0));
        }
    }
    void MovePlayer()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        // forward and backwards movement
        transform.position += transform.forward * zAxis * Time.deltaTime;

        // left and right movement
        transform.position += transform.right * xAxis * Time.deltaTime;
    }
}
