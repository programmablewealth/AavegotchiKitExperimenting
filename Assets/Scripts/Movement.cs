using System.Collections;
using System.Collections.Generic;
using com.mycompany;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        GotchiUI gotchiUi = GetComponent<GotchiUI>();
        if (horizontalInput > 0f) {
            gotchiUi.turn(3);
        } else if (horizontalInput < 0f) {
             gotchiUi.turn(1);
        }

        if (verticalInput > 0f) {
            gotchiUi.turn(2);
        } else if (verticalInput < 0f) {
             gotchiUi.turn(0);
        }
        
        if (horizontalInput == 0f && verticalInput == 0f) {
            gotchiUi.turn(0);
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * movementSpeed);
    }
}
