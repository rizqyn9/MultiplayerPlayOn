using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Obstacle;

namespace Map1
{
    public class Map_1_Handler : NetworkBehaviour
    {
        public Rotator[] rotators;

        [ContextMenu(nameof(startMapHandler))]
        public void startMapHandler()
        {
            foreach(Rotator rotator in rotators)
            {
                rotator.isStarted = true;
            }
        }
    }
}
