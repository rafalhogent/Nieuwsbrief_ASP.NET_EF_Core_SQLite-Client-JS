using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Net;
using Core.Models;
using Core.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class EmailValidationRepository : IEmailValidationRepository
    {
        private readonly EmailValidationConfig _emailValidConfig;

        public EmailValidationRepository(IOptionsMonitor<EmailValidationConfig> optionsMonitor)
        {
            _emailValidConfig = optionsMonitor.CurrentValue;
        }


        public async Task<EmailValidationResult> VerifyEmailWithAbstractAPIAsync(string email)
        {

            HttpClient client = new HttpClient();
            var response = await client
                .GetAsync($"{_emailValidConfig.EMAIL_API_URL}?api_key={_emailValidConfig.EMAIL_API_KEY}&email={email}");


            if (response.IsSuccessStatusCode)
            {
                string rawJSON = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<EmailValidationResult>(rawJSON);
                return res;
            }

            throw new Exception($"De service van onze partner AbstractAPI is niet beschikbaar : {response.StatusCode}. "
                + " Contacteer helpdesk");

        }
    }
}
