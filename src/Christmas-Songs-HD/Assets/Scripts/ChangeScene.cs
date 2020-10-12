// Register when mouse dragging has ended. OnMouseUp is called
// when the mouse button is released.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{


	public void LoadScene (int SceneID) 
	{
		SceneManager.LoadScene(SceneID);
		
	}
}