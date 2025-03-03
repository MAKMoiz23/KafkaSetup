# 📦 KafkaOrderSystem

## 🚀 Description
KafkaOrderSystem is a backend application that leverages Apache Kafka for message brokering, enabling efficient processing of order data. It includes producer and consumer services developed using .NET Core.

## ✨ Features

- Order producer service to publish order messages to Kafka topics.

- Consumer service to process orders from Kafka topics.

- Swagger UI for API testing.

- Docker support for containerized deployment.

## 📂 Project Structure
```
📦 KafkaOrderSystem
├─ 📁 KafkaOrderSystem.Producer
│   ├─ 📄 OrderController.cs
│   └─ 📄 Program.cs
├─ 📁 KafkaOrderSystem.Consumer
│   ├─ 📄 Worker.cs
│   └─ 📄 Program.cs
├─ 📁 KafkaOrderSystem.Shared
│   └─ 📄 OrderModel.cs
├─ 📄 README.md
└─ 📄 docker-compose.yml
```
## 🚧 Installation

### Clone the repository
```
git clone https://github.com/username/KafkaOrderSystem.git
```
### Navigate to the project directory
```
cd KafkaOrderSystem
```
### Install dependencies for both Producer and Consumer
```
dotnet restore
```
### Run and build Services
```
docker-compose up --bulid
```
### Run Services
```
docker-compose up
```

## 🧪 Usage

Producer API: Submit orders via the OrderController.

Consumer Service: Automatically consumes orders from Kafka.

## 🔍 API Endpoints

**Method** -> POST

**Endpoint** -> /api/order

**Description** -> Submit a new order

## 🧰 Technologies Used

### 🟦 .NET Core

### ☕ Kafka

### 🐳 Docker
