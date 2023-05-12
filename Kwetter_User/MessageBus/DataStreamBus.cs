using System;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Data_Stream
{
    class DataStream : IHostedService
    {
        private readonly ILogger<DataStream> _logger;

        public DataStream(ILogger<DataStream> logger)
        {
            _logger = logger;
        }

        public void ConsumeMessages(string[] args)
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {


            var topic = "my-stream";

            var conf = new ConsumerConfig
            {
                BootstrapServers = "host.docker.internal:29092",
                GroupId = Environment.MachineName,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                consumer.Subscribe(topic);

                try
                {
                    while (true)
                    {
                        var msg = consumer.Consume();
                        if (msg == null) continue;

                        if (msg.IsPartitionEOF)
                        {
                            _logger.LogError($"% {msg.Topic} [{msg.Partition}] reached end at offset {msg.Offset}");
                        }
                        else
                        {
                            MsgProcess(msg);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Cancelled
                    _logger.LogInformation("Consumer was cancelled");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while consuming messages");
                }
                finally
                {
                    consumer.Close();
                }


            }
            return null;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void MsgProcess(ConsumeResult<Ignore, string> msg)
        {
            try
            {
                _logger.LogInformation("Received message: {Message}", msg.Message.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the message");
            }
        }
    }
}
