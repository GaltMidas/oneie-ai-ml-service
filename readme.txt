# Project created from

dotnet new webapi -o oneie-ai-ml-service

MongoDB.Driver
Microsoft.Extensions.Configuration

# API

http://localhost:5000/api/leadscoring/perform/james/google =>

[
    "jaems",
    "google",
    "db Data here",
    "80%"
]

# Deploy

create vm in vnet       see create_vnet_vm.sh.ex, also opens port 80 in inbound rules

git clone https://github.com/GaltMidas/oneie-ai-ml-service.git

cp appsettings.Development.json appsettings.json
and edit with your specific info

$ restore       installs dependencies

edit Program.cs
---------------
.UseUrls("http://x.xx.xx.xx:80")
replace x's with the servers ip

and run
$ sudo dotnet run     or get permission denied when running on port 80

# References

https://docs.microsoft.com/en-us/azure/virtual-network/quick-create-cli