using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rig;
    float magnitude = 5;

    


    void Start()
    {
        rig= GetComponent<Rigidbody>();
        //rig.AddForce(Vector3.up * magnitude, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rig.AddForce(Vector3.up * magnitude, ForceMode.Impulse);
    }
}
