using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    bool available = true;
    private Vector2Int GridSize = new Vector2Int(60, 60);

    private Building[,] grid;
    private Building flyingBuilding;
    public Camera mainCamera;
    public GameObject placementSurface; // Объект, на который можно размещать строения
    

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == placementSurface)
                    {
                        available = true;
                    }
                    else
                    {
                        available = false;
                    }
                }

                flyingBuilding.transform.position = new Vector3(x, 0, y);
                flyingBuilding.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    flyingBuilding.SetNormal();
                    flyingBuilding = null;
                }
            }
        }
    }
}
