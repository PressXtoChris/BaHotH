using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string Name { get; private set; }
    public Floor Floor { get; private set; }
    public Card? Card { get; private set; }

    private bool _canExitNorth;
    private bool _canExitEast;
    private bool _canExitSouth;
    private bool _canExitWest;

    public Room NorthRoom;
    public Room EastRoom;
    public Room SouthRoom;
    public Room WestRoom;

    // Other rooms that this room is connecting to, excluding the NESW rooms.
    public List<Room> ConnectedRooms;

    public Trait? ExitRollTrait { get; private set; }
    public int ExitRollTarget { get; private set; }

    public void InitialiseValues(RoomFactory.RoomJson roomJson)
    {
        Name = roomJson.Name;
        Floor = roomJson.Floor;

        _canExitNorth = roomJson.CanExitNorth;
        _canExitEast = roomJson.CanExitEast;
        _canExitSouth = roomJson.CanExitSouth;
        _canExitWest = roomJson.CanExitWest;
    }
}
