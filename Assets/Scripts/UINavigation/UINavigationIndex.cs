using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public sealed class UINavigationIndex
{
    public int GetNextFrom(IReadOnlyList<Image> uiElements, int currentIndex)
    {
        if (uiElements == null)
            throw new ArgumentNullException(nameof(uiElements));

        if (currentIndex == uiElements.Count - 1)
            return uiElements.ToList().FindIndex(element => element.gameObject.activeInHierarchy);

        if (uiElements[currentIndex + 1].gameObject.activeInHierarchy == false)
            return GetActiveElementIndex(uiElements, currentIndex + 1);

        return currentIndex + 1;
    }

    private int GetActiveElementIndex(IReadOnlyList<Image> uiElements, int start)
    {
        var last = uiElements.Count - 1;

        if (start == last)
            return uiElements.ToList().FindIndex(element => element.gameObject.activeInHierarchy);

        var next = start + 1;

        if (uiElements[next].gameObject.activeInHierarchy)
        {
            return next;
        }

        start += 1;
        return GetActiveElementIndex(uiElements, start);
    }
}