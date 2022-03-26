using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginLogic : MonoBehaviour
{
    EventSystem es;
    public Selectable firstInput;
    public Button returnButton;
 
    // Start is called before the first frame update
    void Start()
    {
    es = EventSystem.current;
    firstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Selectable previous = es.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }

        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = es.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }

        }else if (Input.GetKeyDown(KeyCode.Return))
        {
            returnButton.onClick.Invoke();
            Debug.Log("Button Pressed!");

        }
        
        
    }
}
