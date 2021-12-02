# Our Deployments

## Creating our Kubernetes Cluster

### Start MiniKube

We will be using [Minikube](https://minikube.sigs.k8s.io/docs/start/), and it is already installed on your machine. We will be using the Hyper-V backend. Go to a Windows Terminal and run:

```
minikube start --driver=hyperv
```

### Enable the Addons

For Ingress:

```
minikube addons enable ingress
```

For Ingress DNS

```
minikube addons enable ingress-dns
```

### Create DNS Rule for `*.hypertheory.com`

```
Add-DnsClientNrptRule -Namespace ".hypertheory.com" -NameServers "$(minikube ip)"
```

> Note: to remove it after you are done:

```
Get-DnsClientNrptRule | Where-Object {$_.Namespace -eq '.hypertheory.com'} | Remove-DnsClientNrptRule -Force; Add-DnsClientNrptRule -Namespace ".hypertheory.com" -NameServers "$(minikube ip)"
```

## Add A Namespace For Our App

```
kubectl create namespace hypertheory
```

Use that Namespace

```
kubectl config set-context --current --namespace=hypertheory
```
