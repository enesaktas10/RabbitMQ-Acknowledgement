# RabbitMQ-Acknowledgement
<img src="rabbitmq.png">

RabbitMQ immediately marks the message sent to the consumer for deletion from the queue, regardless of whether it is processed successfully or not.

If there is any interruption or problem in the process of consumers processing the messages they receive from the queue, the task will not be completed because the message will not be processed.

If the message has been processed successfully, the consumer must warn RabbitMq in order for it to be deleted from the queue.

I showed you how to use the message acknowledgment feature in this repository. You can review the codes and get information.
