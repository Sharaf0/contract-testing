#this is simulation of the consumer pipeline
#it should run the tests and generate the pacts

#we should copy all the pacts to the central pact repo, in form of git commit to the master branch
#and then run all provider's pipelines to verify the pacts
#if all the providers pass, then all good.
#otherwise, we should fail the build, and revert the commit

path_to_pacts="../CentralPactRepo/pacts"
consumer="ConsumerService1"

rm -rf pacts
mkdir -p pacts

#run the tests
python -m unittest test_consumer_service1.py

#copy the pacts to the central pact repo
cp -R pacts/* $path_to_pacts/
