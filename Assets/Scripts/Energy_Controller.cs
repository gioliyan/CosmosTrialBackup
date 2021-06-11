using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Controller : MonoBehaviour
{
    private Quaternion randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        randomRotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation.eulerAngles * 0.1f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            Destroy(gameObject);
        }
    }
}
