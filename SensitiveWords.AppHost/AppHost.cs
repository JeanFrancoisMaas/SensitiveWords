var builder = DistributedApplication.CreateBuilder(args);
var sql = builder.AddSqlServer("sql").AddDatabase("sanitizerdb");

var sanitizer = builder.AddProject<Projects.SensitiveWords_MS_Sanitizer>("sensitivewords-ms-sanitizer").WithUrl("https://localhost:7018/swagger").WithReference(sql);


builder.AddProject<Projects.SensitiveWords_WebApp>("sensitivewords-webapp").WithReference(sanitizer);



builder.Build().Run();
