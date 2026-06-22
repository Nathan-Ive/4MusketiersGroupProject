using UnityEngine;

public class RemoveRecipe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
