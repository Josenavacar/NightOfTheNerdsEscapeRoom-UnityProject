using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDController : MonoBehaviour
{

    [System.Serializable]
    public class ButtonCombination
    {
        public Button button;
        public GameObject LED;
        public bool isGreen;
    }

    public List<ButtonCombination> buttons;

    [Header("Puzzle Reset")]
    public float timeUntilReset;

    bool isTimerRunning = false;
    bool isPuzzleComplete = false;
    
    public GameObject LEDPuzzleCanvas;
    public GameObject binaryPuzzleCanvas;
    public List<GameObject> binaryLines;

    /**
    public Button _buttonOne;
    public Button _buttonTwo;
    public Button _buttonThree;

    [Header("LED's")]
    public GameObject _ledOne;
    public GameObject _ledTwo;
    public GameObject _ledThree;

    bool ledOneIsGreen = false;
    bool ledTwoIsGreen = false;
    bool ledThreeIsGreen = false;

    bool isPuzzleComplete = false;
    [Header("Puzzle Reset")]
    public float timeUntilReset;
    private float countdown;
    **/

    // Start is called before the first frame update
    void Start()
    {
        //instead of manually creating/coding each button this instead offers a more efficient solution to adding more buttons. 
        int i = 0;
        foreach (var bc in buttons)
        {
            int CapturedI = i;
            bc.button.onClick.AddListener(() =>
            {
                buttonClick(CapturedI);
            });
            i += 1;
        }
        
        /**
                //Calls ButtonOnClick method when button clicked
                _buttonOne.onClick.AddListener(ButtonOneClick);
                _buttonTwo.onClick.AddListener(ButtonTwoClick);
                _buttonThree.onClick.AddListener(ButtonThreeClick);

                //setting default state of LED
                _ledOne.GetComponent<Image>().color = Color.red;
                _ledTwo.GetComponent<Image>().color = Color.red;
                _ledThree.GetComponent<Image>().color = Color.red;
                
                //grabbing value stored in inspector
                countdown = timeUntilReset;
        **/
    }

    // Update is called once per frame
    void Update()
    {
        //LedReset();
        PuzzleComplete();
    }

    public bool CheckAllGreen()
    {
        foreach (var bc in buttons)
        {
            if (!bc.isGreen)
            {
                return false;
            }
        }
        return true;
    }


    public void PuzzleComplete()
    {
        if (CheckAllGreen() && !isPuzzleComplete)
        {
            isPuzzleComplete = true;
            Debug.Log("Puzzle Complete!");

            foreach(GameObject line in binaryLines)
            {
                line.GetComponent<MovingNumbers>().lineEnabled = true;
            }
            LEDPuzzleCanvas.SetActive(false);
            binaryPuzzleCanvas.SetActive(true);
        }
    }

    public void buttonClick(int index)
    {
        Debug.Log("" + index);
        //var bc copies the memory of buttons[index]
        var bc = buttons[index];

        if (!bc.isGreen)
        {
            bc.LED.GetComponent<Image>().color = Color.green;
            bc.isGreen = true;
            Debug.Log("" + buttons[index].isGreen);

            if (!isTimerRunning)
            {
                isTimerRunning = true;
                StartCoroutine(RunResetTimer());
            }
        }
    }

    IEnumerator RunResetTimer()
    {
        yield return new WaitForSeconds(timeUntilReset);
        if (!isPuzzleComplete && isTimerRunning)
        {
            isTimerRunning = false;
            foreach (var bc in buttons)
            {
                bc.isGreen = false;
                bc.LED.GetComponent<Image>().color = Color.red;

            }
        }
    }







    /**
    public void LedReset()
    {
    
        if (ledOneIsGreen == true || ledTwoIsGreen == true || ledThreeIsGreen == true && isPuzzleComplete == false)
            timeUntilReset -= Time.deltaTime;
            if (timeUntilReset <= 0.0f)
            {
                _ledOne.GetComponent<Image>().color = Color.red;
                _ledTwo.GetComponent<Image>().color = Color.red;
                _ledThree.GetComponent<Image>().color = Color.red;
                ledOneIsGreen = false;
                ledTwoIsGreen = false;
                ledThreeIsGreen = false;

                //reset value stored in inspector
                timeUntilReset = countdown;
            }
   
    }
    **/


    /**
        //turns on LED
        public void ButtonOneClick()
        {
            if (ledOneIsGreen == false)
            {
                _ledOne.GetComponent<Image>().color = Color.green;
                ledOneIsGreen = true;
            }
        }

        //turns on LED
        public void ButtonTwoClick()
        {
            if (ledTwoIsGreen == false)
            {
                _ledTwo.GetComponent<Image>().color = Color.green;
                ledTwoIsGreen = true;
            }
        }

        //turns on LED
        public void ButtonThreeClick()
        {
            if (ledThreeIsGreen == false)
            {
                _ledThree.GetComponent<Image>().color = Color.green;
                ledThreeIsGreen = true;
            }
        }
    **/

}
