using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour

{
    [Header("Direction Events")]
    public UnityEvent<Vector2Int> OnDirectionPressed; //For individual inputs
    public UnityEvent<Vector2Int> OnDirectionHeld; //For continuous inputs
   

    void Update()
    {

        // Directions - after modifiers so speed flags are set
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnDirectionPressed?.Invoke(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            OnDirectionPressed?.Invoke(Vector2Int.right);

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
            OnDirectionHeld?.Invoke(Vector2Int.left);
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
            OnDirectionHeld?.Invoke(Vector2Int.right);
    }
}

//The "?" is important, since it confirms whether or not something is null, and if it is, it won't call the Invoke if nothing is listening.
//Only remove the "?" if you want to test whether or not input functions when you have nothing to receive those inputs. And remember to put it back if you do.
