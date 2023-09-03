using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitWinLose : IEcsInitSystem {
        public void Init (IEcsSystems systems) {
            var winZoneGO = GameObject.FindGameObjectWithTag("WinZone");
            var winPanelGO = GameObject.FindGameObjectWithTag("WinPanel");
            var obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
            var losePanel = GameObject.FindGameObjectWithTag("LosePanel");
            var world = systems.GetWorld();
            var winZoneEntity = world.NewEntity();
            var winPanelEntity = world.NewEntity(); 
           
            var losePanelEntity = world.NewEntity();

            ref var winZoneComponent = ref world.GetPool<WinZoneComponent>().Add(winZoneEntity);
            winZoneComponent.WinZone = winZoneGO;
            winZoneComponent.collider = winZoneGO.GetComponent<Collider>();

            ref var winPanelComponent = ref world.GetPool<WinPanelComponent>().Add(winPanelEntity);
            winPanelComponent.WinPanel = winPanelGO;

            ref var losePanelComponent = ref world.GetPool<LosePanelComponent>().Add(losePanelEntity);
            losePanelComponent.losePanel = losePanel;
            foreach (var obstaclesGO in obstacles)
            {
                var obstaclesEntity = world.NewEntity();
                ref var obstaclesComponent = ref world.GetPool<ObstaclesComponent>().Add(obstaclesEntity);              
                obstaclesComponent.collider = obstaclesGO.GetComponent<Collider>();
                obstaclesComponent.obstacles = obstaclesGO;
            }

        }
    }
}