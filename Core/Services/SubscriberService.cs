using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Exceptions;

namespace Core.Services
{
    public class SubscriberService
    {
        private readonly Regex EmailRegex =
            new(@"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

        //private readonly Regex EmailRegex2 = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IEmailValidationRepository _emailValidationRepository;
        private readonly IEmailingService _emailingService;

        public SubscriberService(ISubscriberRepository subscriberRepository,
                                 IEmailValidationRepository emailValidationRepository,
                                 IEmailingService emailingService)
        {
            _subscriberRepository = subscriberRepository;
            _emailValidationRepository = emailValidationRepository;
            _emailingService = emailingService;
        }

        public async Task RegisterNewSubscriberAsync(string email)
        {
            if (!IsEmailInputValid(email)) throw new InvalidEmailFormatException(email);

            var subscriber = await GetSubscriberByEmailAsync(email);
            if (subscriber != null) throw new EmailExistsException(subscriber.Email);

            var res = await ValidateWithAbstractAPIAsync(email);
            if (res)
            {
                if (await _subscriberRepository.AddNewSubscriberAsync(new(email)) == true)
                {
                   await _emailingService.SendEmailAsync(email);
                }
            }
        }

        public async Task<Subscriber?> GetSubscriberByEmailAsync(string email)
        {
            return await _subscriberRepository.GetSubscriberByEmailAsync(email);
        }


        public async Task<bool> ValidateWithAbstractAPIAsync(string email)
        {
            var res = await _emailValidationRepository.VerifyEmailWithAbstractAPIAsync(email);
            if (!string.IsNullOrEmpty(res.autocorrect)) throw new EmailAutocorrectException(res.autocorrect, res.email);
            if (!res.is_valid_format.Value) { throw new InvalidEmailFormatException(res.email); }
            else { return true; }

        }


        public Regex GetEmailRegex()
        {
            return EmailRegex;
        }

        public bool IsEmailInputValid(string email)
        {
            return EmailRegex.IsMatch(email);
        }



    }
}
