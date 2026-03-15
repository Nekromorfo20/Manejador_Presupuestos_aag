using System.Security.Claims;

namespace ManejoPresupuesto.Servicios
{
    public interface IServicioUsuarios
    {
        int ObtenerUsuariosId();
    }

    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly HttpContext httpContext;
        public ServicioUsuarios(IHttpContextAccessor httpContextAccesor)
        {
            httpContext = httpContextAccesor.HttpContext;
        }
        public int ObtenerUsuariosId() {
            if (httpContext.User.Identity.IsAuthenticated) {
                var idClaim = httpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            }
            else {
                throw new ApplicationException("El usuario no está autenticado");
            }
        }
    }
}
