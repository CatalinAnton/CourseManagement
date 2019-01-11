import { API } from '../common'

export const getResources = courseId => API.GET(`https://localhost:5005/api/resourses?courseId=${courseId}`).toJson()
export const postResource = resource => API.POST('https://localhost:5005/api/resourses', resource)
