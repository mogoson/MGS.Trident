/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BoundsGizmos.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/19/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Trident
{
    public class BoundsGizmos : TridentGizmos
    {
        public Color color = Color.blue;
        public Bounds bounds;

        protected override void OnDrawGizmos()
        {
            bounds = BoundsUtility.EncapsulateRenderer(gameObject);
            Gizmos.color = color;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}