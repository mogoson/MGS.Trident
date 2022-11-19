/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GizmosEditor.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/19/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.Trident
{
    public class GizmosEditor
    {
        [MenuItem("Tool/Trident/Gizmos/Add Bounds Gizmos %G")]
        static void AddBoundsGizmos()
        {
            var selects = Selection.GetTransforms(SelectionMode.Unfiltered);
            if (selects.Length == 0)
            {
                return;
            }

            foreach (var select in selects)
            {
                var gizmos = select.GetComponent<BoundsGizmos>();
                if (gizmos == null)
                {
                    gizmos = select.gameObject.AddComponent<BoundsGizmos>();
                }
                gizmos.enabled = true;
            }
        }

        [MenuItem("Tool/Trident/Gizmos/Remove Bounds Gizmos %#G")]
        static void RemoveBoundsGizmos()
        {
            DestroyImmediate<BoundsGizmos>();
        }

        [MenuItem("Tool/Trident/Gizmos/Remove All Gizmos %&G")]
        static void RemoveAllGizmos()
        {
            DestroyImmediate<TridentGizmos>();
        }

        static void DestroyImmediate<T>() where T : Object
        {
            var objs = Object.FindObjectsOfType<T>();
            foreach (var obj in objs)
            {
                Object.DestroyImmediate(obj);
            }
        }
    }
}