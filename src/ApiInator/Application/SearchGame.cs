using SlimMessageBus;
using ApiInator.Generated;
using SearchGameRequest = ApiInator.Generated.SearchGameRequest;

namespace ApiInator.Generated
{
    public partial class SearchGameRequest : IRequest<SearchGameResponse>
    {
    }
}

namespace ApiInator.Application
{
    public class SearchGameHandler(SteamApi.SteamApi steamApi) : IRequestHandler<SearchGameRequest, SearchGameResponse>
    {
        public async Task<SearchGameResponse> OnHandle(SearchGameRequest request, CancellationToken cancellationToken)
        {
            var name = request.SearchPhrase;
            try
            {
                var games = await steamApi.SearchPreviewByNameAsync(name);
                var response = new SearchGameResponse();
                response.Games.AddRange(games.Select(g => new GamePreview()
                        { Name = g.Name, SteamAppId= g.SteamAppID, TinyImage = g.TinyImage }));
                return response;
            }
            catch
            {
                return new SearchGameResponse();
            }
        }
    }
}