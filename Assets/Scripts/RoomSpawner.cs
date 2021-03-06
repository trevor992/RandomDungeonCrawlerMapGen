﻿using System;
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
            Invoke("Spawn", 1.0f);
        }
    }
    private void Spawn()
    {
        if (spawned == false && roomCountObj.GetRoomCounter() <= numRooms) {
            if (openingDirection == 1)
            {       
                rand = UnityEngine.Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = UnityEngine.Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = UnityEngine.Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = UnityEngine.Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            spawned = true;
            roomCountObj.IncrementCounter();           
        }else if(spawned == false && roomCountObj.GetRoomCounter() > numRooms)
        {
            //broke this snippet of code because the order of BottomRooms, TopRooms etc. is no longer guranteed
           for(int i = 0; i < templates.AllRooms.Length; i++)
            {
                if(templates.AllRooms[i].CompareTag(openingIdentifier))
                {
                    Instantiate(templates.AllRooms[i], transform.position, templates.AllRooms[i].transform.rotation);
                }
            }
            spawned = true;
            roomCountObj.IncrementCounter();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomSpawnPoint") && openingIdentifier.Length < 4 && other.GetComponent<RoomSpawner>().openingIdentifier.Length == 1)
        {
            if (!CheckForDupl(openingIdentifier, other.GetComponent<RoomSpawner>().openingIdentifier))
            {
                openingIdentifier += other.GetComponent<RoomSpawner>().openingIdentifier;
                openingIdentifier = SortString(openingIdentifier);
            }
            Destroy(other.gameObject);
        }else if (other.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }    
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
                rand = UnityEngine.Random.Range(0, templates.BottomRooms_2.Length);
                Instantiate(templates.BottomRooms_2[rand], transform.position, templates.BottomRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = UnityEngine.Random.Range(0, templates.TopRooms_2.Length);
                Instantiate(templates.TopRooms_2[rand], transform.position, templates.TopRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = UnityEngine.Random.Range(0, templates.LeftRooms_2.Length);
                Instantiate(templates.LeftRooms_2[rand], transform.position, templates.LeftRooms_2[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = UnityEngine.Random.Range(0, templates.RightRooms_2.Length);
                Instantiate(templates.RightRooms_2[rand], transform.position, templates.RightRooms_2[rand].transform.rotation);
            }
            spawned = true;
            roomCountObj.IncrementCounter();
        }
    }
}
