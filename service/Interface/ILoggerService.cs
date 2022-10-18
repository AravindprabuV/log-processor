using System;
namespace service.Interface
{
    public interface ILoggerService
    {
        public Task<Dictionary<int, string>> GetApiIdFromFile(string file);

    }
}

