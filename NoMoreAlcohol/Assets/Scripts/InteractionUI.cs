using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{

    //declaration of our variables
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

        //setting our variables to false
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

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void bossRoomMessageMethod()
    {
        bossRoomMessage.SetActive(true);
        Invoke("bossRoomMessageMethodOff", visibleTime);
    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void bossRoomMessageMethodOff()
    {
        bossRoomMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void DoorMessageSecretBossKeyRoomMethod()
    {
        DoorMessageSecretBossKeyRoom.SetActive(true);
        Invoke("DoorMessageSecretBossKeyRoomMethodOff", visibleTime);
    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void DoorMessageSecretBossKeyRoomMethodOff()
    {
        DoorMessageSecretBossKeyRoom.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void SecretBossKeyMessageMethod()
    {
        SecretBossKeyMessage.SetActive(true);
        Invoke("SecretBossKeyMessageMethodOff", visibleTime);
    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void SecretBossKeyMessageMethodOff()
    {
        SecretBossKeyMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void SecretBossMessageMethod()
    {
        SecretBossMessage.SetActive(true);
        Invoke("SecretBossMessageMethodOff", visibleTime);

    }

    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void SecretBossMessageMethodOff()
    {
        SecretBossMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void DoubleJumpChestMessageMethod()
    {
        DoubleJumpChestMessage.SetActive(true);
        Invoke("DoubleJumpChestMessageMethodOff", visibleTime);

    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void DoubleJumpChestMessageMethodOff()
    {
        DoubleJumpChestMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void BossKeyChestMessageMethod()
    {
        bossKeyChestMessage.SetActive(true);
        Invoke("BossKeyChestMessageMethodOff", visibleTime);
    }

    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void BossKeyChestMessageMethodOff()
    {
        bossKeyChestMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void bossKeyRoomMessageMethod()
    {
        bossKeyRoomMessage.SetActive(true);
        Invoke("bossKeyRoomMessageMethodOff", visibleTime);
    }

    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void bossKeyRoomMessageMethodOff()
    {
        bossKeyRoomMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void SecretBossKeyRoomChestMessageMethod()
    {
        SecretBossKeyRoomChestMessage.SetActive(true);
        Invoke("SecretBossKeyRoomChestMessageMethodOff", visibleTime);
    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void SecretBossKeyRoomChestMessageMethodOff()
    {
        SecretBossKeyRoomChestMessage.SetActive(false);
    }

    /**
     * Method a message showned next to a interactable
     *
     * @param none
     */
    public void bossKeyRoomChestMessageMethod()
    {
        bossKeyRoomChestMessage.SetActive(true);
        Invoke("bossKeyRoomChestMessageMethodOff", visibleTime);
    }
    /**
     * Method to set the message off (above one)
     *
     * @param none
     */
    public void bossKeyRoomChestMessageMethodOff()
    {
        bossKeyRoomChestMessage.SetActive(false);
    }

    /**
     * Method to show a message depending on the trigger that is active
     *
     * @param name   //string that pass the name of the trigger to know which text we need to activate
     */

    public void ShowInteractText(string name)
    {
        //switch that let us decide which trigger was activated
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

    //we call this function to hide all the text when any trigger is active
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
