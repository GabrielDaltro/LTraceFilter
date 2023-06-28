using Newtonsoft.Json;
using LTraceFilter.Business.Application;

namespace LTraceFilter.Data
{
    public abstract class BaseReposiory
    {
        private readonly string path;

        protected BaseReposiory(string path)
        {
            this.path = path;
        }

        private string GetConfigFromFile()
        {
            try
            {
                var reader = new StreamReader(path);
                var json = reader.ReadToEnd();
                reader.Dispose();
                return json;
            }
            catch (Exception e)
            {
                throw new PersistenceException("Error to read config file", e);
            }
        }

        protected T GetFromFile<T>()
        {
            try
            {
                string jsonConfig = GetConfigFromFile();
                var config = JsonConvert.DeserializeObject<T>(jsonConfig);
                if (config == null)
                    throw new PersistenceException($"could not get {typeof(T)} from file");
                return config;
            }
            catch (PersistenceException e)
            {
                throw;
            }
            catch (Exception e) 
            {
                throw new PersistenceException($"could not deserialize {typeof(T)} from file", e);
            }
        }

        protected void SaveIntoFile<T>(T data)
        {
            try
            {
                var serializedData = JsonConvert.SerializeObject(data);
                if (serializedData == null)
                    throw new PersistenceException("could not Serialize data from file");
                File.WriteAllText(path, serializedData);
            }
            catch (Exception e)
            {
                throw new PersistenceException($"could not persist {typeof(T)} to file", e);
            }
        }
    }
}