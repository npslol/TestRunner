using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class LoseSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var playerFilter = world.Filter<RunnerComponent>().End();
            var losePanelFilter = world.Filter<LosePanelComponent>().End();
            var obstaclesPool = world.GetPool<ObstaclesComponent>();
            var obstaclesFilter = world.Filter<ObstaclesComponent>().End();
            
            foreach (int playerEntity in playerFilter)
            {
                ref RunnerComponent playerComponent = ref world.GetPool<RunnerComponent>().Get(playerEntity);

                foreach (int losePanelEntity in losePanelFilter)
                {
                    ref LosePanelComponent losePanelComponent = ref world.GetPool<LosePanelComponent>().Get(losePanelEntity);

                    foreach (int obstaclesEntity in obstaclesFilter)
                    {
                        ref ObstaclesComponent obstaclesComponent = ref obstaclesPool.Get(obstaclesEntity);

                        if (obstaclesComponent.collider.bounds.Intersects(playerComponent.Collider.bounds))
                        {
                            losePanelComponent.losePanel.gameObject.SetActive(true);
                            Time.timeScale = 0;
                            break;
                        }
                        else { losePanelComponent.losePanel.gameObject.SetActive(false);
                            Time.timeScale = 1;
                        }
                    }
                }
            }
        }
    }
}