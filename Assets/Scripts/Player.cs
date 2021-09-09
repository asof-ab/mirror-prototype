using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed down");
            rb.AddForce(new Vector3(0,1,0), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C key pressed down");
            CmdMovePlayerToMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("V key pressed down");
            CmdMovePlayerToGameMenu();
        }

    }

    [Command]
    private void CmdMovePlayerToMainMenu()
    {
        MultiSceneNetworkManager.singleton.MovePlayerToMainMenu(this.gameObject);
    }

    [Command]
    private void CmdMovePlayerToGameMenu()
    {
        MultiSceneNetworkManager.singleton.MovePLayerToGameAndUnloadMainMenu(this.gameObject);
    }
}
