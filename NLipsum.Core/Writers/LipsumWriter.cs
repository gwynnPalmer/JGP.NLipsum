﻿using NLipsum.Core.Factories;
using NLipsum.Core.Models;

namespace NLipsum.Core.Writers;

/// <summary>
///     Interface ILipsumWriter
/// </summary>
public interface ILipsumWriter
{
    /// <summary>
    ///     Writes the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    string Write(LipsumMap map);
}

/// <summary>
///     Class LipsumWriter.
/// </summary>
public class LipsumWriter : ILipsumWriter
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LipsumWriter" /> class.
    /// </summary>
    public LipsumWriter()
    {
    }

    /// <summary>
    ///     Writes the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    public string Write(LipsumMap map)
    {
        return FeatureGeneratorFactory
            .GetInstance(map.FeatureType)
            .Generate(map);
    }
}