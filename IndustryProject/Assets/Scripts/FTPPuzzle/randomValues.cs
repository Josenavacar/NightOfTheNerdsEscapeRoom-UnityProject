using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomValues : MonoBehaviour
{
    public TMPro.TextMeshProUGUI shownNumber;
    public int secondsBetweenChange = 1;
    public int currentNumber = 0;
    public anchorPuzzlePiece anchorParent;
    public int output;

    private bool waitTimeIsDone = true;
    private IEnumerator couroutine;
    public bool keepRandoming = true;
    public bool isCompleted = false;
    private void Start()
    {
        anchorParent = GetComponentInParent<anchorPuzzlePiece>();
        shownNumber = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Update()
    {
        if (!isCompleted)
        {
            shownNumber.text = currentNumber.ToString();
            RandomGenerator();
            CheckAnchor();
        }
    }
    public void RandomGenerator()
    {
        if (keepRandoming)
        {
            if (waitTimeIsDone)
            {
                //Debug.Log("number change");
                waitTimeIsDone = false;
                int check =  Random.Range(0,100);
                if (check == output)
                {
                    currentNumber = check - 1;
                }
                else
                {
                    currentNumber = check;
                }
                couroutine = waitTime();
                StartCoroutine(couroutine);
            }
        }
    }
    public IEnumerator waitTime()
    {
        yield return new WaitForSeconds(secondsBetweenChange);
        waitTimeIsDone = true;
    }
    public void CheckAnchor()
    {
        if (anchorParent.occupyingPiece != null)
        {
            keepRandoming = false;
            //Debug.Log("Stop randoming");
        }
        if (anchorParent.occupyingPiece == null)
        {
            keepRandoming = true;
        }
    }
    private void OnEnable()
    {
        keepRandoming = true;
        waitTimeIsDone = true;
    }
    private void OnDisable()
    {
        keepRandoming = false;
        waitTimeIsDone = false;
    }
}
