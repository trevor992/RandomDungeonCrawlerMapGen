using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // 1 ---> need bottom door
    // 2 ---> need top door
    // 3 ---> need left door
    // 4 ---> need right door
    public int openingDirection;
    public string openingIdentifier;

    private RoomTemplates templates;
    private RoomCounter roomCountObj;
    private int rand;
    public bool spawned = false;
    private int numRooms;

    private void Awake()
    {
        switch(openingDirection)
        {
            case 1:
                openingIdentifier = "B";
                break;
            case 2:
                openingIdentifier = "T";
                break;
            case 3:
                openingIdentifier = "L";
                break;

            case 4:
                openingIdentifier = "R";
                break;
        }
    }

    private void Start()
    {
        
        numRooms = UnityEngine.Random.Range(5, 15);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomCountObj = GameObject.FindGameObjectWithTag("Counter").GetComponent<RoomCounter>();
        if (gameObject.CompareTag("EntrySpawn_1"))
        {
            SpecialRoomSpawn();
        }
        else
        {
            Invoke("Spawn", 2.5f);
        }
    }
    private void Spawn()
    {
        if (spawned == false && roomCountObj.GetRoomCounter() <= numRooms) {
            if (openingDirection == 1)
            {       
                rand = UnityEngine.Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = UnityEngine.Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = UnityEngine.Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = UnityEngine.Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
            roomCountObj.IncrementCounter();           
        }else if(spawned == false && roomCountObj.GetRoomCounter() > numRooms)
        {
            switch (openingIdentifier)
            {
                case "B":
                    Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
                    break;
                case "L":
                    Instantiate(templates.leftRooms[1], transform.position, templates.leftRooms[1].transform.rotation);
                    break;
                case "R":
                    Instantiate(templates.rightRooms[2], transform.position, templates.rightRooms[2].transform.rotation);
                    break;
                case "T":
                    Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
                    break;
                case "BL":
                    Instantiate(templates.bottomRooms[6], transform.position, templates.bottomRooms[6].transform.rotation);
                    break;
                case "BR":
                    Instantiate(templates.bottomRooms[7], transform.position, templates.bottomRooms[7].transform.rotation);
                    break;
                case"BT":
                    Instantiate(templates.bottomRooms[2], transform.position, templates.bottomRooms[2].transform.rotation);
                    break;
                case "LR":
                    Instantiate(templates.leftRooms[2], transform.position, templates.leftRooms[2].transform.rotation);
                    break;
                case "LT":
                    Instantiate(templates.leftRooms[7], transform.position, templates.leftRooms[7].transform.rotation);
                    break;
                case "RT":
                    Instantiate(templates.rightRooms[7], transform.position, templates.rightRooms[7].transform.rotation);
                    break;
                case "BLR":
                    Instantiate(templates.bottomRooms[1], transform.position, templates.bottomRooms[1].transform.rotation);
                    break;
                case "BRT":
                    Instantiate(templates.bottomRooms[5], transform.position, templates.bottomRooms[5].transform.rotation);
                    break;
                case "LRT":
                    Instantiate(templates.leftRooms[5], transform.position, templates.leftRooms[5].transform.rotation);
                    break;
                case "BLT":
                    Instantiate(templates.bottomRooms[3], transform.position, templates.bottomRooms[3].transform.rotation);
                    break;
                case "BLRT":
                    Instantiate(templates.leftRooms[4], transform.position, templates.leftRooms[4].transform.rotation);
                    break;            
            }
            spawned = true;
            roomCountObj.IncrementCounter();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomSpawnPoint") && openingIdentifier.Length < 4 && other.GetComponent<RoomSpawner>().openingIdentifier.Length == 1)
        {
            //Debug.Log(" other's opening Identifier String: " + other.GetComponent<RoomSpawner>().openingIdentifier);
            //Debug.Log("This opening Identifiers String:  " + openingIdentifier);
            if (!CheckForDupl(openingIdentifier, other.GetComponent<RoomSpawner>().openingIdentifier))
            {
                openingIdentifier += other.GetComponent<RoomSpawner>().openingIdentifier;
                openingIdentifier = SortString(openingIdentifier);
                //Debug.Log(" other's opening Identifier String2: " + other.GetComponent<RoomSpawner>().openingIdentifier);
                //Debug.Log("This opening Identifiers String2:  " + openingIdentifier);
            }
            Destroy(other.gameObject);
        }else if (other.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
        //spawned = true;
    }

    private string SortString(string s)
    {
        char[] cArray = s.ToCharArray();
        Array.Sort(cArray);
        return new string(cArray);
    }

    private bool CheckForDupl(string s1, string s2)
    {
        char[] cArray1 = s1.ToCharArray();
        char[] cArray2 = s2.ToCharArray();
        return Array.Exists(cArray1, c => cArray2[0] == c);        
    }

    private void SpecialRoomSpawn()
    {
        if (spawned == false && roomCountObj.GetRoomCounter() <= numRooms)
        {
            if (openingDirection == 1)
            {
                rand = UnityEngine.Random.Range(0, templates.bottomRooms_2.Length);
                Instantiate(templates.bottomRooms_2[rand], transform.position, templates.bottomRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = UnityEngine.Random.Range(0, templates.topRooms_2.Length);
                Instantiate(templates.topRooms_2[rand], transform.position, templates.topRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = UnityEngine.Random.Range(0, templates.leftRooms_2.Length);
                Instantiate(templates.leftRooms_2[rand], transform.position, templates.leftRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = UnityEngine.Random.Range(0, templates.rightRooms_2.Length);
                Instantiate(templates.rightRooms_2[rand], transform.position, templates.rightRooms_2[rand].transform.rotation);
            }
            spawned = true;
            roomCountObj.IncrementCounter();
        }
    }
}
