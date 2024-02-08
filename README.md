This Repo, Contains a complete Sonar Qube Set up for .Net Web Api Application.
Refer Blog: 
Prerequsite:
1. Azure Resources -> dev and test subscription
2. Create a service principle with client secret.
3. In each subscriptions you can have resource groups, azure web app hosted in a basic app service plan
4. A sonar cloud project integrated with your Github Organization
5. A sonar token generated .
   [optional] : if you are not cloning this current repository.
6. A .net / application code hosted in remote github repository.

Note:
1. The workflows are disabled .
2. The secrets are populated with dummy values, so if you clone use proper secrets for pipelines to work.
3. The sonar token secret is also changed to dummy value.

pipeline References:
1. During PR -> https://github.com/AllAboutAzure/sonarqube-demo/actions/runs/7830543627
   ![image](https://github.com/AllAboutAzure/sonarqube-demo/assets/156210181/f0c197d5-f0fc-472f-adf3-af829427bf57)
   
2. After merging with Main -> https://github.com/AllAboutAzure/sonarqube-demo/actions/runs/7830543627
   ![image](https://github.com/AllAboutAzure/sonarqube-demo/assets/156210181/1d69368e-c2ff-4124-abaa-d5bf82ebc9b1)

