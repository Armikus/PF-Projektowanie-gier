using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject zoomCard;

    Vector3 startSize;

    public void Awake() {
        Canvas = GameObject.Find("Background");
    }

    void Start() {
    }

    void Update()
    {
    }

    public void startHover() {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, 650), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);

        zoomCard.transform.localScale = new Vector3(2, 2, 2);
    }

    public void endHover() {
        Destroy(zoomCard);
    }
}
