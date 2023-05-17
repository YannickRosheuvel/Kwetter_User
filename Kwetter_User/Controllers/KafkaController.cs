using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Kwetter_User.Controllers
{

        [ApiController]
        [Route("api/kafka")]
    public class KafkaController : Controller
    {
        private readonly ProducerConfig _producerConfig;

            public KafkaController()
            {
                _producerConfig = new ProducerConfig
                {
                    BootstrapServers = "pkc-ewzgj.europe-west4.gcp.confluent.cloud:9092",
                    SecurityProtocol = SecurityProtocol.SaslSsl,
                    SaslMechanism = SaslMechanism.Plain,
                    SaslUsername = "YL3Y522I4ZLXYMT3",
                    SaslPassword = "atjBFT+1sBaZfbKGJnU391/avvat2QXD0gS9flsqo9zLR2j/V3IZgchpsp1YxrNJ",
                    // Optional: Set additional configuration properties as needed
                };
            }

            /// <summary>
            /// Publishes a message to Kafka.
            /// </summary>
            /// <param name="message">The message to publish.</param>
            /// <returns>A response indicating the result of the operation.</returns>
            [HttpPost("publish")]
            public IActionResult PublishToKafka([FromBody] string message)
            {
                using (var producer = new ProducerBuilder<Null, string>(_producerConfig).Build())
                {
                    try
                    {
                        producer.Produce("your_topic_name", new Message<Null, string> { Value = message });
                        producer.Flush(TimeSpan.FromSeconds(10));
                    }
                    catch (ProduceException<Null, string> ex)
                    {
                        return BadRequest($"Failed to publish message to Kafka: {ex.Message}");
                    }
                }

                return Ok("Message published to Kafka successfully");
            }
        }
    }

