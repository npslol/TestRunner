using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    sealed class InitCoin : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var coins = GameObject.FindGameObjectsWithTag("Coin");
            var counterObject = GameObject.FindGameObjectWithTag("Counter");
            var world = systems.GetWorld();
            var coinCounterEntity = world.NewEntity();
            ref var coinCounterComponent = ref world.GetPool<CoinCounterComponent>().Add(coinCounterEntity);
            coinCounterComponent.collectedCoins = 0;
            coinCounterComponent.coinText = counterObject.GetComponent<Text>();
            foreach (var coinGO in coins)
            {
                var entity = world.NewEntity();
                ref var coinComponent = ref world.GetPool<CoinComponent>().Add(entity);
                coinCounterComponent.coinText = counterObject.GetComponent<Text>();
                coinComponent.collider = coinGO.GetComponent<Collider>();
                coinComponent.CoinObject = coinGO;
            }
        }
    }
}
