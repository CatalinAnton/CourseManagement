import {
  GET_RESOURCES,
  SET_RESOURCES,
  POST_RESOURCE
} from './resources.constants'

export const getResources = ({ courseId }, resolve, reject) => ({
  type: GET_RESOURCES,
  payload: { courseId, resolve, reject }
})

export const setResources = (courseId, resources) => ({
  type: SET_RESOURCES,
  payload: { courseId, resources }
})

export const postResource = (resource, resolve, reject) => ({
  type: POST_RESOURCE,
  payload: { resource, resolve, reject }
})
