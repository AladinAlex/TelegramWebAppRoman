import ApiService from './ApiService'
const apiUrl = 'api/Catalog'

export default {
    GetAll: function () {
        return ApiService.get(`${apiUrl}/GetAll`)
    },
    Add: function (data) {
        return ApiService.post(`${apiUrl}/Add`, data)
    }
}