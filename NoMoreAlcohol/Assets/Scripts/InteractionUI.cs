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
    public GameObject bossRoomMessage;
    public GameObject DoorMessageSecretBossKeyRoom;
    public GameObject SecretBossKeyMessage;
    public GameObject SecretBossMessage;
    public GameObject DoubleJumpChestMessage;
    public GameObject bossKeyChestMessage;
    public GameObject bossKeyRoomMessage;
    public GameObject SecretBossKeyRoomChestMessage;
    public GameObject bossKeyRoomChestMessage;
    private float visibleTime = 2f;

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
        bossRoomMessage.SetActive(false);
        DoorMessageSecretBossKeyRoom.SetActive(false);
        SecretBossKeyMessage.SetActive(false);
        SecretBossMessage.SetActive(false);
        DoubleJumpChestMessage.SetActive(false);
        bossKeyChestMessage.SetActive(false);
        bossKeyRoomMessage.SetActive(false);
        SecretBossKeyRoomChestMessage.SetActive(false);
        bossKeyRoomChestMessage.SetActive(false);
    }

    public void bossRoomMessageMethod()
    {
        bossRoomMessage.SetActive(true);
        Invoke("bossRoomMessageMethodOff", visibleTime);
    }
    public void bossRoomMessageMethodOff()
    {
        bossRoomMessage.SetActive(false);
    }

    public void DoorMessageSecretBossKeyRoomMethod()
    {
        DoorMessageSecretBossKeyRoom.SetActive(true);
        Invoke("DoorMessageSecretBossKeyRoomMethodOff", visibleTime);
    }

    public void DoorMessageSecretBossKeyRoomMethodOff()
    {
        DoorMessageSecretBossKeyRoom.SetActive(false);
    }
    public void SecretBossKeyMessageMethod()
    {
        SecretBossKeyMessage.SetActive(true);
        Invoke("SecretBossKeyMessageMethodOff", visibleTime);
    }
    public void SecretBossKeyMessageMethodOff()
    {
        SecretBossKeyMessage.SetActive(false);
    }
    public void SecretBossMessageMethod()
    {
        SecretBossMessage.SetActive(true);
        Invoke("SecretBossMessageMethodOff", visibleTime);

    }
    public void SecretBossMessageMethodOff()
    {
        SecretBossMessage.SetActive(false);
    }

    public void DoubleJumpChestMessageMethod()
    {
        DoubleJumpChestMessage.SetActive(true);
        Invoke("DoubleJumpChestMessageMethodOff", visibleTime);

    }
    public void DoubleJumpChestMessageMethodOff()
    {
        DoubleJumpChestMessage.SetActive(false);
    }

    public void BossKeyChestMessageMethod()
    {
        bossKeyChestMessage.SetActive(true);
        Invoke("BossKeyChestMessageMethodOff", visibleTime);
    }

    public void BossKeyChestMessageMethodOff()
    {
        bossKeyChestMessage.SetActive(false);
    }

    public void bossKeyRoomMessageMethod()
    {
        bossKeyRoomMessage.SetActive(true);
        Invoke("bossKeyRoomMessageMethodOff", visibleTime);
    }
    public void bossKeyRoomMessageMethodOff()
    {
        bossKeyRoomMessage.SetActive(false);
    }

    public void SecretBossKeyRoomChestMessageMethod()
    {
        SecretBossKeyRoomChestMessage.SetActive(true);
        Invoke("SecretBossKeyRoomChestMessageMethodOff", visibleTime);
    }

    public void SecretBossKeyRoomChestMessageMethodOff()
    {
        SecretBossKeyRoomChestMessage.SetActive(false);
    }
    public void bossKeyRoomChestMessageMethod()
    {
        bossKeyRoomChestMessage.SetActive(true);
        Invoke("bossKeyRoomChestMessageMethodOff", visibleTime);
    }

    public void bossKeyRoomChestMessageMethodOff()
    {
        bossKeyRoomChestMessage.SetActive(false);
    }



    public void ShowInteractText(string name)
    {

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
