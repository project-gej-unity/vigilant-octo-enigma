using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 100.0f;
    public float acceleration = 30.0f;
    public float airAcceleration = 5.0f;
    public float maxSlope = 50f;

    [Header("Ground Check Settings")]
    public float checkDistance = 1f;
    public LayerMask groundLayer;

    [Header("Movement Stats UI")]
    public bool showUI = false;
    public GameObject DebugUI;
    public TextMeshProUGUI coordinates;
    public TextMeshProUGUI speedXYZ;
    public TextMeshProUGUI rotation;
    public TextMeshProUGUI isGroundedText;
    public TextMeshProUGUI state;

    private CapsuleCollider capsule;
    private Rigidbody rb;
    bool isGrounded()
    {
        RaycastHit hit;
        Vector3 origin = transform.position + capsule.center;
        Debug.DrawRay(origin, Vector3.down*(checkDistance), Color.red);
        if(Physics.SphereCast(origin, capsule.radius*0.9f, Vector3.down, out hit, checkDistance, groundLayer))
        {
            return Vector3.Angle(Vector3.up, hit.normal) <= maxSlope;
        }
        return false;
    }
    bool isCrouching()
    {

        return false;
    }
    bool isSprinting()
    {

        return false;
    }
    void showMovementStats()
    {
        DebugUI.SetActive(true);
        coordinates.text = $"Position: {transform.position.x:F2} , {transform.position.y:F2} , {transform.position.z:F2}";
        speedXYZ.text = $"Velocity: {rb.linearVelocity.x:F3} , {rb.linearVelocity.y:F3} , {rb.linearVelocity.z:F3}";
        Vector3 rot = transform.eulerAngles;
        rotation.text = $"Rotation: {rot.x:F0} , {rot.y:F0} , {rot.z:F0}";
        isGroundedText.text = $"isGrounded: {isGrounded()}";
        if(isSprinting()) state.text = "Sprinting";
        else if(isCrouching()) state.text = "Crouching";
        else state.text = "Walking";
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        Debug.Log(isGrounded());
    }

    void Update()
    {
        if(showUI)
        {
            showMovementStats();
        }   
        else
        {
            DebugUI.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(isGrounded());
    }
}
