using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFixBall : MonoBehaviour
{
    public InputHandler inputHandler;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude == 0 && inputHandler.IsThereTouchOnScreen())
        {
            Vector3 vec = new Vector3(0f, 1f);
            rb.AddForce(vec, ForceMode.Impulse);
        }
    }
}
