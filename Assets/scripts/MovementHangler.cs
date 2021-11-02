using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHangler : MonoBehaviour
{
    public InputHandler inputHandler;
    [SerializeField] private float speed = 0.2f;

    Rigidbody rb;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Resolution res = Screen.currentResolution;

        Vector2 currentDeltaPos = inputHandler.GetTouchDeltaPosition();
        if (inputHandler.IsThereTouchOnScreen())
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.y < res.height / 3 &&
               touch.position.x > res.width / 4 &&
               touch.position.x < (3 * res.width) / 4)
            {

                var turnY = Quaternion.Euler(0, currentDeltaPos.x * speed * -1, 0);
                rb.rotation = turnY * transform.rotation;

                //Vector3 vecY = new Vector3(0, currentDeltaPos.x * speed * -1, 0);
                //rb.AddTorque(vecY, ForceMode.Force);
            }
            if (touch.position.x < res.width / 4 &&
                touch.position.y > res.height / 4 &&
                touch.position.y < (3 * res.height) / 4)
            {
                var turnX = Quaternion.Euler(currentDeltaPos.y * speed * -1, 0, 0);
                rb.rotation = turnX * transform.rotation;

                //Vector3 vecX = new Vector3( currentDeltaPos.x * speed * -1,0, 0);
                //rb.AddTorque(vecX, ForceMode.Force);

            }
            if (touch.position.x > (3 * res.height) / 4 &&
                touch.position.y > res.height / 4 &&
                touch.position.y < (3 * res.height) / 4)
            {
                var turnZ = Quaternion.Euler(0, 0, currentDeltaPos.y * speed * -1);
                rb.rotation = turnZ * transform.rotation;

                // Vector3 vecZ = new Vector3(0,0, currentDeltaPos.x * speed * -1 );
                //// float h = currentDeltaPos.x * speed * Time.deltaTime;
                //  rb.AddTorque(transform.up*h);


            }
                rb.rotation = rb.rotation.normalized;

            // // ;
            //  foreach(Touch touch in Input.touches)

            ////  if (touch.phase == TouchPhase.Began)
            //  {

            //      if (touch.position.y < res[0].height / 3)
            //      {
            //          transform.rotation = Quaternion.AngleAxis(speed, rotY);
            //      }
            //      if (touch.position.x < res[0].width / 3)
            //      {
            //          Vector3 rotX = new Vector3(currentDeltaPos.y * speed, 0, 0);
            //          transform.Rotate(rotX);
            //          print(rotX);
            //      }
            //      else
            //      {
            //          Vector3 rotZ = new Vector3(0, 0, currentDeltaPos.y * speed);
            //          transform.Rotate(rotZ);

            //      }
            //  }
        }
    }
}
