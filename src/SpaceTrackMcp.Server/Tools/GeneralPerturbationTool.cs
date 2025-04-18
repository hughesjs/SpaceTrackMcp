using System.ComponentModel;
using JetBrains.Annotations;
using ModelContextProtocol.Server;
using SpaceTrackSdk.Public.Clients;
using SpaceTrackSdk.Public.DataModels.BasicSpaceData;

namespace SpaceTrackMcp.Server.Tools;

[McpServerToolType]
[UsedImplicitly]
public class GeneralPerturbationTool
{
    private readonly IClientAdapter<GeneralPerturbation> _client;

    public GeneralPerturbationTool(IClientAdapter<GeneralPerturbation> client)
    {
        _client = client;
    }

    [McpServerTool(Destructive = false, Idempotent = true, Name = "General Perturbation", OpenWorld = false)]
    [Description("Searches the SpaceTrack API for a single general perturbation based on the specified predicate")]
    public Task<GeneralPerturbation?> GetOne(string predicates)
    {
        return _client.Get(predicates);
    }
    
    [McpServerTool(Destructive = false, Idempotent = true, Name = "General Perturbation", OpenWorld = false)]
    [Description("Searches the SpaceTrack API for many general perturbations based on the specified predicate")]
    public async Task<List<GeneralPerturbation>> GetMany(string predicates)
    {
        return await _client.GetMany(predicates) ?? [];
    }
}