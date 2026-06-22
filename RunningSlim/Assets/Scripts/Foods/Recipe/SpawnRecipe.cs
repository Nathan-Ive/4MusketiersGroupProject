using UnityEngine;

public class SpawnRecipe : MonoBehaviour
{
    [SerializeField] private GameObject recipes;
    public void OnMouseDown()
    {
        GameObject recipe = (GameObject)Instantiate(recipes, transform.position, transform.rotation);

    }
}
