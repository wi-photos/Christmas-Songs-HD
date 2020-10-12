// Register when mouse dragging has ended. OnMouseUp is called
// when the mouse button is released.

using UnityEngine;

public class ChangeScene : MonoBehaviour
{
public int SceneID; 

    void OnMouseUp()
    {
	Application.LoadLevel (SceneID);
    }
}