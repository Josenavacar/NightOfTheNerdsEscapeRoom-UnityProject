using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BinaryScene : MonoBehaviour
{
    public List<GameObject> lines;

    public GameObject NoPowerPanel;

    // Start is called before the first frame update
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            this.gameObject.SetActive(false);
        }

        CheckIfEnabled();
    }

    void CheckIfEnabled()
    {
        bool isPuzzleEnabled = true;
        foreach(GameObject line in lines)
        {
            if(!line.GetComponent<MovingNumbers>().lineEnabled)
            {
                isPuzzleEnabled = false;
            }
        }

        if(isPuzzleEnabled)
        {
            NoPowerPanel.SetActive(false);
        }
        else
        {
            NoPowerPanel.SetActive(true);
        }
    }
}
