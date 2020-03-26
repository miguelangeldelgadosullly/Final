import Axios from 'axios'
import exampleService from '../services/ExampleService'
import InvenService from '../services/InvenService'

let apiUrl = 'https://localhost:44380/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios),
    InvenService: new InvenService(Axios, apiUrl)
}