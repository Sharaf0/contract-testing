#this is simulation of the provider pipeline
#it should take related pacts and verify them against the provider

#we should copy all the pacts to the provider from "../../CentralPactRepo/pacts"
#and then verify them against the provider, by running "dotnet test" on the provider


path_to_pacts="../CentralPactRepo/pacts"
provider="ProviderService"
provider_lower="providerservice"

#since pacts files are written in this format "consumerName-providerName.json"
#we should get only the pacts that are related to this provider, i.e. ".*providerName.json"
#provider name is already known

rm -rf pacts
mkdir -p pacts
cp -R $path_to_pacts/*$provider.json pacts/
cp -R $path_to_pacts/*$provider_lower.json pacts/

dotnet test