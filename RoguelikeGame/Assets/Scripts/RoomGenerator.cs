using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startcolor, endcolor;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xoffset;
    public float yoffset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
