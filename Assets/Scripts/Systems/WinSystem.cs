using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class WinSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var playerFilter = world.Filter<RunnerComponent>().End();
            var winPanelFilter = world.Filter<WinPanelComponent>().End();
            var winZoneFilter = world.Filter<WinZoneComponent>().End();

            foreach (int playerEntity in playerFilter)
            {
                ref RunnerComponent playerComponent = ref world.GetPool<RunnerComponent>().Get(playerEntity);

                foreach (int winPanelEntity in winPanelFilter)
                {
                    ref WinPanelComponent winPanelComponent = ref world.GetPool<WinPanelComponent>().Get(winPanelEntity);
               
                    foreach (int winZoneEntity in winZoneFilter)
                    {
                        ref WinZoneComponent winZoneComponent = ref world.GetPool<WinZoneComponent>().Get(winZoneEntity);

                        if (winZoneComponent.collider.bounds.Intersects(playerComponent.Collider.bounds))
                        {
                            winPanelComponent.WinPanel.gameObject.SetActive(true);
                           playerComponent.animator.SetBool("IsRunning", false);
                           playerComponent.moveSpeed = 0;

                            break;
                        }
                        else { winPanelComponent.WinPanel.gameObject.SetActive(false); }
                    }
                }
            }
        }
    }
}