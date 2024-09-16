﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPossible.UI.Dragging
{
    /// <summary>
    /// Components that implement this interfaces can act as the source for
    /// dragging a `DragItem`.
    /// </summary>
    /// <typeparam name="T">The type that represents the item being dragged.</typeparam>
    public interface IDragSource<T> where T : class
    {
        /// <summary>
        /// What item type currently resides in this source?
        /// </summary>
        T GetItem();

        /// <summary>
        /// Remove a given number of items from the source.
        /// </summary>
        void RemoveItem();

    }
}