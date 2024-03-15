import ApiService from './ApiService'
const apiUrl = 'api/Item'

export default {
    GetAll: function (id) {
        return ApiService.get(`${apiUrl}/GetAll/${id}`)
    },
    Add: function (data) {
        return ApiService.post(`${apiUrl}/Add`, data)
    }
}