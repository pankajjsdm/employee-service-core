node {
    stage('Checkout git repo') {
      git branch: 'master', url: 'https://github.com/pankajjsdm/EMPService'
    }
    stage('build and publish') {
        sh(script: "dotnet publish EmpService.sln.sln -c Release ", returnStdout: true)
    }
   
}