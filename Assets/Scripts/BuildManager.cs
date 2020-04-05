using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BuildManager: MonoBehaviour
    {
        public GameObject turretPrefab;

        private GameObject turretToBuild;

        public static BuildManager instance;

        private void Awake()
        {
            if( instance != null)
            {
                Debug.LogError("More than one manager at screen");
                return;
            }
            instance = this;
        }

        private void Start()
        {
            turretToBuild = turretPrefab; // for now
        }

        public GameObject GetTurretToBuild()
        {
            return turretToBuild;
        }
    }
}
