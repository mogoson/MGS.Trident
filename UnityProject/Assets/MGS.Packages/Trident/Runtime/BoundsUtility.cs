/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BoundsUtility.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/19/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Trident
{
    public sealed class BoundsUtility
    {
        public static Bounds Encapsulate(List<Bounds> boundsItems)
        {
            var collectBounds = new Bounds(boundsItems[0].center, Vector3.zero);
            foreach (var bounds in boundsItems)
            {
                collectBounds.Encapsulate(bounds);
            }
            return collectBounds;
        }

        public static Bounds EncapsulateRenderer(GameObject root)
        {
            var renderers = root.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0)
            {
                return new Bounds(root.transform.position, Vector3.zero);
            }

            var bounds = new List<Bounds>();
            foreach (var renderer in renderers)
            {
                if (!renderer.enabled)
                {
                    continue;
                }
                bounds.Add(renderer.bounds);
            }

            if (bounds.Count == 0)
            {
                return new Bounds(root.transform.position, Vector3.zero);
            }

            return Encapsulate(bounds);
        }
    }
}