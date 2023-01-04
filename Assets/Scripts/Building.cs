using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 buildingSize;
    [SerializeField] private Renderer renderer;

    public Vector2 BuildingSize => buildingSize;

    public void SetColor(bool isAvailableToBuild)
    {
        if (isAvailableToBuild)
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.red;
    }

    public void ResetColor()
    {
        renderer.material.color = Color.white;
    }
}
