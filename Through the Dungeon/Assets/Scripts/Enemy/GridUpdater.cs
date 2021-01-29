using System;
using UnityEngine;

namespace Enemy
{
    public class GridUpdater : MonoBehaviour
    {
        public void Start()
        {
            InvokeRepeating(nameof(UpdateAStarGrids), 0.2f, 0.2f);
        }

        private void UpdateAStarGrids()
        {
            AstarPath.active.Scan();
        }
    }
}