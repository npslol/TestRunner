using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class InitPlayer : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            var world = systems.GetWorld();
            var entity = world.NewEntity();

            ref var runnerComponent = ref world.GetPool<RunnerComponent>().Add(entity);
            runnerComponent.animator = go.GetComponent<Animator>();
            runnerComponent.moveSpeed = 200f;
            runnerComponent.minPosX = -1.35f;
            runnerComponent.maxPosX = 1.4f;
            runnerComponent.lastMousePos = Vector3.zero;
            runnerComponent.Collider = go.GetComponent<Collider>();
        }
    }
}
