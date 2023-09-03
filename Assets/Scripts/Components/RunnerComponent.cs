using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    struct RunnerComponent
    {
        public Animator animator;
        public float moveSpeed;
        public float minPosX;
        public float maxPosX;
        public Vector3 lastMousePos;
        public Collider Collider;
    }
    struct CoinComponent
    {
        public Collider collider;
        public GameObject CoinObject;
    }
    struct CoinCounterComponent
    {
        public int collectedCoins;
        public Text coinText;
    }
    struct WinZoneComponent
    {
        public GameObject WinZone;
        public Collider collider;
    }
    struct WinPanelComponent
    {
        public GameObject WinPanel;
    }
     struct LosePanelComponent
    {
        public GameObject losePanel;
    }
    struct ObstaclesComponent
    {
        public GameObject obstacles;
        public Collider collider;
    }
}
