using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMinimap : MonoBehaviour
{
    public GameObject RedDot = null;

    public GameObject Minimap = null;

    public GameObject Level = null;

    public Vector2 LevelSize;

    public Vector2 CentersMappingRatio;

    private Vector2 mapSize;

    // Start is called before the first frame update
    void Start()
    {
        if(Minimap)
        {
            Rect mapRect = Minimap.GetComponent<RectTransform>().rect;
            mapSize = new Vector2(mapRect.width, mapRect.height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Level && RedDot)
        {
            GameObject player = GameObject.FindGameObjectsWithTag ("Player")[0];

            Vector2 playerPos2D = new Vector2(player.transform.position.x, player.transform.position.z);

            Vector2 levelPos2D = new Vector2(Level.transform.position.x, Level.transform.position.z);

            Vector2 redDotPos = playerPos2D - levelPos2D;
            redDotPos /= LevelSize;
            redDotPos *= mapSize;

            Vector2 correctRatio = CentersMappingRatio;
            correctRatio.y = correctRatio.y * -1;
            redDotPos += mapSize * correctRatio;
            
            Vector3 mapping = new Vector3(-redDotPos.x, -redDotPos.y, 0);
            RedDot.transform.position = mapping + Minimap.transform.position;
        }
    }
}
