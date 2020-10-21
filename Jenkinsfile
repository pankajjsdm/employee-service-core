pipeline {
    agent any
    stages {
        stage('Restore Packages') {
            steps {
                sh 'dotnet restore'
            }
        }
		stage('Clean') {
            steps {
                sh 'dotnet clean'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
		stage('Create Package') {
            steps {
                sh 'dotnet pack --no-build --output nupkgs'
            }
        }               
    }
}