using System;
using System.Collections.Generic;
using System.Timers;

using MyoSharp.Device;

namespace MyoSharp.Poses
{
    public class HeldPose : IHeldPose
    {
        #region Constants
        private static readonly TimeSpan DEFAULT_INTERVAL = TimeSpan.FromSeconds(1);
        #endregion

        #region Fields
        private readonly List<Pose> _targetPoses;
        private readonly Timer _timer;
        private readonly IMyoEventGenerator _myo;

        private bool _timerAlive;
        private bool _timerPaused;
        private IMyo _triggeringMyo;
        private bool _disposed;
        private Pose _lastPose;
        #endregion

        #region Constructors
        protected HeldPose(IMyoEventGenerator myo, TimeSpan interval, IEnumerable<Pose> targetPoses)
        {
            _targetPoses = new List<Pose>(targetPoses);
            if (_targetPoses.Contains(Pose.Unknown))
            {
                throw new ArgumentException("All target poses must be specified.", "targetPoses");
            }

            if (_targetPoses.Count < 1)
            {
                throw new ArgumentException("At least one target pose must be specified.", "targetPoses");
            }

            _timer = new Timer()
            {
                AutoReset = true,
                Interval = interval.TotalMilliseconds,
            };
            _timer.Elapsed += Timer_Elapsed;
            
            _lastPose = Pose.Unknown;

            _myo = myo;
            _myo.PoseChanged += Myo_PoseChanged;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="HeldPose"/> class.
        /// </summary>
        ~HeldPose()
        {
            Dispose(false);
        }
        #endregion

        #region Events
        public event EventHandler<PoseEventArgs> Triggered;
        #endregion

        #region Properties
        public TimeSpan Interval
        {
            get
            {
                var interval = TimeSpan.FromMilliseconds(_timer.Interval);

                return interval;
            }
            
            set
            {
                _timer.Interval = value.TotalMilliseconds;
            }
        }
        #endregion

        #region Methods
        public static IHeldPose Create(IMyoEventGenerator myo, Pose targetPose)
        {
            var interval = DEFAULT_INTERVAL;

            return Create(
                myo, 
                interval, 
                targetPose);
        }

        public static IHeldPose Create(IMyoEventGenerator myo, params Pose[] targetPoses)
        {
            return Create(
                myo,
                (IEnumerable<Pose>)targetPoses);
        }

        public static IHeldPose Create(IMyoEventGenerator myo, IEnumerable<Pose> targetPoses)
        {
            var interval = DEFAULT_INTERVAL;

            return Create(
                myo,
                interval,
                targetPoses);
        }

        public static IHeldPose Create(IMyoEventGenerator myo, TimeSpan interval, params Pose[] targetPoses)
        {
            return Create(
                myo, 
                interval, 
                (IEnumerable<Pose>)targetPoses);
        }

        public static IHeldPose Create(IMyoEventGenerator myo, TimeSpan interval, IEnumerable<Pose> targetPoses)
        {
            return new HeldPose(
                myo, 
                interval,
                targetPoses);
        }

        public void Start()
        {
            lock (_timer)
            {
                _timer.Start();
                _timerAlive = true;
                _timerPaused = false;
            }
        }

        public void Stop()
        {
            lock (_timer)
            {
                _timer.Stop();
                _timerAlive = false;
                _timerPaused = false;
            }
        }

        public void Reset()
        {
            lock (_timer)
            {
                Stop();
                Start();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    Stop();
                    _timer.Dispose();

                    _myo.PoseChanged -= Myo_PoseChanged;
                }
            }
            finally
            {
                _disposed = true;
            }
        }

        protected virtual void OnTriggered(IMyo myo, DateTime timestamp, Pose pose)
        {
            var handler = Triggered;
            if (handler != null)
            {
                var args = new PoseEventArgs(
                    myo,
                    timestamp,
                    pose);
                handler.Invoke(this, args);
            }
        }
        #endregion

        #region Event Handlers
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var triggeringMyo = _triggeringMyo;
            if (triggeringMyo == null)
            {
                return;
            }

            var currentPose = _lastPose;
            if (!_targetPoses.Contains(currentPose))
            {
                return;
            }

            OnTriggered(
                triggeringMyo, 
                e.SignalTime,
                currentPose);
        }

        private void Myo_PoseChanged(object sender, PoseEventArgs e)
        {
            var samePose = _lastPose == e.Pose;
            _lastPose = e.Pose;
            _triggeringMyo = e.Myo;

            lock (_timer)
            {
                if (_timerAlive)
                {
                    return;
                }

                if (samePose && _targetPoses.Contains(e.Pose))
                {
                    if (_timerPaused)
                    {
                        _timerPaused = false;
                        _timer.Start();
                    }
                }
                else
                {
                    _timerPaused = true;
                    _timer.Stop();
                }
            }
        }

        public void AddPoses(params Pose[] poses)
        {
            foreach(var pose in poses)
            {
                if (_targetPoses.Contains(pose)) continue;
                _targetPoses.Add(pose);
            }
        }

        public void RemovePoses(params Pose[] poses)
        {
            foreach (var pose in poses)
            {
                if (!_targetPoses.Contains(pose)) continue;
                _targetPoses.Remove(pose);
            }
        }
        #endregion
    }
}
