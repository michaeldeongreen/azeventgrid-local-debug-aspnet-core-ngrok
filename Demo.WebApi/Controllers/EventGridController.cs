using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json.Linq;

namespace Demo.WebApi.Controllers
{
    [Route("eventgrid")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]    
    public class EventGridController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] List<EventGridEvent> eventGridEvents)
        {
            IActionResult result = Ok();

            foreach (EventGridEvent eventGridEvent in eventGridEvents)
            {
                // subscription validation
                if (eventGridEvent.EventType == EventTypes.EventGridSubscriptionValidationEvent)
                {
                    var eventData = ((JObject)(eventGridEvent.Data)).ToObject<SubscriptionValidationEventData>();

                    var responseData = new SubscriptionValidationResponse()
                    {
                        ValidationResponse = eventData.ValidationCode
                    };
                    return Ok(responseData);
                }

                // handle other eventgrid events
                await HandleEventGridEventAsync(eventGridEvent);
            }
            return Ok();
        }
        private async Task<IActionResult> HandleEventGridEventAsync(EventGridEvent eventGridEvent)
        {
            if (eventGridEvent.EventType == EventTypes.StorageBlobCreatedEvent)
            {
                // do something
            }

            // delay return by 3 seconds
            await Task.Delay(3000);

            return Ok();
        }
    }
}