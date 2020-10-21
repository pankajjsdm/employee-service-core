pipeline {
    agent any    
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        }     
   
 stage('Checkout') {
    steps {
     git credentialsId: 'Github', url: 'https://github.com/pankajjsdm/EMPService.git/', branch: 'master'
     }
  }
  stage('Restore packages'){
   steps{
      sh "dotnet restore EmpService/EmpService.csproj"
     }
  }
    stage('Clean'){
    steps{
        sh "dotnet clean EmpService/EmpService.csproj"
     }
   }
  stage('Build'){
   steps{
      sh "dotnet build EmpService/EmpService.csproj --configuration Release"
    }
 } 
    stage('Publish'){
     steps{
       sh "dotnet publish EmpService/EmpService.csproj "
     }
	 }
}

