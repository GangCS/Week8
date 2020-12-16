using UnityEngine;

/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class KeyboardMoverQ6 : MonoBehaviour
{
    protected Vector3 dir;//Saves the target moving's position for Carving

    protected Vector3 NewPosition()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = Vector3.left;
            return transform.position + Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector3.right;
            return transform.position + Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector3.down;
            return transform.position + Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Vector3.up;
            return transform.position + Vector3.up;
        }
        else
        {
            return transform.position;
        }
    }


    void Update()
    {
        transform.position = NewPosition();
    }
}
