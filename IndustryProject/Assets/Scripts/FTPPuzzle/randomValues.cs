using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomValues : MonoBehaviour
{
    public TMPro.TextMeshProUGUI shownNumber;
    public int secondsBetweenChange = 1;
    public int currentNumber = 0;
    public anchorPuzzlePiece anchorParent;

    private bool waitTimeIsDone = true;
    private IEnumerator couroutine;
    public bool keepRandoming = true;
    private void Start()
    {
        anchorParent = GetComponentInParent<anchorPuzzlePiece>();
        shownNumber = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Update()
    {
        shownNumber.text = currentNumber.ToString();
        RandomGenerator();
        StopRandomGenerator();
    }
    public void RandomGenerator()
    {
        if (keepRandoming)
        {
            if (waitTimeIsDone)
            {
                //Debug.Log("number change");
                waitTimeIsDone = false;
                currentNumber = Random.Range(1, 100);
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
    public void StopRandomGenerator()
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
}
