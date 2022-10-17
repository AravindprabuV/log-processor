using System;
namespace service.Interface
{
    public interface ILoggerService
    {
        public Task ParseLogFiles(string file);

    }
}

