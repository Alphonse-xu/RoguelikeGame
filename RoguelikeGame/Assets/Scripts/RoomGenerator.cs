using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;


public class RoomGenerator : MonoBehaviour
{
    public enum Direction { up,down,left,right};
    public Direction direction;

    [Header("地图信息")]
    public int roomLevel = 1;   //当前层数等级（初始在第一层）
    public int mapLength = 4;   //地图边长，房间数量


    [Header("房间信息")]
    public int maxRoomNum = 20;   //生成最多房间的数量
    public int minRoomNum = 10;  //生成最少房间的数量
    public int genRoomNum;  //生成房间的数量
    public List<Vector2> roomId = new List<Vector2>();  //存储每个房间的编号
    public List<Vector2> roomVisited = new List<Vector2>();     //存储玩家经过的房间
    public List<Vector2> roomNotVisited = new List<Vector2>();     //存储玩家没有去过的房间



    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;

    public List<GameObject> rooms = new List<GameObject> ();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
           rooms.Add( Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity));

            //change point position
            ChangePointPos();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangePointPos()
    {
        direction = (Direction)Random.Range(0, 4);

        switch (direction)
        {
            case Direction.up:
                generatorPoint.position += new Vector3(0, yOffset, 0);
                break;
            case Direction.down:
                generatorPoint.position += new Vector3(0, -yOffset, 0);
                break;
            case Direction.left:
                generatorPoint.position += new Vector3(-xOffset, 0, 0);
                break;
            case Direction.right:
                generatorPoint.position += new Vector3(xOffset, 0, 0);
                break;
        }
    }

    /// <summary>
    /// 生成地图
    /// </summary>
    public void GenerateRoom()
    {
        roomId.Add(new Vector2(mapLength, mapLength));

        genRoomNum = Random.Range(minRoomNum, maxRoomNum);

        while (roomId.Count < genRoomNum)
        {

        }

    }

}
