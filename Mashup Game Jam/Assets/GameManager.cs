using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private Camera cam;

    private List<int> portalNums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    [SerializeField] private GameObject[] portals = new GameObject[10];

    [SerializeField] private Vector2[] playerPos = new Vector2[10];
    [SerializeField] private Vector2[] cameraPos = new Vector2[10];

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        cam = Camera.main;

        // Assigns each portal a random number
        for (int i = 0; i < 10; i++)
        {
            int num = Random.Range(0, portalNums.Count);
            portals[i].GetComponent<Portal>().portalNum = portalNums[num];
            portalNums.RemoveAt(num);
        }
    }

    public void ToRoom(int num)
    {
        player.transform.position = new Vector3(playerPos[num - 1].x, playerPos[num - 1].y, player.transform.position.z);
        cam.transform.position = new Vector3(cameraPos[num - 1].x, cameraPos[num - 1].y, cam.transform.position.z);
    }
}
