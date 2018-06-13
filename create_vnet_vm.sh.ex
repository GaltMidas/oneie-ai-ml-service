az group create --name myResourceGroup --location eastus

az network vnet create \
  --name myVirtualNetwork \
  --resource-group myResourceGroup \
  --subnet-name default

az vm create \
  --resource-group myResourceGroup \
  --name myVm2 \
  --image UbuntuLTS \
  --generate-ssh-keys

az vm open-port --port 80 --resource-group myResourceGroup --name myVM

; ssh pub.lic.ip.address
