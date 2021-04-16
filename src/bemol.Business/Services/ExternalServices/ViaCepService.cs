using bemol.Business.Extensions;
using bemol.Business.Interfaces;
using bemol.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bemol.Business.Services.ExternalServices
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        public ViaCepService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://viacep.com.br")
            };
        }

        public async Task<Cep> GetDadosCep(string cep)
        {
            var cepOnlyNumber = String.Join("", System.Text.RegularExpressions.Regex.Split(cep, @"[^\d]"));

            var response = await _httpClient.GetAsync($"/ws/{cepOnlyNumber}/json/");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var respVC = await response.DeserealizeResponse<Cep>();

                    if (respVC.cep == null) return null;

                    return respVC;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }
    }
}
