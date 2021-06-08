using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotMovement : MonoBehaviour
{
    private GameObject Robot;
    private GameObject MazeLocation;
    private Vector3 centerPos;
    private Vector3 currentPos;
    private Vector3 setScale;
    private List<int> Movements;
    private TextMeshProUGUI MoveText;

    // Start is called before the first frame update
    void Start()
    {
        Movements = new List<int>();
        MoveText = GameObject.Find("MoveText").GetComponent<TextMeshProUGUI>() ;
        Robot = GameObject.Find("Robot");
        StartCoroutine(WaitForMaze());
    }

    IEnumerator WaitForMaze()
    {
        yield return new WaitForSeconds(2);
        MazeLocation = GameObject.Find("Cell-X:5Y:5");
        Robot.transform.SetParent(MazeLocation.transform, false);
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("Wait for 1 sec");
    }

    public void Execute()
    {
        StartCoroutine(ExecuteOne());
    }

    public IEnumerator ExecuteOne()
    {
        for (int i = 0; i < Movements.Count; i++)
        {
            Debug.Log(Movements[i]);
            if (Movements[i] == 1)
            {
                Debug.Log("Move North");
                currentPos = Robot.transform.position;
                currentPos.y += 75;
                Robot.transform.position = currentPos;
            }
            else if (Movements[i] == 2)
            {
                Debug.Log("Move South");
                currentPos = Robot.transform.position;
                currentPos.y -= 75;
                Robot.transform.position = currentPos;
            }
            else if (Movements[i] == 3)
            {
                Debug.Log("Move East");
                currentPos = Robot.transform.position;
                currentPos.x += 75;
                Robot.transform.position = currentPos;
            }
            else if (Movements[i] == 4)
            {
                Debug.Log("Move West");
                currentPos = Robot.transform.position;
                currentPos.x -= 75;
                Robot.transform.position = currentPos;
            }

            yield return StartCoroutine("WaitForMove");
        }
    }

    public void Reset()
    {
        Movements = new List<int>();
        MoveText.text = "";
    }

    public void MoveNorth()
    {
        Movements.Add(1);
        MoveText.text += (Movements.Count.ToString()) + " Move North" + "\t";
    }

    public void MoveSouth()
    {
        Movements.Add(2);

        MoveText.text += (Movements.Count.ToString()) + " Move South" + "\t";
    }

    public void MoveEast()
    {
        Movements.Add(3);

        MoveText.text += (Movements.Count.ToString()) + " Move East" + "\t";
    }

    public void MoveWest()
    {
        Movements.Add(4);

        MoveText.text += (Movements.Count.ToString()) + " Move West" + "\t";
    }
}
