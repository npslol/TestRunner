using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    sealed class CoinCollectionSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var playerFilter = world.Filter<RunnerComponent>().End();
            var coinPool = world.GetPool<CoinComponent>();
            var coinFilter = world.Filter<CoinComponent>().End();
            var counterFilter = world.Filter<CoinCounterComponent>().End();
            foreach (int playerEntity in playerFilter)
            {
                ref RunnerComponent playerComponent = ref world.GetPool<RunnerComponent>().Get(playerEntity);
                foreach (int coinCounterEntity in counterFilter)
                {
                    ref CoinCounterComponent coinCounterComponent = ref world.GetPool<CoinCounterComponent>().Get(coinCounterEntity);
                    foreach (int coinEntity in coinFilter)
                    {
                        ref CoinComponent coinComponent = ref coinPool.Get(coinEntity);

                        if (coinComponent.collider.bounds.Intersects(playerComponent.Collider.bounds))
                        {
                            coinCounterComponent.collectedCoins++;
                            coinCounterComponent.coinText.text = coinCounterComponent.collectedCoins.ToString();
                            coinComponent.CoinObject.gameObject.SetActive(false);
                            world.DelEntity(coinEntity);
                            
                            break;
                        }
                    }
                }
            }
        }
    }
}
