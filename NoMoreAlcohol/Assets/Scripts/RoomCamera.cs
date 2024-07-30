using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomCamera : MonoBehaviour
{

    [SerializeField] Grid grid;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("map_active") == 0)
        {

            Debug.Log("Map is active.");

            Vector3Int cellPosition = grid.WorldToCell(player.transform.position);
            Camera.transform.position = grid.GetCellCenterWorld(cellPosition);



        }
    }
}
