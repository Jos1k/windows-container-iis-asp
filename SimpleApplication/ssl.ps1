import-module webadministration

$cert = (New-SelfSignedCertificate -DnsName localhost -CertStoreLocation cert:Localmachine\My).Thumbprint
New-WebBinding -Name "Default Web Site" -IP "*" -Port 443 -Protocol https
Get-Item cert:\LocalMachine\MY\$cert | New-Item IIS:\SslBindings\0.0.0.0!443

# iisreset

