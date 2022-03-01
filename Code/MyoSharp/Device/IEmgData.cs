﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyoSharp.Device
{
    /// <summary>
    /// An interface that defines functionality for working with EMG data.
    /// </summary>
    public interface IEmgData
    {
        #region Methods
        /// <summary>
        /// Gets the EMG data for specified sensor.
        /// </summary>
        /// <param name="sensor">The index of the sensor. Must be greater than or equal to zero.</param>
        /// <returns>The data for the specified sensor or zero if the sensor does not exist.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="sensor"/> is less than zero.
        /// </exception>
        int GetDataForSensor(int sensor);
        #endregion
    }
}
