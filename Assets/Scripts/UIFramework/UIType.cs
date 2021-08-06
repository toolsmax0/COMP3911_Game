using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores information about a single UI, including names and paths
/// </summary>
public class UIType
{
    /// <summary>
    /// The UI name
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// The UI path
    /// </summary>
    public string Path { get; private set; }

    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }
}
