# rabbit-chat

Simple chat application with real-time updates.

API written in C#, RabbitMQ for messenging service, Angular for front end, Electron for desktop.

Standard API for processing data. When a message is created, RabbitMQ sends a trigger to the front end to request an updated list of messages that relate to the user. This is how the real-time updating will be achieved.

Hosted locally in containers on a Windows Server 2019 (Insiders Preview).

There may be more efficient ways of dealing with the real-time requirement, but I wanted to become more comfortable with RabbitMQ and having containerized micro-services.
