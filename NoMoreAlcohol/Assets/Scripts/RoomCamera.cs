using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//script for the camera used in the game, this type goes from room to room 
public class RoomCamera : MonoBehaviour
{

    [SerializeField] Grid grid;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject player;


    
    void Update()
    {
        //changing up the position of the player following the player cell by cell
        if (PlayerPrefs.GetInt("map_active") == 0)
        {
    
            Vector3Int cellPosition = grid.WorldToCell(player.transform.position);
            Camera.transform.position = grid.GetCellCenterWorld(cellPosition);

        }
    }
}
