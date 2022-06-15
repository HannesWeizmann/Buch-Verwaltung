using Microsoft.Extensions.Configuration;

namespace FahrzeugeWPF
{
    public class KonfigurationsLeser : IKonfigurationsLeser
    {
        private readonly IConfiguration _configuration;

        public KonfigurationsLeser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string LiesDatenbankVerbindungZurMariaDB()
        {
            return _configuration.GetConnectionString("MariaDB");
        }
    }

    public interface IKonfigurationsLeser
    {
    }
}

