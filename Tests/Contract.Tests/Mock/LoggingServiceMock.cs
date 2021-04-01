using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Services;

namespace Routindo.Contract.Tests.Mock
{
    class LoggingServiceMock: ILoggingService
    {
        public void Trace(string message)
        {
            throw new NotImplementedException();
        }

        public void Trace<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Trace(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Trace(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T>(T value)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
