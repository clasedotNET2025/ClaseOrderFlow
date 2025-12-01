using System.Security.Principal;

var builder = DistributedApplication.CreateBuilder(args);

var rabbit = builder
    .AddRabbitMQ("rabbitmq")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("rabbitmq-data")
    .WithManagementPlugin();

var postgres = builder
    .AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("postgres")
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

var redis = builder.AddRedis("redis")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("redis-data-identity")
    .WithRedisInsight();


var db = postgres.AddDatabase("identity");

var identity = builder.AddProject<Projects.OrderFlowClase_API_Identity>("orderflowclase-api-identity")
    .WaitFor(db)
    .WaitFor(rabbit)
    .WithReference(db)
    .WithReference(rabbit);


builder.AddProject<Projects.OrderFlowClase_ApiGateway>("orderflowclase-apigateway")
    .WithReference(redis)
    .WithReference(identity)
    .WaitFor(redis)
    .WaitFor(identity);


builder.Build().Run();