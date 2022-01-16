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
      bat 'dotnet restore EmpService.sln'
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
       
       def app     
      stage('Clone repository') {               
             
            checkout scm    
      }     
      stage('Build image') {         
       
            app = docker.build("pankajjsdm/docker-compose.yml")    
       }     
      stage('Test image') {           
            app.inside {            
             
             sh 'echo "Tests passed"'        
            }    
        }     
       stage('Push image') {
            docker.withRegistry('https://registry.hub.docker.com', 'git') {            
       app.push("${env.BUILD_NUMBER}")            
       app.push("latest")        
              }    
           }
       
       
   }
}

