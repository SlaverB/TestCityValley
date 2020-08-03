using UnityEngine;

class GameManager: MonoBehaviour
{
    [SerializeField] TileMapManager _tileMap;
    private void Start()
    {
        ButtonPanel.GridButtonPressed += GhangeActivityOfTileMap;
    }

    private void GhangeActivityOfTileMap()
    {
        if(_tileMap.gameObject.activeSelf == true)
        {
            _tileMap.gameObject.SetActive(false);
        }
        else
        {
            _tileMap.gameObject.SetActive(true);
        }
    }
}
