using HGAPI.Endpoints;

namespace HGAPI.Models.DAL
{
	public static class AddEnpointsDependencies
	{
		public static WebApplication AddEndpointDependencies(this WebApplication app)
		{
			app.AccountEndpoints();
			app.AddUserPlayerEndpoints();
			app.AddProductGamesEndPoints();
			return app;
		}
	}
}
