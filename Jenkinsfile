pipeline {
  agent any
  stages {
    stage('BUILD') {
      steps {
        powershell 'buildAquariumApi'
      }
    }
  }
  environment {
    dev = 'dev'
  }
}