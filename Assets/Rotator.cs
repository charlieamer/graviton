using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Rotator : MonoBehaviour
{
    public float translationSpeed = 1f;
    public float rotationSpeed = 100f;
}

public class RotatorSystem : ComponentSystem
{
    struct Components
    {
        public Rotator rotator;
        public Transform transform;
        public Transform originalPosition;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;

        foreach (var e in GetEntities<Components>())
        {
            //e.transform.Translate(e.rotator.translationSpeed * deltaTime, 0f, 0f);
            e.transform.Rotate(0, e.rotator.rotationSpeed * deltaTime, 0);
        }
    }
}
