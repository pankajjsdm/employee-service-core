pipeline{
    agent any
    
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        }
        
    triggers {
        pollSCM 'H * * * *'
    }
 stage('Checkout') {
    steps {
     git credentialsId: 'Github', url: 'https://github.com/pankajjsdm/EMPService.git/', branch: 'master'
     }
  }
  stage('Restore packages'){
   steps{
      bat "dotnet restore EmpService/EmpService.csproj"
     }
  }
    stage('Clean'){
    steps{
        bat "dotnet clean EmpService/EmpService.csproj"
     }
   }
  stage('Build'){
   steps{
      bat "dotnet build EmpService/EmpService.csproj --configuration Release"
    }
 } 
    stage('Publish'){
     steps{
       bat "dotnet publish EmpService/EmpService.csproj "
     }
}
}
