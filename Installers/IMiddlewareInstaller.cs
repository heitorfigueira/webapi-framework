using Microsoft.AspNetCore.Builder;

namespace WebApi.Framework.Installers
{
    public interface IMiddlewareInstaller
    {
        public int MiddlewareOrder => -1;

        void AddMiddlewareInstaller(WebApplication app);
    }
}
