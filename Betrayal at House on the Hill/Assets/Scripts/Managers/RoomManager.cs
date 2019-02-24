using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> Rooms = new List<Room>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpConnectedRoomsFor(Room room)
    {
        string[] connectedRooms = RoomFactory.GetRoomJsonWithName(room.Name).ConnectedRooms;
        foreach (string roomName in connectedRooms)
        {
            room.ConnectedRooms.Add(GetRoomWithName(roomName));
        }
    }

    private Room GetRoomWithName(string name)
    {
        return Rooms.Where(r => r.Name == name).First();
    }
}
