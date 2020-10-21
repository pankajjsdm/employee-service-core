pipeline {
    agent any    
    environment {
        dotnet ='C:\\Program Files\\dotnet\\'
        }     
   stages{
 stage('Checkout') {
    steps {
     git credentialsId: 'Github', url: 'https://github.com/pankajjsdm/EMPService.git/', branch: 'master'
     }
  }
  stage('Restore'){
   steps{
      bat 'donet restore EmpService.sln'
     }
  }
    stage('Clean'){
    steps{
        bat "dotnet clean EmpService.sln"
     }
   }
  stage('Build'){
   steps{
      bat "dotnet build EmpService.sln --configuration Release"
    }
 } 
    stage('Publish'){
     steps{
       bat "dotnet publish EmpService.sln "
     }
    }
   }
}

