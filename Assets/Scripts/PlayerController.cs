using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject playArea;

    [SerializeField]
    bool hideArea = true;

    // Start is called before the first frame update
    void Start()
    {
        if (hideArea) playArea.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = NormalizeVector3(Input.mousePosition);
        if (IsMouseOverPlayArea(mousePos))
        {
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = NormalizeVector3(worldPos);
        }
        
    }

    bool IsMouseOverPlayArea(Vector3 mousePos)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = mousePos
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        foreach (var item in results)
        {
            if(item.gameObject == playArea) return true;
        }
        return false;

    }

    Vector3 NormalizeVector3(Vector3 input)
    {
        return new Vector3(input.x, input.y, 0);
    }
}
