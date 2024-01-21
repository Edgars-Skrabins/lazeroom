using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private Vector2 mousePos;

    void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
