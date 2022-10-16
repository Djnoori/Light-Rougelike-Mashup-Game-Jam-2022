using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<int> portalNums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    [SerializeField] private GameObject[] portals = new GameObject[10];

    void Start()
    {
        // Assigns each portal a random number
        for (int i = 0; i < 10; i++)
        {
            int num = Random.Range(0, portalNums.Count);
            portals[i].GetComponent<Portal>().portalNum = portalNums[num];
            portalNums.RemoveAt(num);
        }
    }

    public void ToRoom(string name)
    {
        SceneManager.LoadScene(name);
    }
}
