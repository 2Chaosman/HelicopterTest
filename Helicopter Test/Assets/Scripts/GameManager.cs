using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float weaponRange = 100;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] public Camera missileCamera;
    [SerializeField] private float missileFireForce = 300;

    private Rigidbody missileRb;
    private bool isFPSViewOn = false;
    public bool isFired = false;

    private void Start()
    {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
        missileCamera = missilePrefab.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        FireMissile();
        ChangeView();
        MoveHelicopter();
        
    }

    private void FireMissile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFPSViewOn && !isFired)
        {
            isFired = true;
            missileCamera.enabled = true;
            Vector3 rayOrigin = firstPersonCamera.transform.position;
            Ray ray = firstPersonCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            Debug.DrawRay(rayOrigin, firstPersonCamera.transform.forward * weaponRange, Color.green);

            if(Physics.Raycast(rayOrigin, firstPersonCamera.transform.forward, out hit))
            {
                GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);
                missile.transform.Rotate(0, 0, 90);
                missileRb = missile.GetComponent<Rigidbody>();
                missileRb.AddForce(ray.direction * missileFireForce);
                
            }

        }

    }

    private void ChangeView()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isFPSViewOn)
            {
                thirdPersonCamera.enabled = true;
                firstPersonCamera.enabled = false;
                isFPSViewOn = false;
            }
            else
            {
                thirdPersonCamera.enabled = false;
                firstPersonCamera.enabled = true;
                isFPSViewOn = true;
            }
        }
    }

    private void MoveHelicopter()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
