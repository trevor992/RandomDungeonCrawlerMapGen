using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{
    private int roomCounter;

    private void Start()
    {
       roomCounter = 1;
    }
    public void IncrementCounter()
    {
        roomCounter++;
    }
    public int GetRoomCounter()
    {
        return roomCounter;
    }
    private void Update()
    {
        //Debug.Log(roomCounter);
    }
}
