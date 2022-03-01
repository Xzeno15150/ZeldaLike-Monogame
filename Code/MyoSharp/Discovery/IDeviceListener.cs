﻿using System;

using MyoSharp.Communication;

namespace MyoSharp.Discovery
{
    /// <summary>
    /// An interface that defines functionality for listening to device connectivity.
    /// </summary>
    public interface IDeviceListener : IDisposable
    {
        #region Events
        /// <summary>
        /// The event that is triggered when a device has paired.
        /// </summary>
        event EventHandler<PairedEventArgs> Paired;

        /// <summary>
        /// The event that is triggered when a device has been unpaired.
        /// </summary>
        event EventHandler<PairedEventArgs> Unpaired;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <see cref="IChannelListener"/> that this 
        /// <see cref="IDeviceListener"/> is listening to events with.
        /// </summary>
        IChannelListener ChannelListener { get; }
        #endregion
    }
}
