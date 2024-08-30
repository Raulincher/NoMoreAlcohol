using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject bossRoom;
    public GameObject SecretBossKeyRoom; 
    public GameObject SecretBossKeyChest; 
    public GameObject SecretBoss;
    public GameObject DoubleJumpChest;
    public GameObject bossKeyChest;
    public GameObject bossKeyRoom;
    public GameObject SecretBossKeyRoomChest;
    public GameObject bossKeyRoomChest;

    void Start()
    {
        bossRoom.SetActive(false);
        SecretBossKeyRoom.SetActive(false);
        SecretBossKeyChest.SetActive(false);
        SecretBoss.SetActive(false);
        DoubleJumpChest.SetActive(false);
        bossKeyChest.SetActive(false);
        bossKeyRoom.SetActive(false);
        SecretBossKeyRoomChest.SetActive(false);
        bossKeyRoomChest.SetActive(false);
    }

    public void ShowInteractText(string name)
    {
        Debug.Log(name);

        switch (name)
        {
            case "DoorToBoss":
                bossRoom.SetActive(true);
                break;
            case "SecretBossKeyRoom":
                SecretBossKeyRoom.SetActive(true);
                break;
            case "SecretBossKey":
                SecretBossKeyChest.SetActive(true);
                break;
            case "SecretBossRoom":
                SecretBoss.SetActive(true);
                break;
            case "DoubleJump":
                DoubleJumpChest.SetActive(true);
                break;
            case "FinalBossKey":
                bossKeyChest.SetActive(true);
                break;
            case "SecretDoor1":
                bossKeyRoom.SetActive(true);
                break;
            case "KeyToSecretBossKeyRoom":
                SecretBossKeyRoomChest.SetActive(true);
                break;
            case "SecretRoom1Key":
                bossKeyRoomChest.SetActive(true);
                break;
            default:
                bossRoom.SetActive(false);
                SecretBossKeyRoom.SetActive(false);
                SecretBossKeyChest.SetActive(false);
                SecretBoss.SetActive(false);
                DoubleJumpChest.SetActive(false);
                bossKeyChest.SetActive(false);
                bossKeyRoom.SetActive(false);
                SecretBossKeyRoomChest.SetActive(false);
                bossKeyRoomChest.SetActive(false);
                break;
        }
        
    }

    public void HideInteractText()
    {
        bossRoom.SetActive(false);
        SecretBossKeyRoom.SetActive(false);
        SecretBossKeyChest.SetActive(false);
        SecretBoss.SetActive(false);
        DoubleJumpChest.SetActive(false);
        bossKeyChest.SetActive(false);
        bossKeyRoom.SetActive(false);
        SecretBossKeyRoomChest.SetActive(false);
        bossKeyRoomChest.SetActive(false);
    }
}
