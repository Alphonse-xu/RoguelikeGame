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
    private GameObject endRoom;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;


    public List<Room> rooms = new List<Room> ();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
           rooms.Add( Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());

            //change point position
            ChangePointPos();
        }
        rooms[0].GetComponent<SpriteRenderer>().color = startColor;//改变第1个房间的颜色

        endRoom = rooms[0].gameObject;

        //找到房间
        foreach (var room in rooms)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}
            SetupRoom(room, room.transform.position);


        }
        endRoom.GetComponent<SpriteRenderer>().color = endColor;//改变房间的颜色

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 生成随机地图
    /// 建立一个空的 GameObject 用来做创建房间的点，设置坐标(0,0,0)。
    /// 每创建1个房间之后，随机在上、下、右判断是否有房间，若没有就创建一个新的房间；若已经有房间，则再次随机切换周围四个方向位置。
    /// </summary>
    public void ChangePointPos()
    {
        do  //循环检测生成的地图是否重合
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
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));
    }

    public void SetupRoom(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);
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
