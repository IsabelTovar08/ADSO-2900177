using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Utilities.Exeptions;
using Google.Apis.Http;
using Google.Apis.Auth;
using Microsoft.Extensions.Logging;
using Entity.Models;
using Entity.DTOs.Auth;
using Entity.DTOs;

namespace Business.Services.Auth
{
    public class AuthService
    {
        private readonly UserService _userService;
        private readonly GoogleAuthService _googleAuthService;

        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserService userService, GoogleAuthService googleAuthService, IConfiguration config, ILogger<AuthService> logger)
        {
            _userService = userService;
            _googleAuthService = googleAuthService;
            _config = config;
            _logger = logger;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            // Validar usuario
            var user = await _userService.ValidateUserAsync(email, password);
            if (user == null)
                throw new ValidationException("Credenciales inválidas");

            // Generar token
            return user;
        }



        public async Task<User?> AuthenticateWithGoogleCodeAsync(GoogleCodeDTO code)
        {
            if (string.IsNullOrWhiteSpace(code?.Code))
            {
                _logger.LogWarning("Código de autorización de Google es nulo o vacío.");
                return null;
            }

            var clientId = _config["Authentication:Google:ClientId"];
            var clientSecret = _config["Authentication:Google:ClientSecret"];
            var redirectUri = _config["Authentication:Google:RedirectUri"];

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(redirectUri))
            {
                _logger.LogError("Configuración de Google OAuth incompleta.");
                return null;
            }

            using var httpClient = new HttpClient();
            var parameters = new Dictionary<string, string>
                {
                    { "code", code.Code },
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "redirect_uri", redirectUri },
                    { "grant_type", "authorization_code" }
                };

            try
            {
                var response = await httpClient.PostAsync("https://oauth2.googleapis.com/token", new FormUrlEncodedContent(parameters));
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Respuesta de Google: {json}", json);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Error al intercambiar el código con Google: {json}");
                    return null;
                }

                var tokenData = JsonSerializer.Deserialize<GoogleTokenResponse>(json);
                if (tokenData == null || string.IsNullOrEmpty(tokenData.IdToken))
                {
                    _logger.LogWarning("No se pudo obtener un id_token válido.");
                    return null;
                }

                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string> { clientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenData.IdToken, settings);
                if (payload == null)
                {
                    _logger.LogWarning("El ID token no es válido.");
                    return null;
                }
                var userInfo = new GoogleUserInfo
                {
                    Email = payload.Email,
                    FirstName = payload.GivenName,
                    LastName = payload.FamilyName
                };

                return await _googleAuthService.GetOrCreateGoogleUser(userInfo);
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "Error HTTP al solicitar token a Google.");
                return null;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Error al deserializar la respuesta JSON de Google.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado en autenticación con Google.");
                return null;
            }
        }
    }
}