using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

    }

    void Update()
    {
        if (isLocalPlayer)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
       
    }
     void LateUpdate()
    {
        if (isLocalPlayer)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLenght;

            if (groundPlane.Raycast(cameraRay, out rayLenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLenght);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = moveVelocity;

       
    }
    [Command]
    void CmdFire()
    {
        // criar a bala a partir do prefab
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //velocidade da bala
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10.0f;

        //Spawnar a bala no cliente
        NetworkServer.Spawn(bullet);

        //Destroy a bala
        Destroy(bullet, 2);
    }


}
