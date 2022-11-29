using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Services;
using Core.Exceptions;
using Core.Models;
using Microsoft.Extensions.Options;
using Web.DTOs;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriberController : ControllerBase
    {
        private readonly SubscriberService _subscriberService;

        public SubscriberController(SubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterNewSubscriberAsync(EmailDTO email)
        {
            try
            {
               await _subscriberService.RegisterNewSubscriberAsync(email.Email);
            }
            catch (EmailExistsException e)
            {
                return base.BadRequest($"Het email adres {e.Email} is al ingeschreven");
            }
            catch (EmailAutocorrectException e)
            {
                return base.BadRequest($"Controlleer je invoer: {e.TypedEmail}, \nMisschien bedoel je {e.Autocorrect} ?");
            }
            catch (InvalidEmailFormatException e)
            {
                return base.BadRequest($"Het e-mailadres {e.Email} is niet geldig");
            }
            catch(Exception e)
            {
                return base.BadRequest("Wegens technisch probleem kunnen wij je email niet inschrijven. \n" + e.Message);
            }
            return base.Ok($"Wij hebben je email {email.Email} ingeschreven." + 
                            "\nBinnenkort krijg je een email met bevestiging...");
        }


        
    }
}
