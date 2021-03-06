using SpazioDati.Dandelion.Domain.Models;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using System;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class LanguageDetectionService
    {
        private ApiClient _apiClient;

        public LanguageDetectionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<LanguageDetectionDto> CallLanguageDetectionAsync(LanguageDetectionParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<LanguageDetectionDto>(ApiClient.LanguageDetectionUriBuilder(), ApiClient.LanguageDetectionContentBuilder(source, parameters), parameters.HttpMethod);
        }

    }
}