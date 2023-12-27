using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public int x;
    public int y;

    private void Start() 
    {
        Vector2 startPosition = new Vector2(x, y);
        PhotonNetwork.Instantiate(playerPrefab.name, startPosition, Quaternion.identity);
    }
}
