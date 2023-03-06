using System.Collections.Generic;
using UnityEngine;
using Utilites;

namespace SnowyMountain.SlopeManagment
{
    public class SlopeManager : MonoBehaviour
    {
        [field: SerializeField]
        private int NumberOfSlopeToGenerate { get; set; }
        [field: SerializeField]
        private Vector3 SpawnOffset { get; set; }

        private Queue<GameObject> SlopeCollection { get; set; } = new();
        private Vector3 SpawnPosition { get; set; }
        private SlopeType LastSlopeType { get; set; }

        private const string SLOPE_ID = "SLOPE";

        protected virtual void Awake ()
        {
            GenerateStartSlope();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.T)) //USE TO DEBUG, REMOVE LATER
            {
                DespawnSlope();
                SpawnSlope();
            }
        }

        private void GenerateStartSlope ()
        {
            for (int index = 0; index < NumberOfSlopeToGenerate; index++)
            {
                SpawnSlope();
            }
        }

        private void SpawnSlope ()
        {
            GameObject slope = ObjectPooler.Instance.SpawnFromPool(SLOPE_ID, SpawnPosition, Quaternion.identity);
            slope.transform.SetParent(transform);
            SpawnPosition += SpawnOffset;

            SlopeDrawController drawController = slope.GetComponent<SlopeDrawController>();
            SlopeType lastDrawnType = drawController.DrawSlopeVariant(LastSlopeType);
            LastSlopeType = lastDrawnType;

            SlopeCollection.Enqueue(slope);
        }

        private void DespawnSlope ()
        {
            ObjectPooler.Instance.DespawnToPool(SLOPE_ID, SlopeCollection.Dequeue());
        }
    }
}