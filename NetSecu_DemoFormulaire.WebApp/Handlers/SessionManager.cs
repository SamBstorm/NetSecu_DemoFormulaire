using NetSecu_DemoFormulaire.Models;
using System.Text.Json;

namespace NetSecu_DemoFormulaire.WebApp.Handlers
{
    public class SessionManager
    {
        private ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public UserModel? CurrentUser {
            get
            {
                string? value = _session.GetString(nameof(CurrentUser));
                if (value is null) return null;
                return JsonSerializer.Deserialize<UserModel>(value);
            }
            set
            {
                if (value is null) return;
                _session.SetString(nameof(CurrentUser), JsonSerializer.Serialize(value));
            }
        }
    }
}
