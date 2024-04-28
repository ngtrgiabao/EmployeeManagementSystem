using System.Net.Http.Json;
using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contacts;

namespace ClientLibrary.Services.Implementations;

public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
{
    public const string AuthUrl = "api/authentication";
    
    public async Task<GeneralResponse> CreateAsync(Register user)
    {
        var httpClient = getHttpClient.GetPublishHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
        if (!result.IsSuccessStatusCode) return new GeneralResponse(false, " Error Occured ");

        return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
    }

    public async Task<LoginResponse> SignInAsync(Login user)
    {
        var httpClient = getHttpClient.GetPublishHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
        if (!result.IsSuccessStatusCode) return new LoginResponse(false, " Error Occured ");

        return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
    }

    public async Task<LoginResponse> RefreshToken(RefreshToken token)
    {
        var httpClient = getHttpClient.GetPublishHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/refresh-token", token);
        if (!result.IsSuccessStatusCode) return new LoginResponse(false, " Error Occured ");

        return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
    }
}