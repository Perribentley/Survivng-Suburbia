using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float Speed = 10f;
    [SerializeField] float TurnSpeed = 20f;
    private float HorizontalInput;
    private float ForwardInput;

    private Rigidbody RBPlayer;

    private int FuseCount;
    [SerializeField] Text Fuses;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get player input
        HorizontalInput = Input.GetAxis("Horizontal");
        ForwardInput = Input.GetAxis("Vertical");

        //Move player forward
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ForwardInput);
        //Turn player
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * HorizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RBPlayer = GetComponent<Rigidbody>();

        if(collision.gameObject.name == "House")
        {
            RBPlayer.velocity = Vector3.zero;
        }

        if(collision.gameObject.name == "Street")
        {
            RBPlayer.velocity = Vector3.zero;
        }

        if(collision.gameObject.name == "Walls")
        {
            RBPlayer.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fuse")
        {
            FuseCount += 1;
            Debug.Log(FuseCount);
            SetFuseText();
            other.gameObject.SetActive(false);
        }
    }

    void SetFuseText()
    {
        Fuses.text = "Fuses: " + FuseCount.ToString();
    }
}
