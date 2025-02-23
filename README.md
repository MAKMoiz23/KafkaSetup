📦 KafkaOrderSystem

🚀 Description

KafkaOrderSystem is a backend application that leverages Apache Kafka for message brokering, enabling efficient processing of order data. It includes producer and consumer services developed using .NET Core.

✨ Features

✅ Order producer service to publish order messages to Kafka topics.

✅ Consumer service to process orders from Kafka topics.

✅ Swagger UI for API testing.

✅ Docker support for containerized deployment.

📂 Project Structure

📦 KafkaOrderSystem
├─ 📁 KafkaOrderSystem.Producer
│   ├─ 📄 OrderController.cs
│   └─ 📄 Program.cs
├─ 📁 KafkaOrderSystem.Consumer
│   ├─ 📄 Worker.cs
│   └─ 📄 Program.cs
├─ 📄 README.md
└─ 📄 docker-compose.yml

🚧 Installation

# Clone the repository
git clone https://github.com/username/KafkaOrderSystem.git

# Navigate to the project directory
cd KafkaOrderSystem

# Install dependencies for both Producer and Consumer
dotnet restore

# Run Producer Service
dotnet run --project KafkaOrderSystem.Producer

# Run Consumer Service
dotnet run --project KafkaOrderSystem.Consumer

🧪 Usage

Producer API: Submit orders via the OrderController.

Consumer Service: Automatically consumes orders from Kafka.

🔍 API Endpoints

Method

Endpoint

Description

POST

/api/order

Submit a new order

🧰 Technologies Used

🟦 .NET Core

☕ Kafka

🐳 Docker

🌐 Swagger UI

🛠️ Configuration

Set up Kafka: Ensure Kafka is running locally using Docker or manually.

Environment Variables: Create a .env file with the following:

KAFKA_BROKER=localhost:9092
KAFKA_TOPIC=order-topic
