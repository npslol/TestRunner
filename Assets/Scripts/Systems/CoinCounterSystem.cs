using Leopotam.EcsLite;

namespace Client {

    sealed class CoinCounterSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var coinCounterPool = world.Filter<CoinCounterComponent>().End();

            foreach (int coinCounterEntity in coinCounterPool)
            {
                ref CoinCounterComponent coinCounterComponent = ref world.GetPool<CoinCounterComponent>().Get(coinCounterEntity);
                coinCounterComponent.coinText.text = coinCounterComponent.collectedCoins.ToString();
            }
        }
    }


}