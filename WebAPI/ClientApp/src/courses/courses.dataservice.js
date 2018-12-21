import { API } from '../common'

export const getCourses = () => API.GET('https://localhost:5003/api/courses').toJson()
export const postCourse = course => API.POST('https://localhost:5003/api/courses', course)
