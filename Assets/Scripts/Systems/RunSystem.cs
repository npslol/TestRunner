using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class RunSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var go = GameObject.FindGameObjectWithTag("Player");

            var runnerFilter = world.Filter<RunnerComponent>().End();
            var runnerPool = world.GetPool<RunnerComponent>();

            foreach (int entity in runnerFilter)
            {
                ref RunnerComponent runnerComponent = ref runnerPool.Get(entity);

                if (Input.GetMouseButtonDown(0))
                    runnerComponent.lastMousePos = Input.mousePosition;
                else if (Input.GetMouseButton(0))
                {
                    runnerComponent.animator.SetBool("IsRunning", true);
                    Vector3 mouseDelta = Input.mousePosition - runnerComponent.lastMousePos;
                    float horizontalInput = mouseDelta.x / Screen.width;
                    float newPositionX = Mathf.Clamp(
                        go.transform.position.x + horizontalInput * runnerComponent.moveSpeed * Time.deltaTime,
                        runnerComponent.minPosX,
                        runnerComponent.maxPosX
                    );
                    go.transform.position = new Vector3(newPositionX, go.transform.position.y, go.transform.position.z);
                    runnerComponent.lastMousePos = Input.mousePosition;
                }
                else
                    runnerComponent.animator.SetBool("IsRunning", false);
            }
        }
    }
}
