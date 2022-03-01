﻿using System;
using System.Collections.Generic;
using System.Text;

using MyoSharp.Communication;
using MyoSharp.Exceptions;
using MyoSharp.Internal;

namespace MyoSharp.Commands
{
    public class MyoCommand : IMyoCommand
    {
        #region Fields
        private readonly MyoCommandDelegate _command;
        private readonly IMyoErrorHandlerDriver _myoErrorHandlerDriver;
        #endregion

        #region Constructors
        private MyoCommand(IMyoErrorHandlerDriver myoErrorHandlerDriver, MyoCommandDelegate command)
        {
            _myoErrorHandlerDriver = myoErrorHandlerDriver;
            _command = command;
        }
        #endregion

        #region Methods
        public static IMyoCommand Create(IMyoErrorHandlerDriver myoErrorHandlerDriver, MyoCommandDelegate command)
        {
            return new MyoCommand(myoErrorHandlerDriver, command);
        }

        public void Execute()
        {
            IMyoCommandResult result = null;
            try
            {
                result = _command();
                if (result == null)
                {
                    throw new NullReferenceException("The result of a MyoCommandDelegate cannot be null.");
                }

                if (result.Result == MyoResult.Success)
                {
                    return;
                }

                throw CreateMyoException(result);
            }
            finally
            {
                if (result != null)
                {
                    _myoErrorHandlerDriver.FreeMyoError(result.ErrorHandle);
                }
            }
        }

        private Exception CreateMyoException(IMyoCommandResult myoCommandResult)
        {
            var errorMessage = _myoErrorHandlerDriver.GetErrorString(myoCommandResult.ErrorHandle);
            
            return myoCommandResult.Result == MyoResult.ErrorInvalidArgument
                ? (Exception)new ArgumentException(errorMessage)
                : (Exception)new InvalidOperationException(errorMessage);
        }
        #endregion
    }
}
