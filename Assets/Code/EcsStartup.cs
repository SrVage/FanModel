using Client.Components.Interaction;
using Client.Systems.Initial;
using Client.Systems.Input;
using Client.Systems.Interactable;
using Client.Systems.Rotating;
using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourEntity[] _entities;
        [SerializeField] private float _mouseSensetivity;
        EcsWorld _world;
        EcsSystems _systems;
        

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            Application.targetFrameRate = 60;
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add (new InitialSceneSystem(_entities))
                .Add(new MouseClickHandlerSystem())
                .Add(new MouseRightClickHandlerSystem(_mouseSensetivity))
                .Add(new FanToggleSystem())
                .Add (new FanRotatingSystem())
                
                // register one-frame components (order is important), for example:
                .OneFrame<IsTriggeredTag> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}