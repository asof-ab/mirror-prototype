using Mirror;
using UnityEngine;
using ParrelSync;

public class NetworkManagerStartup : MonoBehaviour
{
  NetworkManager networkManager;

  void Start()
  {
    networkManager = GetComponent<NetworkManager>();

    if (!Application.isBatchMode)
    {
      if (Application.isEditor)
      {
        // If game is running in a ParrelSync clone
        if (ClonesManager.IsClone())
        {
          Debug.Log($"=== Client Build ===");
          networkManager.networkAddress = "localhost";
          networkManager.StartClient();
        }
        else
        {
          Debug.Log($"=== Server Build ===");
          networkManager.StartServer();
        }
      }
      else
      {
        Debug.Log($"=== Client Build ===");
        networkManager.StartClient();
      }
    }
    else
    {
      Debug.Log($"=== Server Build ===");
      networkManager.StartServer();
    }
  }
}
