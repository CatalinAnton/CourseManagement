import { GET_COURSES, SET_COURSES, POST_COURSE } from './courses.constants'

export const getCourses = (payload, resolve, reject) => ({
    type: GET_COURSES,
    payload: { resolve, reject }
  })
  
  export const setCourses = resources => ({
    type: SET_COURSES,
    payload: { resources }
  })
  
  export const postCourse = (course, resolve, reject) => ({
    type: POST_COURSE,
    payload: { course, resolve, reject }
  })
  